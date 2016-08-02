Public Module SentenceCasingModule
   <System.Runtime.CompilerServices.Extension> _
   Public Function ToSentenceCase(ByVal input As String) As String
      If IsAllUpper(input) Then
         Return input
      End If
      If IsAllUpperOrAllLower(input) Then
         ' fix the ALL UPPERCASE or all lowercase namesy)
         Return Join(input.Split(" "c).Select(Function(word) wordToProperCase(word)).ToArray, " ")
      Else
         ' leave the CamelCase or Propercase names alone
         Return input
      End If
   End Function

   ''' <summary>
   ''' Determine if the string is all uppercased
   ''' </summary>
   ''' <param name="sender">String</param>
   ''' <returns>Upper cased string</returns>
   Public Function IsAllUpper(ByVal sender As String) As Boolean
      For i As Integer = 0 To sender.Length - 1
         If Char.IsLetter(sender.Chars(i)) AndAlso (Not (Char.IsUpper(sender.Chars(i)))) Then
            Return False
         End If
      Next i
      Return True
   End Function

   <System.Runtime.CompilerServices.Extension> _
   Public Function IsAllUpperOrAllLower(ByVal input As String) As Boolean
      Return (input.ToLower().Equals(input) OrElse input.ToUpper().Equals(input))
   End Function

   Private Function wordToProperCase(ByVal word As String) As String
      If String.IsNullOrEmpty(word) Then
         Return word
      End If

      ' Standard case
      Dim Value As String = capitaliseFirstLetter(word)

      ' Special cases:
      Value = properSuffix(Value, "'") ' D'Artagnon, D'Silva
      Value = properSuffix(Value, ".") ' ???
      Value = properSuffix(Value, "-") ' Oscar-Meyer-Weiner
      Value = properSuffix(Value, "Mc") ' Scots
      Value = properSuffix(Value, "Mac") ' Scots

      ' Special words:
      Value = specialWords(Value, "van") ' Dick van Dyke
      Value = specialWords(Value, "von") ' Baron von Bruin-Valt
      Value = specialWords(Value, "de")
      Value = specialWords(Value, "di")
      Value = specialWords(Value, "da") ' Leonardo da Vinci, Eduardo da Silva
      Value = specialWords(Value, "of") ' The Grand Old Duke of York
      Value = specialWords(Value, "the") ' William the Conqueror
      Value = specialWords(Value, "HRH") ' His/Her Royal Highness
      Value = specialWords(Value, "HRM") ' His/Her Royal Majesty
      Value = specialWords(Value, "H.R.H.") ' His/Her Royal Highness
      Value = specialWords(Value, "H.R.M.") ' His/Her Royal Majesty

      Value = dealWithRomanNumerals(Value) ' William Gates, III

      Return Value

   End Function

   Private Function properSuffix(ByVal word As String, ByVal prefix As String) As String
      If String.IsNullOrEmpty(word) Then
         Return word
      End If

      Dim lowerWord As String = word.ToLower()
      Dim lowerPrefix As String = prefix.ToLower()

      If Not lowerWord.Contains(lowerPrefix) Then
         Return word
      End If

      Dim index As Integer = lowerWord.IndexOf(lowerPrefix)

      ' If the search string is at the end of the word ignore.
      If index + prefix.Length = word.Length Then
         Return word
      End If

      Return word.Substring(0, index) & prefix & capitaliseFirstLetter(word.Substring(index + prefix.Length))

   End Function

   Private Function specialWords(ByVal word As String, ByVal specialWord As String) As String
      If word.Equals(specialWord, StringComparison.InvariantCultureIgnoreCase) Then
         Return specialWord
      Else
         Return word
      End If
   End Function

   Private Function dealWithRomanNumerals(ByVal word As String) As String
      Dim ones As New List(Of String)() From {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"}
      Dim tens As New List(Of String)() From {"X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC", "C"}
      ' assume nobody uses hundreds

      For Each number As String In ones
         If word.Equals(number, StringComparison.InvariantCultureIgnoreCase) Then
            Return number
         End If
      Next number

      For Each ten As String In tens
         For Each one As String In ones
            If word.Equals(ten & one, StringComparison.InvariantCultureIgnoreCase) Then
               Return ten & one
            End If
         Next one
      Next ten

      Return word

   End Function

   Private Function capitaliseFirstLetter(ByVal word As String) As String
      Return Char.ToUpper(word.Chars(0)) & word.Substring(1).ToLower()
   End Function

End Module
