List<string> guests = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> filters = new();

static Predicate<string> GetPredicate(string condition, string value)
{
    switch (condition)
    {
        case "Starts with":
            return person => person.StartsWith(value);
        case "Ends with":
            return person => person.EndsWith(value);
        case "Length":
            return person => person.Length == int.Parse(value);
        case "Contains":
            return person => person.Contains(value);
        default:
            return default;
    }
}

string command;
while ((command = Console.ReadLine()) != "Print")
{
    string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string action = tokens[0];
    string filter = tokens[1];
    string value = tokens[2];
    switch (action)
    {
        case "Add filter":
            if (!filters.ContainsKey(filter + value))
            {
                filters.Add(filter + value, GetPredicate(filter, value));
            }
            break;
        case "Remove filter":
            filters.Remove(filter + value);
            break;
    }
}

foreach (var filter in filters)
{
    guests.RemoveAll(filter.Value);
}

if (guests.Any())
{
    Console.WriteLine(string.Join(" ", guests));
}
