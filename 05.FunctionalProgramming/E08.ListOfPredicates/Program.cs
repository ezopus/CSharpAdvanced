List<Predicate<int>> predicates = new();

Func<List<int>, HashSet<int>, List<int>> divisibles = (numbers, dividers) =>
{
    List<int> results = new();
    //iterate through whole range
    foreach (int number in numbers)
    {
        //flag to stop if number in range is not divisible by number from divider range
        bool isDivisible = true;

        //check for each number if it's true for each predicate
        foreach (var match in predicates)
        {
            if (!match(number))
            {
                isDivisible = false;
                break;
            }
        }
        //if all predicates are met and number is divisible by all dividers in range - add to list
        if (isDivisible)
        {
            results.Add(number);
        }
    }
    return results;
};

int rangeEnd = int.Parse(Console.ReadLine());
HashSet<int> dividers = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

List<int> output = Enumerable.Range(1, rangeEnd).ToList();

//fill list of predicates with condition for each divider
foreach (int divider in dividers)
{
    predicates.Add(n => n % divider == 0);
}

output = divisibles(output, dividers);

Console.WriteLine(string.Join(" ", output));