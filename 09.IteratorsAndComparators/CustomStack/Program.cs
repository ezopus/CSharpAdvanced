namespace CustomStacks
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> numbers = new();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                if (action == "Push")
                {
                    int[] itemsToPush = tokens.Skip(1).Select(int.Parse).ToArray();
                    foreach (var item in itemsToPush)
                    {
                        numbers.Push(item);
                    }
                }
                else if (action == "Pop")
                {
                    try
                    {
                        numbers.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}