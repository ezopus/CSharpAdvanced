using System.Collections;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> _items;

        public Lake(List<int> items)
        {
            _items = items;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return _items[i];
                }
            }

            for (int i = _items.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return _items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
