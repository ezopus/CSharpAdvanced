Func<string, int, bool> evenOddMatch = (condition, number) =>
{
    if (condition == "even")
    {
        return number % 2 == 0;
    }
    else
    {
        return number % 2 != 0;
    }
};

Func<int, int, List<int>> rangeFunc = (startRange, endRange) =>
{
    List<int> range = new();
    for (int i = startRange; i <= endRange; i++)
    {
        range.Add(i);
    }

    return range;
};

int[] inputRange = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

List<int> range = new();
range = rangeFunc(inputRange[0], inputRange[1]);

string condition = Console.ReadLine();

foreach (var number in range)
{
    if (evenOddMatch(condition, number))
    {
        Console.Write(number + " ");
    }
}
