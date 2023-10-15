namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            stack = new Stack<T>();
        }

        private Stack<T> stack;

        public void Add(T item)
        {
            stack.Push(item);
        }

        public T Remove()
        {
            return stack.Pop();
        }

        public int Count
        {
            get => stack.Count;
        }


    }
}
