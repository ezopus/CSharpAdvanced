namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSet = new();
            SortedSet<Person> sorted = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(tokens[0], int.Parse(tokens[1]));

                hashSet.Add(person);
                sorted.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}