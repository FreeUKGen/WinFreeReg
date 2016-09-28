'	$Date: 2015-07-27 11:52:33 +0200 (Mon, 27 Jul 2015) $
'	$Rev: 492 $
'	$Id: TranscriptionValidations.vb 492 2015-07-27 09:52:33Z Mikefry $
'
'	WinREG/3 - Version 3.2.18
'

Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Text

Public NotInheritable Class TranscriptionValidations
	Public Const ERR0001 As String = "1"
	Public Const ERR0002 As String = "2"
	Public Const ERR0003 As String = "3"
	Public Const ERR0004 As String = "4"
	Public Const ERR0005 As String = "5"
	Public Const ERR0006 As String = "6"
	Public Const ERR0007 As String = "7"
	Public Const ERR0008 As String = "8"
	Public Const ERR0009 As String = "9"
	Public Const ERR0010 As String = "10"
	Public Const ERR0011 As String = "11"
	Public Const ERR0012 As String = "12"
	Public Const ERR0013 As String = "13"
	Public Const ERR0014 As String = "14"
	Public Const ERR0015 As String = "15"
	Public Const ERR0016 As String = "16"
	Public Const ERR0017 As String = "17"
	Public Const ERR0018 As String = "18"
	Public Const ERR0019 As String = "19"
	Public Const ERR0020 As String = "20"
	Public Const ERR0021 As String = "21"
	Public Const ERR0022 As String = "22"
	Public Const ERR0023 As String = "23"
	Public Const ERR0024 As String = "24"
	Public Const ERR0025 As String = "25"
	Public Const ERR0026 As String = "26"
	Public Const ERR0027 As String = "27"
	Public Const ERR0028 As String = "28"
	Public Const ERR0029 As String = "29"
	Public Const ERR0030 As String = "30"
	Public Const ERR0031 As String = "31"
	Public Const ERR0032 As String = "32"
	Public Const ERR0033 As String = "33"
	Public Const ERR0034 As String = "34"
	Public Const ERR0035 As String = "35"
	Public Const ERR0036 As String = "36"
	Public Const ERR0037 As String = "37"
	Public Const ERR0038 As String = "38"
	Public Const ERR0039 As String = "39"
	Public Const ERR0040 As String = "40"
	Public Const ERR0041 As String = "41"
	Public Const ERR0042 As String = "42"
	Public Const ERR0043 As String = "43"
	Public Const ERR0044 As String = "44"
	Public Const ERR0045 As String = "45"
	Public Const ERR0046 As String = "46"
	Public Const ERR0047 As String = "47"
	Public Const ERR0048 As String = "48"
	Public Const ERR0049 As String = "49"
	Public Const ERR0050 As String = "50"
	Public Const ERR0051 As String = "51"
	Public Const ERR0052 As String = "52"
	Public Const ERR0053 As String = "53"
	Public Const ERR0054 As String = "54"
	Public Const ERR0055 As String = "55"
	Public Const ERR0056 As String = "56"
	Public Const ERR0057 As String = "57"
	Public Const ERR0058 As String = "58"
	Public Const ERR0059 As String = "59"
	Public Const ERR0060 As String = "60"
	Public Const ERR0061 As String = "61"
	Public Const ERR0062 As String = "62"
	Public Const INF0001 As String = "1001"
	Public Const INF0002 As String = "1002"
	Public Const INF0003 As String = "1003"
	Public Const INF0004 As String = "1004"
	Public Const INF0005 As String = "1005"
	Public Const INF0006 As String = "1006"
	Public Const INF0007 As String = "1007"
	Public Const INF0008 As String = "1008"
	Public Const INF0009 As String = "1009"
	Public Const INF0010 As String = "1010"
	Public Const INF0011 As String = "1011"
	Public Const INF0012 As String = "1012"
	Public Const MSG0001 As String = "2001"
	Public Const MSG0002 As String = "2002"
	Public Const MSG0003 As String = "2003"
	Public Const MSG0004 As String = "2004"
	Public Const MSG0005 As String = "2005"
	Public Const MSG0006 As String = "2006"
	Public Const MSG0007 As String = "2007"
	Public Const MSG0008 As String = "2008"
	Public Const MSG0009 As String = "2009"
	Public Const MSG0010 As String = "2010"
	Public Const MSG0011 As String = "2011"
	Public Const MSG0012 As String = "2012"

	Private Sub New()
	End Sub

	Public Shared Function ValidateDate(ByRef strToValidate As String, ByRef strErrMessage As String, ByRef strBits As String(), ByVal MyLeadingZeroOnDates As Boolean, ByVal MyAddErrorNumberToMessage As Boolean) As Boolean
		Dim e As Boolean

		strErrMessage = ""

		If strToValidate = "" Then											' Empty dates are valid
			e = True
			Return True
		ElseIf strToValidate = "*" Then									' .. so is a single *
			e = True
			Return True
		End If

		' Validate the format of a Date using a Regular Expression
		'
		Dim m As Match

		Dim r1 = New freereg.regex.rgxValidateDate
		m = r1.Match(strToValidate)
		'		m = rgxValidateDate.Match(strToValidate)
		If m.Success = False Then											' Badly formed dates are rejected
			Dim r2 = New freereg.regex.rgxValidateDoubleDate
			m = r2.Match(strToValidate)
			'			m = rgxValidateDoubleDate.Match(strToValidate)
			If m.Success = False Then										' Badly formed dates are rejected
				strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0011:{0}", My.Resources.err0011), My.Resources.err0011)
				e = False
				Return False
			End If
		End If

		' At this point, it would seem that the entered date is at least in an acceptable format
		'
		' What we have to do now is check that each component of the date is valid and that the
		' components are, when taken together, valid.
		'
		Dim dd As String, mmm As String, yy As String, zz As String, sep1 As String, sep2 As String, strToReplace As String
		Const delim As String = "- /."
		Dim fValidDoubleYear As Boolean = False, fValidYear As Boolean = False, fValidMonth As Boolean = False, fValidDay As Boolean = False

		dd = m.Groups.Item("days").Value().Trim()
		sep1 = m.Groups.Item("sep1").Value().Trim()
		mmm = m.Groups.Item("month").Value().Trim(delim.ToCharArray())
		sep2 = m.Groups.Item("sep2").Value().Trim()
		yy = m.Groups.Item("year").Value().Trim()
		zz = m.Groups.Item("newyear").Value().Trim()
		e = True																		' At this point, the date appears to be valid

		' If separators are used, they should be consistent
		'
		If sep1 IsNot Nothing AndAlso sep2 IsNot Nothing Then
			If sep1 <> sep2 Then
				strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0039:{0}", My.Resources.err0039), My.Resources.err0039)
				e = False
				Return False
			End If
		End If

		' If the date contains UCF characters, can we really validate it properly?
		' Obviously, if a component is encoded as a single *, then possibly. If it contains
		' an _, then we're talking about a single, unreadable character - digit in the case
		' of the day or year, but alphbetic or digit in the case of the month.
		'

		strBits(1) = dd
		strBits(2) = mmm
		strBits(3) = yy
		strBits(4) = zz

		' Validate the month component and convert it to the common Mmm format
		'
		If mmm <> "" Then
			If mmm <> "*" Then													' Month can be * in which case it's valid
				fValidMonth = True
				Dim dnum As Integer
				If Int32.TryParse(mmm, dnum) Then
					Select Case dnum
						Case 1
							mmm = "Jan"
						Case 2
							mmm = "Feb"
						Case 3
							mmm = "Mar"
						Case 4
							mmm = "Apr"
						Case 5
							mmm = "May"
						Case 6
							mmm = "Jun"
						Case 7
							mmm = "Jul"
						Case 8
							mmm = "Aug"
						Case 9
							mmm = "Sep"
						Case 10
							mmm = "Oct"
						Case 11
							mmm = "Nov"
						Case 12
							mmm = "Dec"
						Case Else
							strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0013:{0}", My.Resources.err0013), My.Resources.err0013)
							e = False												' Just in case!
					End Select
				Else
					If mmm = "" Then
						strToReplace = ""
					Else
						If mmm.Length < 3 Then
							strErrMessage = My.Resources.err0014
							e = False												' Just in case!
						End If

						strToReplace = UCase(Microsoft.VisualBasic.Left(mmm, 1)) & LCase(Microsoft.VisualBasic.Mid(mmm, 2, 2))
					End If
					mmm = strToReplace
				End If
				strBits(2) = mmm
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Validate the dd component
		'
		If dd <> "" Then
			If dd <> "*" Then														' Days can be *, in which case don't do this
				If dd.Contains("_") = False Then
					If dd.EndsWith("st", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("nd", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("rd", StringComparison.CurrentCultureIgnoreCase) OrElse dd.EndsWith("th", StringComparison.CurrentCultureIgnoreCase) Then
						dd = dd.TrimEnd("s"c, "S"c, "t"c, "T"c, "n"c, "N"c, "d"c, "D"c, "r"c, "R"c, "h"c, "H"c)
						strBits(1) = dd
					End If

					Dim dnum As Integer
					If Integer.TryParse(dd, NumberStyles.Integer, Nothing, dnum) Then

						fValidDay = True
						If mmm = "Sep" And yy = "1752" And (CInt(dd) >= 3 And CInt(dd) <= 13) Then
							strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0015:{0}", My.Resources.err0015), My.Resources.err0015)
							e = False												' The 'missing' 11 days from 1752 are invalid
						End If
					Else
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", "day should be numeric"), "day should be numeric")
						e = False
					End If
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Validate the year component
		'
		Dim yyi As Integer
		If yy <> "" Then
			If yy <> "*" Then
				If yy.Contains("_") = False Then
					fValidYear = True
					If Not Int16.TryParse(yy, yyi) Then
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0022:{0}", My.Resources.err0022), My.Resources.err0022)
						e = False
					End If
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Validate the double year component
		'
		Dim zzi As Integer
		If zz <> "" Then
			If zz <> "*" Then
				If zz.Contains("_") = False Then
					fValidDoubleYear = True
					If Not Int16.TryParse(zz, zzi) Then
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0022:{0}", My.Resources.err0022), My.Resources.err0022)
						e = False
					End If
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		' Post 1751 split year validation
		'
		If fValidYear Then
			If yyi > 1751 Then
				If zz <> "" Then
					strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0025:{0}", My.Resources.err0025), My.Resources.err0025)
					e = False
				End If
				If Not e Then Return False ' Date was invalid
				GoTo LYr
			End If
		End If

		' Pre-1752 split year validation
		'
      If fValidYear AndAlso fValidMonth Then
         If zz <> "*" And zz <> "" Then
            If zz.Contains("_") = False Then
               If mmm <> "Jan" And mmm <> "Feb" And mmm <> "Mar" And mmm <> "" And mmm <> "*" Then
                  strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0016:{0}", My.Resources.err0016), My.Resources.err0016)
                  e = False
               Else
                  If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
                     Dim ddd As Integer
                     If Int16.TryParse(dd, ddd) Then
                        If ddd >= 25 And mmm = "Mar" Then
                           strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0017:{0}", My.Resources.err0017), My.Resources.err0017)
                           e = False
                        Else
                           If zzi <= 99 Then
                              If (yyi Mod 100) = 99 Then ' End of century - split must be "00"
                                 If zz <> "00" Then
                                    strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0018:{0}", My.Resources.err0018), My.Resources.err0018)
                                    e = False
                                 End If
                              Else
                                 Dim yyj As Integer = (yyi + 1) Mod 100
                                 If yyj <> zzi Then
                                    If zzi <> yyj Mod 10 Then
                                       strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0019:{0}", My.Resources.err0019), My.Resources.err0019)
                                       e = False
                                    End If
                                 End If
                                 If e Then zz = yyj.ToString()
                              End If
                           Else                          ' Split-year can't be more than 99
                              strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0020:{0}", My.Resources.err0020), My.Resources.err0020)
                              e = False
                           End If
                        End If
                     Else
                        strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0021:{0}", My.Resources.err0021), My.Resources.err0021)
                        e = False
                     End If
                  Else
                     If zzi <= 99 Then
                        If (yyi Mod 100) = 99 Then ' End of century - split must be "00"
                           If zz <> "00" Then
                              strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0018:{0}", My.Resources.err0018), My.Resources.err0018)
                              e = False
                           End If
                        Else
                           Dim yyj As Integer = (yyi + 1) Mod 100

                           If yyj <> zzi Then
                              If zzi <> yyj Mod 10 Then
                                 strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0019:{0}", My.Resources.err0019), My.Resources.err0019)
                                 e = False
                              End If
                           End If
                           If e Then zz = yyj.ToString()
                        End If
                     Else                          ' Split-year can't be more than 99
                        strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0020:{0}", My.Resources.err0020), My.Resources.err0020)
                        e = False
                     End If
                  End If
               End If
            End If
         Else                                ' zz="" - Should be a split-year in this case
            If mmm = "Jan" Or mmm = "Feb" Then
               strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0023:{0}", My.Resources.err0023), My.Resources.err0023)
               e = False
            Else
               If mmm = "Mar" Then
                  If Not String.IsNullOrEmpty(dd) Then
                     If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
                        Try
                           If CInt(dd) <= 24 Then
                              strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0023:{0}", My.Resources.err0023), My.Resources.err0023)
                              e = False
                           End If
                        Catch ex As Exception
                           strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0024:{0}", My.Resources.err0024), My.Resources.err0024)
                           e = False
                        End Try
                     End If
                  End If
               End If
            End If
         End If
      End If
		If Not e Then Return False ' Date was invalid

		' Special check for leap years
		'
LYr:  If mmm = "Feb" And dd = "29" Then
			yyi = Convert.ToInt16(yy)

			If yyi < 1752 Then yyi += 1 ' The double-year is the crucial one!
			Dim century As Integer = yyi \ 100, year As Integer = yyi Mod 100

			If year <> 0 Then
				If (year Mod 4) <> 0 Then
					strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0026:{0}", My.Resources.err0026), My.Resources.err0026)
					e = False
				End If
			Else
				If (century Mod 4) <> 0 Then								' Only 1600 and 2000 are leap years. 17/18/1900 are not.
					strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0027:{0}", My.Resources.err0027), My.Resources.err0027)
					e = False
				End If
			End If
		End If
		If Not e Then Return False ' Date was invalid

		If MyLeadingZeroOnDates Then
			If dd <> "*" And dd <> "" And dd.Contains("_") = False Then
				Dim dnum As Integer = Convert.ToInt32(dd)					' Convert a numeric day to the required dd format
				strToReplace = String.Format("{0:00} {1} {2}", dnum, mmm, yy)						' Construct a correctly formatted and punctuated date string
			Else
				If dd <> "" Then
					strToReplace = String.Format("{0} {1} {2}", dd, mmm, yy)			' Construct a correctly formatted and punctuated date string
				ElseIf mmm <> "" Then
					strToReplace = String.Format("{0} {1}", mmm, yy)							' Construct a correctly formatted and punctuated date string
				Else
					strToReplace = yy											' Construct a correctly formatted and punctuated date string
				End If
			End If
		Else
			strToReplace = String.Format("{0} {1} {2}", dd, mmm, yy)					' Construct a correctly formatted and punctuated date string
		End If

		If Not zz = "" Then
			strToReplace = String.Format("{0}/{1}", strToReplace, zz)
		End If

		strBits(1) = dd
		strBits(2) = mmm
		strBits(3) = yy
		strBits(4) = zz

		strToValidate = strToReplace
		Return True
	End Function

	Public Shared Function ValidateBirthAndBaptismDates(ByVal strBirth As String, ByVal strBaptism As String, ByVal MyAddErrorNumberToMessage As Boolean) As Boolean
		If strBirth <> String.Empty AndAlso strBaptism <> String.Empty Then

			' TODO: This check fails when either date is double-dated, because DateTime doen't understand the date format
			'
			Try
				Dim dateBirth, dateBaptism As DateTime
				Dim fBirth, fBaptism As Boolean

				fBirth = DateTime.TryParse(strBirth, dateBirth)
				fBaptism = DateTime.TryParse(strBaptism, dateBaptism)
				If fBirth AndAlso fBaptism Then
					If dateBirth > dateBaptism Then
						Return False
					End If
				Else
				End If

			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, "Exception whilst Checking Birth and Baptism dates")
				Return False
			End Try
		End If
		Return True
	End Function

	Public Shared Function ValidateBurialAge(ByRef strToValidate As String, ByRef strErrMessage As String, ByVal inValidation As Boolean, ByVal MyAddErrorNumberToMessage As Boolean) As Boolean
		Dim e As Boolean = False

		strErrMessage = String.Empty
		If strToValidate = String.Empty OrElse strToValidate = "*" Then Return True

		If String.Compare(strToValidate, "infant", True) = 0 OrElse String.Compare(strToValidate, "child", True) = 0 Then Return True

		Dim s As ULong
		If UInt32.TryParse(strToValidate, s) Then
			If s > 99 Then
				If Not inValidation Then
					If MessageBox.Show(My.Resources.msgOldperson, "Burial Age", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, "MessageBoxes.chm", HelpNavigator.TopicId, ERR0041) = Windows.Forms.DialogResult.Yes Then
						Return True
					Else
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0041:{0}", My.Resources.err0041), My.Resources.err0041)
						Return False
					End If
				Else
					strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0041:{0}", My.Resources.err0041), My.Resources.err0041)
					Return False
				End If
			End If
			Return True
		End If

		' Now we need to look for 1 or 2 digit numbers followed by one of the age 'units'
		' There could be multiple units of y-years, m-months, w-weeks, d-days in any order
		' But there should not be any duplicate units
		'
		Dim t As String = strToValidate						' Temporary copy of the data string
		Dim ca As Char() = t.ToCharArray
		Dim i As Integer = 0
		t = ""
		For Each c As Char In ca								' replace any units with digits
			If c = "y"c Or c = "Y"c Then
				ca(i) = "0"c
			ElseIf c = "m"c Or c = "M"c Then
				ca(i) = "0"c
			ElseIf c = "w"c Or c = "W"c Then
				ca(i) = "0"c
			ElseIf c = "d"c Or c = "D"c Then
				ca(i) = "0"c
			ElseIf c = "h"c Or c = "H"c Then
				ca(i) = "0"c
			ElseIf c = "_"c Or c = "¼"c Or c = "½"c Or c = "¾"c Then
				ca(i) = "0"c
			End If

			t = t + ca(i)
			i += 1
		Next

		If UInt64.TryParse(t, s) Then
			e = True
		Else
			e = False												' otherwise, the string is invalid
			strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0004:{0}", My.Resources.err0004), My.Resources.err0004)
		End If

		Return e
	End Function

	Public Shared Function ValidateMarriageAge(ByRef strToValidate As String, ByRef strErrMessage As String, ByVal type As String, ByVal inValidation As Boolean, ByVal MyAddErrorNumberToMessage As Boolean) As Boolean
		strErrMessage = ""
		If strToValidate = "" OrElse strToValidate = "*" Then Return True
		If String.Compare(strToValidate, "minor", True) = 0 Then Return True

		If String.Compare(strToValidate, "of full age", True) = 0 OrElse String.Compare(strToValidate, "of age", True) = 0 OrElse String.Compare(strToValidate, "full age", True) = 0 Then
			strToValidate = "full age"
			Return True
		End If

		If String.Compare(strToValidate, "over 21", True) = 0 Then
			strToValidate = "over 21"
			Return True
		End If

		'	Use a Regular Expression to carry out basic validation of the Marriage Ages
		'
		Dim rgx As New Regex(My.Resources.rgxMarriageAge1, RegexOptions.Compiled Or RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
		Dim m As Match = rgx.Match(strToValidate)

		'	If the Match succeeds then at least one of the possible groups has been matched and we should have a valid Age
		'
		If m.Success Then
			If m.Groups("years").Success Then						' We've got a plain number of years
				Dim yrs As Int16 = 0
				If Int16.TryParse(m.Groups("years").Value, yrs) Then
					If yrs < 16 Then
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Warning: Is the {0} really aged under 16?", type)), String.Format("Warning: Is the {0} really aged under 16?", type))
						Return False
					ElseIf yrs >= 100 Then
						strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Warning: Is the {0} really getting married aged 100 or over?", type)), String.Format("Warning: Is the {0} really getting married aged 100 or over?", type))
						Return False
					End If
				Else
					strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Age of the {0} should generally be numeric", type)), String.Format("Age of the {0} should generally be numeric", type))
					Return False											' Shouldn't happen with the RegEx in use :-)
				End If
				Return True													' - don't want any other groups

			ElseIf m.Groups("vulgar").Success Then					' Now we have a number of years with an extra added vulgar fraction character ¼ or ½ or ¾
				Return True													' - don't want any other groups

			ElseIf m.Groups("units").Success Then					' Now we're into ages expressed as numbers of various units - years
				Return True													' - don't want any other groups

			ElseIf m.Groups("months").Success Then					' Months
				Return True													' - don't want any other groups

			ElseIf m.Groups("weeks").Success Then					' Weeks
				Return True													' - don't want any other groups

			ElseIf m.Groups("days").Success Then					' And Days
				Return True													' - don't want any other groups
			End If
		Else
			strErrMessage = IIf(MyAddErrorNumberToMessage, String.Format("0006:{0}", My.Resources.err0006), My.Resources.err0006)
			Return False
		End If
	End Function

End Class
