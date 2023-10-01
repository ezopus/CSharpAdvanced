List<string> guests = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

static Predicate<string> GetPredicate(string condition, string value)
{
    switch (condition)
    {
        case "StartsWith":
            return person => person.StartsWith(value);
        case "EndsWith":
            return person => person.EndsWith(value);
        case "Length":
            return person => person.Length == int.Parse(value);
        default:
            return default;
    }
}

string command;
while ((command = Console.ReadLine()) != "Party!")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = tokens[0];
    string condition = tokens[1];
    string value = tokens[2];
    switch (action)
    {
        case "Remove":
            guests.RemoveAll(GetPredicate(condition, value));
            break;
        case "Double":
            List<string> peopleToDouble = guests.FindAll(GetPredicate(condition, value));
            foreach (string person in peopleToDouble)
            {
                int index = guests.FindIndex(p => p == person);
                guests.Insert(index, person);
            }
            break;
    }
}

if (guests.Any())
{
    Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}