using System.Collections;

namespace ListyIterators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        private List<T> list;

        private int index;
        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index < list.Count - 1;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(list[index]);
        }

        // public void PrintAll()
        // {
        //     Console.WriteLine(string.Join(" ", list));
        // }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
                yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
