using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/* *****************************************************************************
 * File:    StringExtensions.cs
 * Author:  Philip Pierce - Tuesday, September 09, 2014
 * Description:
 *  Extensions for strings
 *  
 * History:
 *  Tuesday, September 09, 2014 - Created
 * ****************************************************************************/

/// <summary>
/// Extensions for strings
/// </summary>
public static class StringExtensions
{
    #region IsDate

    /// <summary>
    /// Returns true if value is a date
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsDate(this string value)
    {
        try
        {
            DateTime tempDate;
            return DateTime.TryParse(value, out tempDate);
        }

        catch (Exception)
        {
            return false;
        }
    }

    // IsDate
    #endregion

    #region IsInt

    /// <summary>
    /// Returns true if value is an int
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsInt(this string value)
    {
        try
        {
            int tempInt;
            return int.TryParse(value, out tempInt);
        }

        catch (Exception)
        {
            return false;
        }
    }

    // IsInt
    #endregion

    #region Take

    /// <summary>
    /// Like LINQ take - takes the first x characters
    /// </summary>
    /// <param name="value">the string</param>
    /// <param name="count">number of characters to take</param>
    /// <param name="ellipsis">true to add ellipsis (...) at the end of the string</param>
    /// <returns></returns>
    public static string Take(this string value, int count, bool ellipsis = false)
    {
        // get number of characters we can actually take
        int lengthToTake = Math.Min(count, value.Length);

        // Take and return
        return (ellipsis && lengthToTake < value.Length) ?
            string.Format("{0}...", value.Substring(0, lengthToTake)) :
            value.Substring(0, lengthToTake);
    }

    // Take
    #endregion

    #region Skip

    /// <summary>
    /// like LINQ skip - skips the first x characters and returns the remaining string
    /// </summary>
    /// <param name="value">the string</param>
    /// <param name="count">number of characters to skip</param>
    /// <returns></returns>
    public static string Skip(this string value, int count)
    {
        return value.Substring(Math.Min(count, value.Length) - 1);
    }

    // Skip
    #endregion

    #region Reverse

    /// <summary>
    /// Reverses the string
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Reverse(this string input)
    {
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        return new String(chars);
    }

    // Reverse
    #endregion

    #region IsNullOrEmpty

