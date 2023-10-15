int count = int.Parse(Console.ReadLine());

Swap<int> items = new();

for (int i = 0; i < count; i++)
{
    int token = int.Parse(Console.ReadLine());
    items.Add(token);
}

int[] indices = Console
    .ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

items.SwapElement(indices[0], indices[1]);

Console.WriteLine(items.ToString());