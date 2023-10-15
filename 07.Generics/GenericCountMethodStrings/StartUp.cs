int count = int.Parse(Console.ReadLine());

GenericCount<double> items = new();

for (int i = 0; i < count; i++)
{
    double token = double.Parse(Console.ReadLine());
    items.Add(token);
}

double itemToCompare = double.Parse(Console.ReadLine());

Console.WriteLine(items.Count(itemToCompare));