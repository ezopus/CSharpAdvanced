Func<HashSet<int>, int> getMin = numbers =>
{
    int min = int.MaxValue;
    foreach (int number in numbers)
    {
        if (number < min)
        {
            min = number;
        }
    }
    return min;
};

HashSet<int> numbers = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Console.WriteLine(getMin(numbers));