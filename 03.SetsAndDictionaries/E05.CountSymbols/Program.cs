SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

string input = Console.ReadLine();

foreach (char ch in input)
{
    if (!symbols.ContainsKey(ch))
    {
        symbols.Add(ch, 0);
    }
    symbols[ch]++;
}

foreach (var kp in symbols)
{
    Console.WriteLine($"{kp.Key}: {kp.Value} time/s");
}