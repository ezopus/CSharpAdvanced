Func<List<string>, Predicate<string>, List<string>> nameFilter = (names, condition) =>
{
    List<string> filtered = new();
    foreach (var name in names)
    {
        if (condition(name))
        {
            filtered.Add(name);
        }
    }
    return filtered;
};

int length = int.Parse(Console.ReadLine());
List<string> names = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Predicate<string> checkLength = name => name.Length <= length;

names = nameFilter(names, checkLength);

foreach (string name in names)
{
    Console.WriteLine(name);
}