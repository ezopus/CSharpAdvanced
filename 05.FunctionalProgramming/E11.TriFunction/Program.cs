/*
Func<List<string>, int, string> triFunc = (names, length) =>
{
    foreach (var name in names)
    {
        if (name.Sum(x => x) >= length)
        {
            return name;
        }
    }
    return default;
};
*/
Func<string, int, bool> getName = (name, length) =>
{
    if (name.Sum(c => c) >= length)
    {
        return true;
    }
    return false;
};

Func<string[], int, Func<string, int, bool>, string> traverseAllNames = (names, length, match) =>
{
    return names.FirstOrDefault(name => getName(name, length));
};


int length = int.Parse(Console.ReadLine());
string[] names = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine(traverseAllNames(names, length, getName));