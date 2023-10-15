
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        private IComparer<Book> comparer;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex;

            private readonly List<Book> books;
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            //leave empty for now, garbage collector will take care
            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
