int quantity = int.Parse(Console.ReadLine());
int[] order = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
var customers = new Queue<int>(order);

Console.WriteLine(customers.Max());

while (customers.Any())
{
    if (quantity >= customers.Peek())
    {
        quantity -= customers.Dequeue();
    }
    else
    {
        Console.WriteLine("Orders left: " + string.Join(" ", customers));
        return;
    }
}
Console.WriteLine("Orders complete");

