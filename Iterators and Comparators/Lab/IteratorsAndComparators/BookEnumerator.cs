using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookEnumerator : IEnumerator<Book>
    {
        private List<Book> books;
        private int index = -1;

        public BookEnumerator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => this.books[index];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++index < this.books.Count)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
        }
    }
}
