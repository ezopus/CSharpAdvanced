int count = int.Parse(Console.ReadLine());
var elements = new Dictionary<int, int>();

for (int i = 0; i < count; i++)
{
    int input = int.Parse(Console.ReadLine());
    if (elements.ContainsKey(input))
    {
        elements[input]++;
    }
    else
    {
        elements.Add(input, 1);
    }
}

int even = elements.Single(x => x.Value % 2 == 0).Key;

Console.WriteLine(even);