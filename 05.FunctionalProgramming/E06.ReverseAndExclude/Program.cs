using System.Net.NetworkInformation;

Func<List<int>, List<int>> reverse = numbers =>
{
    List<int> reversed = new();
    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        reversed.Add(numbers[i]);
    }
    return reversed;
};

Func<List<int>, Predicate<int>, List<int>> exclude = (numbers, match) =>
{
    List<int> exclusionList = new();
    foreach (int number in numbers)
    {
        if (!match(number))
        {
            exclusionList.Add(number);
        }
    }
    return exclusionList;
};


List<int> input = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

Predicate<int> checkDivider = number => number % divider == 0;

input = exclude(input, checkDivider);

input = reverse(input);

Console.WriteLine(string.Join(" ", input));