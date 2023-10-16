namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(currentPerson);
            }

            int comparableIndex = int.Parse(Console.ReadLine()) - 1;
            Person comparablePerson = people[comparableIndex];

            int matches = 0;
            int notEqual = 0;

            foreach (Person person in people)
            {
                if (person.CompareTo(comparablePerson) == 0)
                {
                    matches++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (matches != 1)
            {
                Console.WriteLine($"{matches} {notEqual} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}