    /// <summary>
    /// Null or empty check as extension
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }

    // IsNullOrEmpty
    #endregion

    #region IsNOTNullOrEmpty

    /// <summary>
    /// Returns true if the string is Not null or empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNOTNullOrEmpty(this string value)
    {
        return (!string.IsNullOrEmpty(value));
    }

    // IsNOTNullOrEmpty
    #endregion

    #region Formatted

    /// <summary>
    /// "a string {0}".Formatted("blah") vs string.Format("a string {0}", "blah")
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string Formatted(this string format, params object[] args)
    {
        return string.Format(format, args);
    }

    // Formatted
    #endregion

    #region StripHtml

    /// <summary>
    /// ditches html tags - note it doesn't get rid of things like nbsp;
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string StripHtml(this string html)
    {
        if (html.IsNullOrEmpty())
            return string.Empty;

        return Regex.Replace(html, @"<[^>]*>", string.Empty);
    }

    // StripHtml
    #endregion

    #region Match

    /// <summary>
    /// Returns true if the pattern matches
    /// </summary>
    /// <param name="value"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static bool Match(this string value, string pattern)
    {
        return Regex.IsMatch(value, pattern);
    }

    // Match
    #endregion

    #region RemoveSpaces

    /// <summary>
    /// Remove white space, not line end
    /// Useful when parsing user input such phone,
    /// price int.Parse("1 000 000".RemoveSpaces(),.....
    /// </summary>
    /// <param name="value"></param>
    public static string RemoveSpaces(this string value)
    {
        return value.Replace(" ", string.Empty);
    }

    // RemoveSpaces
    #endregion

    #region ReplaceRNWithBr

    /// <summary>
    /// Replaces line endings (\r \n) with &lt;br /&gt;
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ReplaceRNWithBr(this string value)
    {
        return value.Replace("\r\n", "<br />").Replace("\n", "<br />");
    }

    // ReplaceRNWithBr
    #endregion

    #region ToEmptyString

    /// <summary>
    /// Converts a null or "" to string.empty. Useful for XML code. Does nothing if <paramref name="value"/> already has a value
    /// </summary>
    /// <param name="value">string to convert</param>
    public static string ToEmptyString(string value)
    {
        return (string.IsNullOrEmpty(value)) ? string.Empty : value;
    }

    // ToEmptyString
    #endregion

    #region ToStringPretty

    /*
    * Converting a sequence to a nicely-formatted string is a bit of a pain. 
    * The String.Join method definitely helps, but unfortunately it accepts an 
    * array of strings, so it does not compose with LINQ very nicely.
    * 
    * My library includes several overloads of the ToStringPretty operator that 
    * hides the uninteresting code. Here is an example of use:
    * 
    * Console.WriteLine(Enumerable.Range(0, 10).ToStringPretty("From 0 to 9: [", ",", "]"));
    * 
    * The output of this program is:
    * 
    * From 0 to 9: [0,1,2,3,4,5,6,7,8,9]
    */

    /// <summary>
    /// Returns a comma delimited string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    public static string ToStringPretty<T>(this IEnumerable<T> source)
    {
        return (source == null) ? string.Empty : ToStringPretty(source, ",");
    }

    /// <summary>
    /// Returns a single string, delimited with <paramref name="delimiter"/> from source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string ToStringPretty<T>(this IEnumerable<T> source, string delimiter)
    {
        return (source == null) ? string.Empty : ToStringPretty(source, string.Empty, delimiter, string.Empty);
    }

    /// <summary>
    /// Returns a delimited string, appending <paramref name="before"/> at the start,
    /// and <paramref name="after"/> at the end of the string
    /// Ex: Enumerable.Range(0, 10).ToStringPretty("From 0 to 9: [", ",", "]")
    /// returns: From 0 to 9: [0,1,2,3,4,5,6,7,8,9]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="before"></param>
    /// <param name="delimiter"></param>
    /// <param name="after"></param>
    /// <returns></returns>
    public static string ToStringPretty<T>(this IEnumerable<T> source, string before, string delimiter, string after)
    {
        if (source == null)
            return string.Empty;

        StringBuilder result = new StringBuilder();
        result.Append(before);

        bool firstElement = true;
        foreach (T elem in source)
        {
            if (firstElement) firstElement = false;
            else result.Append(delimiter);

            result.Append(elem.ToString());
        }

        result.Append(after);
        return result.ToString();
    }

    // ToStringPretty
    #endregion


    #region InvertCase

    /// <summary>
    /// Inverts the case of each character in the given string and returns the new string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The converted string.</returns>
    public static string InvertCase(this string s)
    {
        return new string(
            s.Select(c => char.IsLetter(c) ? (char.IsUpper(c) ?
                  char.ToLower(c) : char.ToUpper(c)) : c).ToArray());
    }

    // InvertCase
    #endregion

    #region IsNullOrEmptyAfterTrimmed

    /// <summary>
    /// Checks whether the given string is null, else if empty after trimmed.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>True if string is Null or Empty, false otherwise.</returns>
    public static bool IsNullOrEmptyAfterTrimmed(this string s)
    {
        return (s.IsNullOrEmpty() || s.Trim().IsNullOrEmpty());
    }

    // IsNullOrEmptyAfterTrimmed
    #endregion

    #region ToCharList

    /// <summary>
    /// Converts the given string to <see cref="List{Char}"/>.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>Returns a list of char (or null if string is null).</returns>
    public static List<char> ToCharList(this string s)
    {
        return (s.IsNOTNullOrEmpty()) ? 
            s.ToCharArray().ToList() : 
            null;
    }

    // ToCharList
    #endregion

    #region SubstringFromXToY

    /// <summary>
    /// Extracts the substring starting from 'start' position to 'end' position.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="start">The start position.</param>
    /// <param name="end">The end position.</param>
    /// <returns>The substring.</returns>
    public static string SubstringFromXToY(this string s, int start, int end)
    {
        if (s.IsNullOrEmpty())
            return string.Empty;

        // if start is past the length of the string
        if (start >= s.Length)
            return string.Empty;

        // if end is beyond the length of the string, reset
        if (end >= s.Length)
            end = s.Length - 1;

        return s.Substring(start, end - start);
    }

    // SubstringFromXToY
    #endregion

    #region RemoveChar

    /// <summary>
    /// Removes the given character from the given string and returns the new string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="c">The character to be removed.</param>
    /// <returns>The new string.</returns>
    public static string RemoveChar(this string s, char c)
    {
        return (s.IsNOTNullOrEmpty()) ? s.Replace(c.ToString(), string.Empty) : string.Empty;
    }

    // RemoveChar
    #endregion

    #region GetWordCount

    /// <summary>
    /// Returns the number of words in the given string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The word count.</returns>
    public static int GetWordCount(this string s)
    {
        return (new Regex(@"\w+")).Matches(s).Count;
    }

    // GetWordCount
    #endregion

    #region IsPalindrome

    /// <summary>
    /// Checks whether the given string is a palindrome.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>True if the given string is palindrome, false otherwise.</returns>
    public static bool IsPalindrome(this string s)
    {
        return s.Equals(s.Reverse());
    }

    // IsPalindrome
    #endregion

    #region IsNotPalindrome

    /// <summary>
    /// Checks whether the given string is NOT a palindrome.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>True if the given string is NOT palindrome, false otherwise.</returns>
    public static bool IsNotPalindrome(this string s)
    {
        return s.IsPalindrome().Toggle();
    }

    // IsNotPalindrome
    #endregion

    #region IsValidEmail

    /// <summary>
    /// Returns true if the email address is valid
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsValidEmail(this string email)
    {
        // fail if null or too long
        if ((string.IsNullOrEmpty(email)) || (email.Length > 100))
            return false;

        //// set to ignore case
        //Regex regex = new Regex(STR_EmailPattern, RegexOptions.IgnoreCase);
        //// return if the regex matches
        //return regex.IsMatch(email);


        // use the MSDN email validator
        return new EmailValidator().IsValidEmail(email);
    }

    // IsValidEmail
    #endregion

    #region IsValidIPAddress

    /// <summary>
    /// Checks whether the given string is a valid IP address using regular expressions.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>True if it is a valid IP address, false otherwise.</returns>
    public static bool IsValidIPAddress(this string s)
    {
        return Regex.IsMatch(s, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
    }

    // IsValidIPAddress
    #endregion

    #region AppendSep

    /// <summary>
    /// Appends the given separator to the given string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="sep">The separator to be appended.</param>
    /// <returns>The appended string.</returns>
    public static string AppendSep(this string s, string sep)
    {
        return s + sep;
    }

    // AppendSep
    #endregion

    #region AppendComma

    /// <summary>
    /// Appends the a comma to the given string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The appended string.</returns>
    public static string AppendComma(this string s)
    {
        return s.AppendSep(",");
    }

    // AppendComma
    #endregion

    #region AppendNewLine

    /// <summary>
    /// Appends \r \n to a string
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The appended string.</returns>
    public static string AppendNewLine(this string s)
    {
        return s.AppendSep("\r\n");
    }

    // AppendNewLine
    #endregion

    #region AppendHtmlBr

    /// <summary>
    /// Appends \r \n to a string
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The appended string.</returns>
    public static string AppendHtmlBr(this string s)
    {
        return s.AppendSep("<br />");
    }

    // AppendHtmlBr
    #endregion

    #region AppendSpace

    /// <summary>
    /// Appends the a space to the given string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The appended string.</returns>
    public static string AppendSpace(this string s)
    {
        return s.AppendSep(" ");
    }

    // AppendSpace
    #endregion

    #region AppendHyphen

    /// <summary>
    /// Appends the a hyphen to the given string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <returns>The appended string.</returns>
    public static string AppendHyphen(this string s)
    {
        return s.AppendSep("-");
    }

    // AppendHyphen
    #endregion

    #region AppendSep

    /// <summary>
    /// Appends the given character to the given string and returns the new string.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="sep">The character to be appended.</param>
    /// <returns>The appended string.</returns>
    public static string AppendSep(this string s, char sep)
    {
        return s.AppendSep(sep.ToString());
    }

    // AppendSep
    #endregion

    #region AppendWithSep

    /// <summary>
    /// Returns this string + sep + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <param name="sep">The separator to be introduced in between these two strings.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithSep(this string s, string newString, string sep)
    {
        return s.AppendSep(sep) + newString;
    }

    // AppendWithSep
    #endregion

    #region AppendWithSep

    /// <summary>
    /// Returns this string + sep + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <param name="sep">The separator to be introduced in between these two strings.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithSep(this string s, string newString, char sep)
    {
        return s.AppendSep(sep) + newString;
    }

    // AppendWithSep
    #endregion

    #region AppendWithComma

    /// <summary>
    /// Returns this string + "," + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithComma(this string s, string newString)
    {
        return s.AppendWithSep(newString, ",");
    }

    // AppendWithComma
    #endregion

    #region AppendWithNewLine

    /// <summary>
    /// Returns this string + "\r\n" + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithNewLine(this string s, string newString)
    {
        return s.AppendWithSep(newString, "\r\n");
    }

    // AppendWithNewLine
    #endregion

    #region AppendWithHtmlBr

    /// <summary>
    /// Returns this string + "\r\n" + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithHtmlBr(this string s, string newString)
    {
        return s.AppendWithSep(newString, "<br />");
    }

    // AppendWithHtmlBr
    #endregion

    #region AppendWithHyphen

    /// <summary>
    /// Returns this string + "-" + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithHyphen(this string s, string newString)
    {
        return s.AppendWithSep(newString, "-");
    }

    // AppendWithHyphen
    #endregion

    #region AppendWithSpace

    /// <summary>
    /// Returns this string + " " + newString.
    /// </summary>
    /// <param name="s">The given string.</param>
    /// <param name="newString">The string to be concatenated.</param>
    /// <returns>The appended string.</returns>
    /// <remarks>This may give poor performance for large number of strings used in loop. Use <see cref="StringBuilder"/> instead.</remarks>
    public static string AppendWithSpace(this string s, string newString)
    {
        return s.AppendWithSep(newString, " ");
    }

    // AppendWithSpace
    #endregion

    #region CreateRandomPassword

    /// <summary>
    /// Creates a random password mixed case, with numbers and special characters
    /// NOTE: sets value of sVal as well
    /// </summary>
    /// <param name="sVal"></param>
    /// <param name="PasswordLength">length of the new password</param>
    public static string CreateRandomPassword(this string sVal, int PasswordLength)
    {
        return CreateRandomPassword(sVal, PasswordLength, true, true, true, true, true, true, false);
    }

    /// <summary>
    /// Creates a random password mixed case, with numbers and special characters (numbers and special chars are allowed, but not required)
    /// NOTE: sets value of sVal as well
    /// </summary>
    /// <param name="sVal"></param>
    /// <param name="PasswordLength">length of the new password</param>
    /// <param name="allowMixedCase">allow upper and lower case</param>
    /// <param name="allowNumbers">allow numbers to be part of the password</param>
    /// <param name="allowSpecialCharacters">allow special characters</param>
    public static string CreateRandomPassword(this string sVal, int PasswordLength, bool allowMixedCase, bool allowNumbers, bool allowSpecialCharacters)
    {
        return CreateRandomPassword(sVal, PasswordLength, true, true, true, false, false, false, false);
    }

    /// <summary>
    /// Creates a random password mixed case, with numbers and special characters
    /// NOTE: sets value of sVal as well
    /// </summary>
    /// <param name="sVal"></param>
    /// <param name="PasswordLength">length of the new password</param>
    /// <param name="ignoreProgrammingCharacters">Avoid punctuation used in programming <![CDATA[ ($, ', ", &, [space], ,, ?, @, #, <, >, (, ), {, }, [, ], /, \) ]]> .</param>
    public static string CreateRandomPassword(this string sVal, int PasswordLength, bool ignoreProgrammingCharacters)
    {
        return CreateRandomPassword(sVal, PasswordLength, true, true, true, true, true, true, ignoreProgrammingCharacters);
    }

    /// <summary>
    /// Creates a random password mixed case, with numbers and special characters (numbers and special chars are allowed, but not required)
    /// NOTE: sets value of sVal as well
    /// </summary>
    /// <param name="sVal"></param>
    /// <param name="PasswordLength">length of the new password</param>
    /// <param name="allowMixedCase">allow upper and lower case</param>
    /// <param name="allowNumbers">allow numbers to be part of the password</param>
    /// <param name="allowSpecialCharacters">allow special characters</param>
    /// <param name="ignoreProgrammingCharacters">Avoid punctuation used in programming <![CDATA[ ($, ', ", &, [space], ,, ?, @, #, <, >, (, ), {, }, [, ], /, \) ]]> .</param>
    public static string CreateRandomPassword(this string sVal, int PasswordLength, bool allowMixedCase, bool allowNumbers, bool allowSpecialCharacters, bool ignoreProgrammingCharacters)
    {
        return CreateRandomPassword(sVal, PasswordLength, true, true, true, false, false, false, ignoreProgrammingCharacters);
    }

    /// <summary>
    /// Creates a random password (a-z, A-Z, 0-9), and with special characters.
    /// NOTE: sets value of sVal as well
    /// </summary>
    /// <param name="sVal"></param>
    /// <param name="PasswordLength">length of the new password</param>
    /// <param name="allowMixedCase">allow upper and lower case</param>
    /// <param name="allowNumbers">allow numbers to be part of the password</param>
    /// <param name="allowSpecialCharacters">allow special characters</param>
    /// <param name="mixedCaseRequired">true to required both upper and lower case letters in the password</param>
    /// <param name="numberRequired">true to require at least one number in the password</param>
    /// <param name="specialRequired">true to require at least one special character</param>
    /// <param name="ignoreProgrammingCharacters">Avoid punctuation used in programming <![CDATA[ ($, ', ", &, [space], ,, ?, @, #, <, >, (, ), {, }, [, ], /, \) ]]> .</param>
    public static string CreateRandomPassword(this string sVal, int PasswordLength, bool allowMixedCase, bool allowNumbers, bool allowSpecialCharacters, bool mixedCaseRequired, bool numberRequired, bool specialRequired, bool ignoreProgrammingCharacters)
    {
        #region Validation

        if ((!allowMixedCase) && (mixedCaseRequired))
            throw new ArgumentException("mixedCaseRequired cannot be true if allowMixedCase is false", "allowMixedCase");
        if ((!allowNumbers) && (numberRequired))
            throw new ArgumentException("numberRequired cannot be true if allowNumbers is false", "allowNumbers");
        if ((!allowSpecialCharacters) && (specialRequired))
            throw new ArgumentException("specialRequired cannot be true if allowSpecialCharacters is false", "allowSpecialCharacters");

        // Validation
        #endregion

        StringBuilder sb = new StringBuilder();

        // pick random locations for each
        int UpperCaseIndex = 0.RandomRangeInclusive(PasswordLength);
        int NumberIndex = 1.RandomRangeInclusive(PasswordLength);
        while (NumberIndex == UpperCaseIndex)
            NumberIndex = 1.RandomRangeInclusive(PasswordLength);
        int SpecialIndex = 1.RandomRangeInclusive(PasswordLength);
        while ((SpecialIndex == UpperCaseIndex) || (SpecialIndex == NumberIndex))
            SpecialIndex = 1.RandomRangeInclusive(PasswordLength);

        // loop through and randomly create the password
        for (int i = 0; i < PasswordLength; i++)
        {
            // if we are using a required then, test now
            if ((mixedCaseRequired) && (i == UpperCaseIndex))
            {
                // A-Z (65-90)
                sb.Append(65.RandomRangeInclusive(90).ToChar());
                continue;
            }

            // force lower case
            if (i == 0)
            {
                // a-z (97-122)
                sb.Append(97.RandomRangeInclusive(122).ToChar());
                continue;
            }

            if ((numberRequired) && (i == NumberIndex))
            {
                // 0-9 (48-57)
                sb.Append(48.RandomRangeInclusive(57).ToChar());
                continue;
            }

            if ((specialRequired) && (i == SpecialIndex))
            {
                sb.Append(GetSpecialCode(ignoreProgrammingCharacters));
                continue;
            }

            // when true, we've assigned a code for this iteration
            bool HasCode = false;

            // loop until we get a code for this iteration
            while (!HasCode)
            {
                // random number 1-4
                switch (1.RandomRangeInclusive(4))
                {
                    case 1: // a-z (97-122)
                        sb.Append(97.RandomRangeInclusive(123).ToChar());
                        HasCode = true;
                        break;
                    case 2: // A-Z (65-90)
                        if (allowMixedCase)
                        {
                            sb.Append(65.RandomRangeInclusive(91).ToChar());
                            HasCode = true;
                        }
                        break;
                    case 3: // 0-9 (48-57)
                        if (allowNumbers)
                        {
                            sb.Append(48.RandomRangeInclusive(58).ToChar());
                            HasCode = true;
                        }
                        break;
                    case 4: // # $ % ^ & * ( )  (32-47 & 58-64)
                        if (allowSpecialCharacters)
                        {
                            sb.Append(GetSpecialCode(ignoreProgrammingCharacters));
                            HasCode = true;
                        }
                        break;
                }
            }
        }

        // return
        return sb.ToString().Trim();
    }

    #region GetSpecialCode

    /// <summary>
    /// Returns a special code
    /// </summary>
    /// <param name="ignoreProgrammingCharacters">true to ignore programming characters</param>
    private static char GetSpecialCode(bool ignoreProgrammingCharacters)
    {
        // $, ', ", &, [space], ,, ?, @, #, <, >, (, ), {, }, [, ], /, \

        int specialCode;

        do
        {
            // get the code
            specialCode = 32.RandomRangeInclusive(65);

            // keep going until we get a valid one
            // skip numbers (ASCII 48 - 57)
        } while (((specialCode > 47) && (specialCode < 58)) ||
            (ignoreProgrammingCharacters && specialCode.IsNotIn(37, 42, 43, 45, 61))); // only allow %, *, +, -, =   if ignore programming

        return specialCode.ToChar();
    }

    // GetSpecialCode
    #endregion

    // CreateRandomPassword
    #endregion

    #region ToTitleCase

    /// <summary>
    /// Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).
    /// </summary>
    /// <param name="mText"></param>
    /// <returns></returns>
    public static string ToTitleCase(this string mText)
    {
        if (mText.IsNullOrEmpty()) 
            return mText;

        // get globalization info
        System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

        // convert to title case
        return textInfo.ToTitleCase(mText);
    }

    // ToTitleCase
    #endregion

    /// <summary>
    /// Finds the specified Start Text and the End Text in this string instance, and returns a string
    /// containing all the text starting from startText, to the beginning of endText. (endText is not
    /// included.)
    /// usage: "This is a tester for my cool extension method!!".Subsetstring("tester", "cool",true);
    /// Output: "tester for my "
    /// </summary>
    /// <param name="s">The string to retrieve the subset from.</param>
    /// <param name="startText">The Start Text to begin the Subset from.</param>
    /// <param name="endText">The End Text to where the Subset goes to.</param>
    /// <param name="ignoreCase">Whether or not to ignore case when comparing startText/endText to the string.</param>
    /// <returns>A string containing all the text starting from startText, to the begining of endText.</returns>
    public static string SubsetString(this string s, string startText, string endText, bool ignoreCase)
    {
        if (s.IsNullOrEmpty())
            return string.Empty;
        
        if (startText.IsNullOrEmpty() || endText.IsNullOrEmpty())
            throw new ArgumentException("Start Text and End Text cannot be empty.");

        // set our starting values
        string tempStr = ignoreCase ? s.ToUpperInvariant() : s;
        int start = ignoreCase ? tempStr.IndexOf(startText.ToUpperInvariant()) : tempStr.IndexOf(startText);
        int end = ignoreCase ? tempStr.IndexOf(endText.ToUpperInvariant(), start) : tempStr.IndexOf(endText, start);

        // get the substring
        return SubstringFromXToY(tempStr, start, end);
    }

    /// <summary>
    /// Adds extra spaces to meet the total length
    /// </summary>
    /// <param name="s"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string PadRightEx(this string s, int length)
    {
        // exit if string is already at length
        if ((!s.IsNullOrEmpty()) && (s.Length >= length))
            return s;

        // if string is null, then return empty string
        // else, add spaces and exit
        return (s != null) ?
            string.Format("{0}{1}", s, new string(' ', length - s.Length)) :
            new string(' ', length);
    }
}
