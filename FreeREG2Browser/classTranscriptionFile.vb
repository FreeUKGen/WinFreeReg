Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports WinFreeReg.TranscriptionTables
Imports BrightIdeasSoftware
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

Public Class TranscriptionFileClass

	Private m_fileName As String
   Public Property FileName() As String
      Get
         Return m_fileName
      End Get
      Set(ByVal value As String)
         m_fileName = value
      End Set
   End Property

   Private m_pathName As String
   Public Property PathName() As String
      Get
         Return m_pathName
      End Get
      Set(ByVal value As String)
         m_pathName = value
      End Set
   End Property

   Private m_fullFilename As String
   Public Property FullFileName() As String
      Get
         Return m_fullFilename
      End Get
      Set(ByVal value As String)
         m_fullFilename = value
      End Set
   End Property

   Private m_fileHeader As FileHeaderClass
   Public Property FileHeader() As FileHeaderClass
      Get
         Return m_fileHeader
      End Get
      Set(ByVal value As FileHeaderClass)
         m_fileHeader = value
      End Set
   End Property

   Private m_recordcollection As DataTable
   Public Property Items() As DataTable
      Get
         Return m_recordcollection
      End Get
      Set(ByVal value As DataTable)
         m_recordcollection = value
      End Set
   End Property

   Private m_Lookups As LookupTables
   Public Property LookupTables() As LookupTables
      Get
         Return m_Lookups
      End Get
      Set(ByVal value As LookupTables)
         m_Lookups = value
      End Set
   End Property

   Private m_FreeregTables As WinFreeReg.FreeregTables
   Public Property FreeregTables() As WinFreeReg.FreeregTables
      Get
         Return m_FreeregTables
      End Get
      Set(ByVal value As WinFreeReg.FreeregTables)
         m_FreeregTables = value
      End Set
   End Property

   Private m_PlaceCode As String
   Public Property PlaceCode() As String
      Get
         Return m_PlaceCode
      End Get
      Set(value As String)
         m_PlaceCode = value
      End Set
   End Property

	Private m_FormHelp As formGeneralHelp
	Public Property FormHelp() As formGeneralHelp
		Get
			Return m_FormHelp
		End Get
		Set(ByVal value As formGeneralHelp)
			m_FormHelp = value
		End Set
	End Property

	Property FileCorrected As Boolean

	Private m_Decoding As Encoding = Encoding.GetEncoding("iso-8859-1")
   Private m_Encoding As Encoding = Encoding.GetEncoding("utf-8")

   Enum FileTypes
      BAPTISMS
      MARRIAGES
      BURIALS
   End Enum

   Sub New()
      MyBase.New()
      m_pathName = ""
      m_fileName = ""
		m_fullFilename = ""
		m_FormHelp = Nothing
	End Sub

	Sub New(ByVal row As DataRow, ByVal lookups As LookupTables, ByVal freeregTables As FreeregTables, ByVal formHelp As formGeneralHelp)
		MyBase.New()
		m_fileName = row("Name")
		m_pathName = row("DirectoryName")
		m_fullFilename = Path.Combine(m_pathName, m_fileName)
		m_Lookups = lookups
		m_FreeregTables = freeregTables
		m_FormHelp = formHelp

		Using m_Reader As New TextFieldParser(m_fullFilename, m_Decoding)
			m_Reader.TextFieldType = FieldType.Delimited
			m_Reader.SetDelimiters(",")
			m_Reader.TrimWhiteSpace = True
			m_Reader.HasFieldsEnclosedInQuotes = True

			m_fileHeader = New FileHeaderClass(m_Reader)
			Dim rec As String() = m_fileHeader.GetHeader()
			If String.IsNullOrEmpty(m_fileHeader.InternalFilename) Then m_fileHeader.InternalFilename = m_fileName
			Dim X = m_fileHeader.Church.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
			If X.Length > 0 Then
				If m_FreeregTables.RegisterTypes.FindByType(X(X.Length - 1)) IsNot Nothing Then
					m_fileHeader.Church = String.Join(" ", X, 0, X.Length - 1)
					m_fileHeader.RegisterType = X(X.Length - 1)
				End If
			End If

			Select Case m_fileHeader.FileType
				Case FileTypes.BAPTISMS
					Dim recordcollection = New TranscriptionTables.BaptismsDataTable
					recordcollection.LinkLookupTables(True, True, lookups.BaptismSex)
					AddNewBaptismRecord(recordcollection, rec)

					While Not m_Reader.EndOfData
						rec = m_Reader.ReadFields()
						AddNewBaptismRecord(recordcollection, rec)
					End While
					recordcollection.AcceptChanges()
					m_recordcollection = recordcollection

				Case FileTypes.BURIALS
					Dim recordcollection = New TranscriptionTables.BurialsDataTable
					recordcollection.LinkLookupTables(True, True, lookups.BurialRelationship)
					AddNewBurialRecord(recordcollection, rec)

					While Not m_Reader.EndOfData
						rec = m_Reader.ReadFields()
						AddNewBurialRecord(recordcollection, rec)
					End While
					recordcollection.AcceptChanges()
					m_recordcollection = recordcollection

				Case FileTypes.MARRIAGES
					Dim recordcollection = New TranscriptionTables.MarriagesDataTable
					recordcollection.LinkLookupTables(True, True, lookups.GroomCondition, lookups.BrideCondition)
					AddNewMarriageRecord(recordcollection, rec)

					While Not m_Reader.EndOfData
						rec = m_Reader.ReadFields()
						AddNewMarriageRecord(recordcollection, rec)
					End While
					recordcollection.AcceptChanges()
					m_recordcollection = recordcollection

			End Select
		End Using

		Dim Crec = freeregTables.Churches.FindByChurchNameChapmanCodePlaceName(m_fileHeader.Church, m_fileHeader.County, m_fileHeader.Place)
		If Crec Is Nothing Then
			m_PlaceCode = String.Empty
			Using dlg As New formMissingDetails With {.TranscriptionFile = Me, .Tables = freeregTables}
				dlg.FormHelp = formHelp
				Dim rc = dlg.ShowDialog
				If rc = DialogResult.Cancel Then Throw New FileHeaderException(String.Format("Unable to find Church record for County:{0} Place:{1} Church:{2}", m_fileHeader.County, m_fileHeader.Place, m_fileHeader.Church))
				If FileCorrected Then Save()
			End Using
		Else
			m_PlaceCode = Crec.FileCode
		End If

	End Sub

   Sub Create(ByVal strFileName As String, ByVal tableLookups As LookupTables, ByVal tableFreereg As FreeregTables, ByVal strFileType As String)
      Try
         Dim NewFile As New TranscriptionFileClass()
         FullFileName = strFileName
         FileName = Path.GetFileName(strFileName)
         PathName = Path.GetDirectoryName(strFileName)
         LookupTables = tableLookups
         FreeregTables = tableFreereg

         FileHeader = New FileHeaderClass()
         FileHeader.FileType = [Enum].Parse(GetType(FileTypes), strFileType, True)

      Catch ex As FileHeaderException
         Throw
      End Try

   End Sub

   Private Sub AddNewBaptismRecord(ByRef recordcollection As WinFreeReg.TranscriptionTables.BaptismsDataTable, ByVal rec As String())
      Dim recBaptism As TranscriptionTables.BaptismsRow
      recBaptism = recordcollection.NewBaptismsRow()
      With recBaptism
         .County = rec(0)
         .Place = rec(1)
         .Church = rec(2)
         .RegNo = rec(3)
         .BirthDate = rec(4)
         .BaptismDate = rec(5)
         .Forenames = rec(6)
         .Sex = rec(7)
         .FathersName = rec(8)
         .MothersName = rec(9)
         .FathersSurname = rec(10)
         .MothersSurname = rec(11)
         .Abode = rec(12)
         .FathersOccupation = rec(13)
         .Notes = rec(14)
         If rec.Length >= 16 Then
            .LDSFiche = rec(15)
            .LDSImage = rec(16)
         End If
      End With
      recordcollection.Rows.Add(recBaptism)
   End Sub

   Private Sub AddNewBurialRecord(ByRef recordcollection As WinFreeReg.TranscriptionTables.BurialsDataTable, ByVal rec As String())
      Dim recBurial As TranscriptionTables.BurialsRow
      recBurial = recordcollection.NewBurialsRow()
      With recBurial
         .County = rec(0)
         .Place = rec(1)
         .Church = rec(2)
         .RegNo = rec(3)
         .BurialDate = rec(4)
         .Forenames = rec(5)
         .Relationship = rec(6)
         .MaleForenames = rec(7)
         .FemaleForenames = rec(8)
         .RelativeSurname = rec(9)
         .Surname = rec(10)
         .Age = rec(11)
         .Abode = rec(12)
         .Notes = rec(13)
         If rec.Length >= 15 Then
            .LDSFiche = rec(14)
            .LDSImage = rec(15)
         End If
      End With
      recordcollection.Rows.Add(recBurial)
   End Sub

   Private Sub AddNewMarriageRecord(ByRef recordcollection As WinFreeReg.TranscriptionTables.MarriagesDataTable, ByVal rec As String())
      Dim recMarriage As TranscriptionTables.MarriagesRow
      recMarriage = recordcollection.NewMarriagesRow()
      With recMarriage
         .County = rec(0)
         .Place = rec(1)
         .Church = rec(2)
         .RegNo = rec(3)
         .MarriageDate = rec(4)
         .GroomForenames = rec(5)
         .GroomSurname = rec(6)
         .GroomAge = rec(7)
         .GroomParish = rec(8)
         .GroomCondition = rec(9)
         .GroomOccupation = rec(10)
         .GroomAbode = rec(11)
         .BrideForenames = rec(12)
         .BrideSurname = rec(13)
         .BrideAge = rec(14)
         .BrideParish = rec(15)
         .BrideCondition = rec(16)
         .BrideOccupation = rec(17)
         .BrideAbode = rec(18)
         .GroomFatherForenames = rec(19)
         .GroomFatherSurname = rec(20)
         .GroomFatherOccupation = rec(21)
         .BrideFatherForenames = rec(22)
         .BrideFatherSurname = rec(23)
         .BrideFatherOccupation = rec(24)
         .Witness1Forenames = rec(25)
         .Witness1Surname = rec(26)
         .Witness2Forenames = rec(27)
         .Witness2Surname = rec(28)
         .Notes = rec(29)
         If rec.Length >= 31 Then
            .LDSFiche = rec(30)
            .LDSImage = rec(31)
         End If
      End With
      recordcollection.Rows.Add(recMarriage)
   End Sub

   Public Sub Save()
      Dim DataLine As String
      Dim strFiche As String = "", strImage As String = ""
      Dim charComma As Char() = {","}
      Dim strChurchName As String = String.Format("{0} {1}", m_fileHeader.Church, m_fileHeader.RegisterType).TrimEnd()

      Using fs As New FileStream(Path.ChangeExtension(m_fullFilename, ".tmp"), FileMode.Create, FileAccess.Write, FileShare.None)
         Using sw As New StreamWriter(fs, m_Encoding)
            m_fileHeader.Save(sw, m_Encoding)
            Select Case m_fileHeader.FileType
               Case FileTypes.BAPTISMS
                  For Each recBaptism As TranscriptionTables.BaptismsRow In CType(m_recordcollection, TranscriptionTables.BaptismsDataTable).Rows
                     DataLine = ""
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.County)
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.Place)
                     DataLine = DataLine & "," & QuoteString(strChurchName)
                     If IsNothing(recBaptism.RegNo) Or IsDBNull(recBaptism.RegNo) Or String.IsNullOrEmpty(recBaptism.RegNo) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.RegNo)

                     If IsNothing(recBaptism.BirthDate) Or IsDBNull(recBaptism.BirthDate) Or String.IsNullOrEmpty(recBaptism.BirthDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.BirthDate)
                     If IsNothing(recBaptism.BaptismDate) Or IsDBNull(recBaptism.BaptismDate) Or String.IsNullOrEmpty(recBaptism.BaptismDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.BaptismDate)
                     If IsNothing(recBaptism.Forenames) Or IsDBNull(recBaptism.Forenames) Or String.IsNullOrEmpty(recBaptism.Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.Forenames)
                     If IsNothing(recBaptism.Sex) Or IsDBNull(recBaptism.Sex) Or String.IsNullOrEmpty(recBaptism.Sex) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.Sex)
                     If IsNothing(recBaptism.FathersName) Or IsDBNull(recBaptism.FathersName) Or String.IsNullOrEmpty(recBaptism.FathersName) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.FathersName)
                     If IsNothing(recBaptism.MothersName) Or IsDBNull(recBaptism.MothersName) Or String.IsNullOrEmpty(recBaptism.MothersName) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.MothersName)
                     If IsNothing(recBaptism.FathersSurname) Or IsDBNull(recBaptism.FathersSurname) Or String.IsNullOrEmpty(recBaptism.FathersSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.FathersSurname)
                     If IsNothing(recBaptism.MothersSurname) Or IsDBNull(recBaptism.MothersSurname) Or String.IsNullOrEmpty(recBaptism.MothersSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.MothersSurname)
                     If IsNothing(recBaptism.Abode) Or IsDBNull(recBaptism.Abode) Or String.IsNullOrEmpty(recBaptism.Abode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.Abode)
                     If IsNothing(recBaptism.FathersOccupation) Or IsDBNull(recBaptism.FathersOccupation) Or String.IsNullOrEmpty(recBaptism.FathersOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.FathersOccupation)

                     If IsNothing(recBaptism.Notes) Or IsDBNull(recBaptism.Notes) Or String.IsNullOrEmpty(recBaptism.Notes) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBaptism.Notes)

                     If m_fileHeader.isLDS Then
                        If IsDBNull(recBaptism.LDSFiche) OrElse recBaptism.LDSFiche Is Nothing Then
                           If strFiche <> "" Then DataLine = DataLine & "," & QuoteString(strFiche) Else DataLine = DataLine & ","
                        Else
                           DataLine = DataLine & "," & QuoteString(recBaptism.LDSFiche)
                           strFiche = recBaptism.LDSFiche
                        End If
                        If IsDBNull(recBaptism.LDSImage) OrElse recBaptism.LDSImage Is Nothing Then
                           If strImage <> "" Then DataLine = DataLine & "," & QuoteString(strImage) Else DataLine = DataLine & ","
                        Else
                           DataLine = String.Format("{0},{1}", DataLine, QuoteString(recBaptism.LDSImage))
                           strImage = recBaptism.LDSImage
                        End If
                     End If

                     DataLine = DataLine.TrimStart(charComma)
                     sw.WriteLine(DataLine)
                  Next

               Case FileTypes.BURIALS
                  For Each recBurial As TranscriptionTables.BurialsRow In CType(m_recordcollection, TranscriptionTables.BurialsDataTable).Rows
                     DataLine = ""
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.County)
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.Place)
                     DataLine = DataLine & "," & QuoteString(strChurchName)
                     If IsNothing(recBurial.RegNo) Or IsDBNull(recBurial.RegNo) Or String.IsNullOrEmpty(recBurial.RegNo) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.RegNo)

                     If IsNothing(recBurial.BurialDate) Or IsDBNull(recBurial.BurialDate) Or String.IsNullOrEmpty(recBurial.BurialDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.BurialDate)
                     If IsNothing(recBurial.Forenames) Or IsDBNull(recBurial.Forenames) Or String.IsNullOrEmpty(recBurial.Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Forenames)
                     If IsNothing(recBurial.Relationship) Or IsDBNull(recBurial.Relationship) Or String.IsNullOrEmpty(recBurial.Relationship) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Relationship)
                     If IsNothing(recBurial.MaleForenames) Or IsDBNull(recBurial.MaleForenames) Or String.IsNullOrEmpty(recBurial.MaleForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.MaleForenames)
                     If IsNothing(recBurial.FemaleForenames) Or IsDBNull(recBurial.FemaleForenames) Or String.IsNullOrEmpty(recBurial.FemaleForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.FemaleForenames)
                     If IsNothing(recBurial.RelativeSurname) Or IsDBNull(recBurial.RelativeSurname) Or String.IsNullOrEmpty(recBurial.RelativeSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.RelativeSurname)
                     If IsNothing(recBurial.Surname) Or IsDBNull(recBurial.Surname) Or String.IsNullOrEmpty(recBurial.Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Surname)
                     If IsNothing(recBurial.Age) Or IsDBNull(recBurial.Age) Or String.IsNullOrEmpty(recBurial.Age) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Age)
                     If IsNothing(recBurial.Abode) Or IsDBNull(recBurial.Abode) Or String.IsNullOrEmpty(recBurial.Abode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Abode)

                     If IsNothing(recBurial.Notes) Or IsDBNull(recBurial.Notes) Or String.IsNullOrEmpty(recBurial.Notes) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recBurial.Notes)

                     If m_fileHeader.isLDS Then
                        If IsDBNull(recBurial.LDSFiche) OrElse recBurial.LDSFiche Is Nothing Then
                           If strFiche <> "" Then DataLine = DataLine & "," & QuoteString(strFiche) Else DataLine = DataLine & ","
                        Else
                           DataLine = DataLine & "," & QuoteString(recBurial.LDSFiche)
                           strFiche = recBurial.LDSFiche
                        End If
                        If IsDBNull(recBurial.LDSImage) OrElse recBurial.LDSImage Is Nothing Then
                           If strImage <> "" Then DataLine = DataLine & "," & QuoteString(strImage) Else DataLine = DataLine & ","
                        Else
                           DataLine = String.Format("{0},{1}", DataLine, QuoteString(recBurial.LDSImage))
                           strImage = recBurial.LDSImage
                        End If
                     End If

                     DataLine = DataLine.TrimStart(charComma)
                     sw.WriteLine(DataLine)
                  Next

               Case FileTypes.MARRIAGES
                  For Each recMarriage As TranscriptionTables.MarriagesRow In CType(m_recordcollection, TranscriptionTables.MarriagesDataTable).Rows
                     DataLine = ""
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.County)
                     DataLine = DataLine & "," & QuoteString(m_fileHeader.Place)
                     DataLine = DataLine & "," & QuoteString(strChurchName)
                     If IsNothing(recMarriage.RegNo) Or IsDBNull(recMarriage.RegNo) Or String.IsNullOrEmpty(recMarriage.RegNo) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.RegNo)

                     If IsNothing(recMarriage.MarriageDate) Or IsDBNull(recMarriage.MarriageDate) Or String.IsNullOrEmpty(recMarriage.MarriageDate) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.MarriageDate)
                     If IsNothing(recMarriage.GroomForenames) Or IsDBNull(recMarriage.GroomForenames) Or String.IsNullOrEmpty(recMarriage.GroomForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomForenames)
                     If IsNothing(recMarriage.GroomSurname) Or IsDBNull(recMarriage.GroomSurname) Or String.IsNullOrEmpty(recMarriage.GroomSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomSurname)
                     If IsNothing(recMarriage.GroomAge) Or IsDBNull(recMarriage.GroomAge) Or String.IsNullOrEmpty(recMarriage.GroomAge) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomAge)
                     If IsNothing(recMarriage.GroomParish) Or IsDBNull(recMarriage.GroomParish) Or String.IsNullOrEmpty(recMarriage.GroomParish) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomParish)
                     If IsNothing(recMarriage.GroomCondition) Or IsDBNull(recMarriage.GroomCondition) Or String.IsNullOrEmpty(recMarriage.GroomCondition) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomCondition)
                     If IsNothing(recMarriage.GroomOccupation) Or IsDBNull(recMarriage.GroomOccupation) Or String.IsNullOrEmpty(recMarriage.GroomOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomOccupation)
                     If IsNothing(recMarriage.GroomAbode) Or IsDBNull(recMarriage.GroomAbode) Or String.IsNullOrEmpty(recMarriage.GroomAbode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomAbode)
                     If IsNothing(recMarriage.BrideForenames) Or IsDBNull(recMarriage.BrideForenames) Or String.IsNullOrEmpty(recMarriage.BrideForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideForenames)
                     If IsNothing(recMarriage.BrideSurname) Or IsDBNull(recMarriage.BrideSurname) Or String.IsNullOrEmpty(recMarriage.BrideSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideSurname)
                     If IsNothing(recMarriage.BrideAge) Or IsDBNull(recMarriage.BrideAge) Or String.IsNullOrEmpty(recMarriage.BrideAge) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideAge)
                     If IsNothing(recMarriage.BrideParish) Or IsDBNull(recMarriage.BrideParish) Or String.IsNullOrEmpty(recMarriage.BrideParish) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideParish)
                     If IsNothing(recMarriage.BrideCondition) Or IsDBNull(recMarriage.BrideCondition) Or String.IsNullOrEmpty(recMarriage.BrideCondition) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideCondition)
                     If IsNothing(recMarriage.BrideOccupation) Or IsDBNull(recMarriage.BrideOccupation) Or String.IsNullOrEmpty(recMarriage.BrideOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideOccupation)
                     If IsNothing(recMarriage.BrideAbode) Or IsDBNull(recMarriage.BrideAbode) Or String.IsNullOrEmpty(recMarriage.BrideAbode) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideAbode)
                     If IsNothing(recMarriage.GroomFatherForenames) Or IsDBNull(recMarriage.GroomFatherForenames) Or String.IsNullOrEmpty(recMarriage.GroomFatherForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomFatherForenames)
                     If IsNothing(recMarriage.GroomFatherSurname) Or IsDBNull(recMarriage.GroomFatherSurname) Or String.IsNullOrEmpty(recMarriage.GroomFatherSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomFatherSurname)
                     If IsNothing(recMarriage.GroomFatherOccupation) Or IsDBNull(recMarriage.GroomFatherOccupation) Or String.IsNullOrEmpty(recMarriage.GroomFatherOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.GroomFatherOccupation)
                     If IsNothing(recMarriage.BrideFatherForenames) Or IsDBNull(recMarriage.BrideFatherForenames) Or String.IsNullOrEmpty(recMarriage.BrideFatherForenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideFatherForenames)
                     If IsNothing(recMarriage.BrideFatherSurname) Or IsDBNull(recMarriage.BrideFatherSurname) Or String.IsNullOrEmpty(recMarriage.BrideFatherSurname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideFatherSurname)
                     If IsNothing(recMarriage.BrideFatherOccupation) Or IsDBNull(recMarriage.BrideFatherOccupation) Or String.IsNullOrEmpty(recMarriage.BrideFatherOccupation) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.BrideFatherOccupation)
                     If IsNothing(recMarriage.Witness1Forenames) Or IsDBNull(recMarriage.Witness1Forenames) Or String.IsNullOrEmpty(recMarriage.Witness1Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.Witness1Forenames)
                     If IsNothing(recMarriage.Witness1Surname) Or IsDBNull(recMarriage.Witness1Surname) Or String.IsNullOrEmpty(recMarriage.Witness1Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.Witness1Surname)
                     If IsNothing(recMarriage.Witness2Forenames) Or IsDBNull(recMarriage.Witness2Forenames) Or String.IsNullOrEmpty(recMarriage.Witness2Forenames) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.Witness2Forenames)
                     If IsNothing(recMarriage.Witness2Surname) Or IsDBNull(recMarriage.Witness2Surname) Or String.IsNullOrEmpty(recMarriage.Witness2Surname) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.Witness2Surname)

                     If IsNothing(recMarriage.Notes) Or IsDBNull(recMarriage.Notes) Or String.IsNullOrEmpty(recMarriage.Notes) Then DataLine = DataLine & "," Else DataLine = DataLine & "," & QuoteString(recMarriage.Notes)

                     If m_fileHeader.isLDS Then
                        If IsDBNull(recMarriage.LDSFiche) OrElse recMarriage.LDSFiche Is Nothing Then
                           If strFiche <> "" Then DataLine = DataLine & "," & QuoteString(strFiche) Else DataLine = DataLine & ","
                        Else
                           DataLine = DataLine & "," & QuoteString(recMarriage.LDSFiche)
                           strFiche = recMarriage.LDSFiche
                        End If
                        If IsDBNull(recMarriage.LDSImage) OrElse recMarriage.LDSImage Is Nothing Then
                           If strImage <> "" Then DataLine = DataLine & "," & QuoteString(strImage) Else DataLine = DataLine & ","
                        Else
                           DataLine = String.Format("{0},{1}", DataLine, QuoteString(recMarriage.LDSImage))
                           strImage = recMarriage.LDSImage
                        End If
                     End If

                     DataLine = DataLine.TrimStart(charComma)
                     sw.WriteLine(DataLine)
                  Next

            End Select
         End Using
      End Using

      If File.Exists(Path.ChangeExtension(m_fullFilename, "ERR")) Then File.Delete(Path.ChangeExtension(m_fullFilename, "ERR"))
      File.Delete(m_fullFilename)
      My.Computer.FileSystem.RenameFile(Path.ChangeExtension(m_fullFilename, ".tmp"), Path.GetFileName(m_fullFilename))

   End Sub

   'Public Function DecodeBaptismSex(ByVal Description As String) As String
   '	Dim dt As LookupTables.BaptismSexDataTable = m_Lookups.BaptismSex
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.BaptismSexRow) row.Description = Description)
   '	Return x(0).Code
   'End Function

   'Public Function DecodeBurialRelationship(ByVal Description As String) As String
   '	Dim dt As LookupTables.BurialRelationshipDataTable = m_Lookups.BurialRelationship
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.BurialRelationshipRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

   'Public Function DecodeBrideCondition(ByVal Description As String) As String
   '	Dim dt As LookupTables.BrideConditionDataTable = m_Lookups.BrideCondition
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.BrideConditionRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

   'Public Function DecodeGroomCondition(ByVal Description As String) As String
   '	Dim dt As LookupTables.GroomConditionDataTable = m_Lookups.GroomCondition
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.GroomConditionRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

   Public Shared Function QuoteString(ByVal str As String) As String
      Dim ch1 As Char = """", ch2 As String = """"
      Dim NewString As String

      If str.IndexOf(ch1) = 0 Then
         NewString = str.Trim(ch2.ToCharArray())
      Else
         NewString = str
      End If

      If NewString.Contains("{") Then
         NewString = NewString.Replace("{", "{{")
      End If

      If NewString.Contains("}") Then
         NewString = NewString.Replace("}", "}}")
      End If

      If NewString.Contains(",") Or NewString.Contains("""") Then
         If NewString.Contains("""") Then
            NewString = NewString.Replace(ch1, Chr(34) & Chr(34))
         End If

         If Not (NewString.IndexOf(ch1) = 0 And NewString.LastIndexOf(ch1) = NewString.Length - 1) Then
            NewString = String.Format("""{0}""", NewString)
         End If
      End If
      Return NewString
   End Function

   Public Class FileHeaderClass

		Private m_myReader As TextFieldParser
      Public Property MyReader() As TextFieldParser
         Get
            Return m_myReader
         End Get
         Set(ByVal value As TextFieldParser)
            m_myReader = value
         End Set
      End Property

      Private m_fileType As FileTypes
      Public Property FileType() As FileTypes
         Get
            Return m_fileType
         End Get
         Set(ByVal value As FileTypes)
            m_fileType = value
         End Set
      End Property

      Private m_dateCreated As DateTime
      Public Property DateCreated() As DateTime
         Get
            Return m_dateCreated
         End Get
         Set(ByVal value As DateTime)
            m_dateCreated = value
         End Set
      End Property

      Private m_dateLastChanged As DateTime
      Public Property DateLastChanged() As DateTime
         Get
            Return m_dateLastChanged
         End Get
         Set(ByVal value As DateTime)
            m_dateLastChanged = value
         End Set
      End Property

      Private m_creditName As String
      Public Property CreditName() As String
         Get
            Return m_creditName
         End Get
         Set(ByVal value As String)
            m_creditName = value
         End Set
      End Property

      Private m_creditEmail As String
      Public Property CreditEmail() As String
         Get
            Return m_creditEmail
         End Get
         Set(ByVal value As String)
            m_creditEmail = value
         End Set
      End Property

      Private m_comment1 As String
      Public Property Comment1() As String
         Get
            Return m_comment1
         End Get
         Set(ByVal value As String)
            m_comment1 = value
         End Set
      End Property

      Private m_comment2 As String
      Public Property Comment2() As String
         Get
            Return m_comment2
         End Get
         Set(ByVal value As String)
            m_comment2 = value
         End Set
      End Property

      Private m_myEmail As String
      Public Property MyEmail() As String
         Get
            Return m_myEmail
         End Get
         Set(ByVal value As String)
            m_myEmail = value
         End Set
      End Property

      Private m_myName As String
      Public Property MyName() As String
         Get
            Return m_myName
         End Get
         Set(ByVal value As String)
            m_myName = value
         End Set
      End Property

      Private m_myPassword As String
      Public Property MyPassword() As String
         Get
            Return m_myPassword
         End Get
         Set(ByVal value As String)
            m_myPassword = value
         End Set
      End Property

      Private m_mySyndicate As String
      Public Property MySyndicate() As String
         Get
            Return m_mySyndicate
         End Get
         Set(ByVal value As String)
            m_mySyndicate = value
         End Set
      End Property

      Private m_internalFilename As String
      Public Property InternalFilename() As String
         Get
            Return m_internalFilename
         End Get
         Set(ByVal value As String)
            m_internalFilename = value
         End Set
      End Property

      Private m_VersionUsed As String
      Public Property VersionUsed() As String
         Get
            Return m_VersionUsed
         End Get
         Set(ByVal value As String)
            m_VersionUsed = value
         End Set
      End Property

      Private m_county As String
      Public Property County() As String
         Get
            Return m_county
         End Get
         Set(ByVal value As String)
            m_county = value
         End Set
      End Property

      Private m_place As String
      Public Property Place() As String
         Get
            Return m_place
         End Get
         Set(ByVal value As String)
            m_place = value
         End Set
      End Property

      Private m_church As String
      Public Property Church() As String
         Get
            Return m_church
         End Get
         Set(ByVal value As String)
            m_church = value
         End Set
      End Property

      Private m_regType As String
      Public Property RegisterType() As String
         Get
            Return m_regType
         End Get
         Set(ByVal value As String)
            m_regType = value
         End Set
      End Property

      Private m_isLDS As Boolean
      Public Property isLDS() As Boolean
         Get
            Return m_isLDS
         End Get
         Set(value As Boolean)
            m_isLDS = value
         End Set
      End Property

      Private _hdrLine1 As String()
      Private _hdrLine2 As String()
      Private _hdrLine3 As String()
      Private _hdrLine4 As String()
      Private _hdrLine5 As String()

      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(ByVal _file As TextFieldParser)
         MyBase.New()
         m_myReader = _file
		End Sub

      Public Function GetHeader() As String()
         Dim FirstDataRecord() = New String() {""}
         Try
            ' +INFO,<email>,<password>,SEQUENCED,<filetype>,<charset>,<WinREG version>
				_hdrLine1 = m_myReader.ReadFields()
				If _hdrLine1(0) = "+INFO" Then
					m_fileType = [Enum].Parse(GetType(FileTypes), _hdrLine1(4), True)
					m_myEmail = _hdrLine1(1)
					m_myPassword = _hdrLine1(2)
					If _hdrLine1.Length >= 5 Then
						If _hdrLine1.Length > 6 Then
							m_VersionUsed = _hdrLine1(6)
						End If
					End If
				Else
				End If

				' #,CCC,<name>,<syndicate>,<internal name>,<date created>
				_hdrLine2 = m_myReader.ReadFields()
				If _hdrLine2(0) = "#" AndAlso _hdrLine2(1) = "CCC" Then
					If _hdrLine2.Length >= 3 Then
						m_myName = _hdrLine2(2)
						If _hdrLine2.Length >= 4 Then
							m_mySyndicate = _hdrLine2(3)
							If _hdrLine2.Length >= 5 Then
								m_internalFilename = _hdrLine2(4)
								If _hdrLine2.Length >= 6 Then
									m_dateCreated = [DateTime].Parse(_hdrLine2(5))
								Else
									m_dateCreated = Date.Now()
								End If
							Else
								m_internalFilename = String.Empty
								m_dateCreated = Date.Now()
							End If
						Else
							m_mySyndicate = String.Empty
							m_internalFilename = String.Empty
							m_dateCreated = Date.Now()
						End If
					Else
						m_mySyndicate = String.Empty
						m_internalFilename = String.Empty
						m_dateCreated = Date.Now()
						m_myName = String.Empty
					End If
				Else
				End If

				' #,CREDIT,<credit name>,<credit email>
				_hdrLine3 = m_myReader.ReadFields()
				If _hdrLine3(0) = "#" AndAlso _hdrLine3(1) = "CREDIT" Then
					If _hdrLine3.Length >= 3 Then
						m_creditName = _hdrLine3(2)
						If _hdrLine3.Length >= 4 Then
							m_creditEmail = _hdrLine3(3)
						Else
							m_creditEmail = String.Empty
						End If
					Else
						m_creditName = String.Empty
						m_creditEmail = String.Empty
					End If
				Else
				End If

				' #,<date changed>,<comment 1>,<comment 2>
				_hdrLine4 = m_myReader.ReadFields()
				If _hdrLine4(0) = "#" Then
					If _hdrLine4.Length >= 2 Then
						Dim f = [DateTime].TryParse(_hdrLine4(1), m_dateLastChanged)
						If _hdrLine4.Length >= 3 Then
							m_comment1 = _hdrLine4(2)
							If _hdrLine4.Length >= 4 Then
								m_comment2 = _hdrLine4(3)
							Else
								m_comment2 = String.Empty
							End If
						Else
							m_comment2 = String.Empty
							m_comment1 = String.Empty
						End If
					Else
						m_comment2 = String.Empty
						m_comment1 = String.Empty
						m_dateLastChanged = Date.Now()
					End If
				Else
				End If

				' +LDS
				_hdrLine5 = m_myReader.ReadFields()
				If _hdrLine5(0) = "+LDS" Then
					m_isLDS = True
					FirstDataRecord = m_myReader.ReadFields()
				Else
					m_isLDS = False
					FirstDataRecord = _hdrLine5
					_hdrLine5 = Nothing
				End If

				m_county = FirstDataRecord(0)
				m_place = FirstDataRecord(1)
				m_church = FirstDataRecord(2)
				m_regType = ""

			Catch ex As MalformedLineException
				Throw
				MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
			End Try

         Return FirstDataRecord
      End Function

      Public Sub Save(ByVal sw As StreamWriter, ByVal encoding As Encoding)
         Dim Line1, Line2, Line3, Line4 As String
         DateLastChanged = Format(Now(), "dd-MMM-yyyy")
         Dim fv As String = String.Format(",{0}.{1:00}.{2:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)

         Dim cp As String
         Select Case encoding.CodePage
            Case 437
               cp = ",cp437"
            Case 850
               cp = ",cp850"
            Case Else
               cp = ","
         End Select

         Line1 = "+INFO," & QuoteString(Me.m_myEmail) & "," & QuoteString(Me.m_myPassword) & ",SEQUENCED," & QuoteString([Enum].GetName(GetType(FileTypes), Me.m_fileType)) & cp & fv
         _hdrLine1 = {"+INFO", QuoteString(Me.m_myEmail), QuoteString(Me.m_myPassword), "SEQUENCED", QuoteString([Enum].GetName(GetType(FileTypes), Me.m_fileType)), cp.Trim({","c}), fv.Trim({","c})}
         Line2 = "#,CCC," & QuoteString(Me.m_myName) & "," & QuoteString(Me.m_mySyndicate) & "," & QuoteString(Me.m_internalFilename) & "," & Me.m_dateCreated
         _hdrLine2 = {"#", "CCC", QuoteString(Me.m_myName), QuoteString(Me.m_mySyndicate), QuoteString(Me.m_internalFilename), Me.m_dateCreated}
         Line3 = "#,CREDIT," & QuoteString(Me.m_creditName) & "," & QuoteString(Me.m_creditEmail)
         _hdrLine3 = {"#", "CREDIT", QuoteString(Me.m_creditName), QuoteString(Me.m_creditEmail)}
         Line4 = "#," & Me.DateLastChanged & "," & QuoteString(Me.Comment1) & "," & QuoteString(Me.Comment2)
         _hdrLine4 = {"#", Me.DateLastChanged, QuoteString(Me.Comment1), QuoteString(Me.Comment2)}

         sw.WriteLine(Line1)
         sw.WriteLine(Line2)
         sw.WriteLine(Line3)
         sw.WriteLine(Line4)

         If isLDS Then
            sw.WriteLine("+LDS")
            _hdrLine1(5) = "+LDS"
         End If
      End Sub

   End Class

End Class
