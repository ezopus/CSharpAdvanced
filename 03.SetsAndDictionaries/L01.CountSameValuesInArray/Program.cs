List<double> numbers = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .ToList();

var numberCount = new Dictionary<double, int>();

foreach (var number in numbers)
{
    if (numberCount.ContainsKey(number))
    {
        numberCount[number]++;
    }
    else
    {
        numberCount.Add(number, 1);
    }
}

foreach (var kp in numberCount)
{
    Console.WriteLine($"{kp.Key} - {kp.Value} times");
}