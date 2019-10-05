using System.Collections.Generic;
using System;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book other)
        {
            var dateDifference = this.Year.CompareTo(other.Year);

            if (dateDifference == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return dateDifference;            
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
