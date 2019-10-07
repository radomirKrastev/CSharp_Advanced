using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    public class ExtensionMethods
    {
        public static string ReplaceAndReverse(string text, string pattern)
        {
            var temporaryResult = Regex.Replace(text, pattern,"@");
            var words = temporaryResult.Split(new string[] { " "},StringSplitOptions.RemoveEmptyEntries).Reverse();

            return string.Join(" ",words);
        }
    }
}
