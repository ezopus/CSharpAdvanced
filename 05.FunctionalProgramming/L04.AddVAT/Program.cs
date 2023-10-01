Func<double, double> AddVat = p =>
{
    return p * 1.2;
};

double[] numbers = Console
    .ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(p => AddVat(p))
    .ToArray();

foreach (var number in numbers)
{
    Console.WriteLine($"{number:f2}");
}