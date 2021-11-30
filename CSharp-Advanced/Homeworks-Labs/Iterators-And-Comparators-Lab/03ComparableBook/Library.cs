using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current
            {
                get
                {
                    return books[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                this.index++;

                if (this.index < this.books.Count)
                {
                    return true;
                }
                else return false;
            }

            public void Reset() => this.index = -1;
        }
    }
}
