using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();

        public Library(params Book [] books)
        {
            this.books= new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BookEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
