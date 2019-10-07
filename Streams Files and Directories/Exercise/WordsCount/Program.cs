using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace WordsCount
{
    public class Program
    {
        public static void Main()
        {
            var keyWords = File.ReadAllText("words.txt").Split(new string [] {" ",Environment.NewLine,"\t" },StringSplitOptions.RemoveEmptyEntries);
            var textRaw = File.ReadAllText("text.txt");
            var pattern = new Regex( @"[a-zA-Z]+");

            MatchCollection matches = pattern.Matches(textRaw);

            File.Create("expectedResult.txt").Close();
            var result = new List<string>();

            foreach (var word in keyWords)
            {
                var wordCount = 0;

                foreach (var pieceOfText in matches)
                {
                    if (word.ToLower() == pieceOfText.ToString().ToLower())
                    {
                        wordCount++;
                    }   
                }

                result.Add(word + $" - {wordCount}");
            }

            File.AppendAllText("expectedResult.txt",
                string.Join(Environment.NewLine,
                result.OrderByDescending(x => int.Parse(x[x.Length - 1].ToString()))));
        }
    }
}
