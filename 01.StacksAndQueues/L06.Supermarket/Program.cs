string input = "";

Queue<string> customers = new();
while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        foreach (var c in customers)
        {
            Console.WriteLine(c);
        }
        customers.Clear();
    }
    else
    {
        customers.Enqueue(input);
    }
}

if (customers.Any())
{
    Console.WriteLine($"{customers.Count} people remaining.");
}
else
{
    Console.WriteLine("0 people remaining.");
}