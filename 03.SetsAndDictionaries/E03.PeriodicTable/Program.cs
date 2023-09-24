SortedSet<string> elements = new SortedSet<string>();
int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    foreach (string token in tokens)
    {
        elements.Add(token);
    }
}

Console.WriteLine(string.Join(" ", elements));