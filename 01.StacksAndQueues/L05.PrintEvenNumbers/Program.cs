Queue<int> numbers = new (
    Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .Where(x => x % 2 == 0));
Console.WriteLine(string.Join(", ", numbers));