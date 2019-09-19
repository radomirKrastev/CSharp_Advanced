using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace WordsCount
{
    public class Program
    {
        public static void Main()
        {
            using(var readWords = new StreamReader("words.txt"))
            {
                var words = readWords.ReadToEnd().Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);

                using (var readText = new StreamReader("text.txt"))
                {
                    using (var writer = new StreamWriter("output.txt"))
                    {
                        string pattern = @"[A-Za-z']+";
                        var regex = new Regex(pattern);
                        var text = readText.ReadToEnd();
                        var allWordsFromText = regex.Matches(text);
                        var wordsCount = new Dictionary<string, int > (); 

                        foreach (var word in words)
                        {
                            wordsCount.Add(word.ToLower(), 0);

                            foreach (var wordFromText in allWordsFromText)
                            {
                                if (word.ToLower() == wordFromText.ToString().ToLower())
                                {
                                    wordsCount[word]++;
                                }
                            }
                        }

                        foreach (var word in wordsCount.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{word.Key}-{word.Value}");
                        }
                    }
                }
            }
        }
    }
}
