Func<string, bool> GetWordsWithCapitalLetter = word =>
{
    if (char.IsUpper(word[0]))
    {
        return true;
    }

    return false;
};

string[] input = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(w => GetWordsWithCapitalLetter(w))
    .ToArray();

foreach (string word in input)
{
    Console.WriteLine(word);
}
