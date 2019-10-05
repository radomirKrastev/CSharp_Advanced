using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IReadOnlyList<string> Authors { get; set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Authors = authors;
            this.Title = title;
            this.Year = year;
        }
    }
}
