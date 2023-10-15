int count = int.Parse(Console.ReadLine());

Box<int> items = new();

for (int i = 0; i < count; i++)
{
    int token = int.Parse(Console.ReadLine());
    items.Add(token);
}

Console.WriteLine(items.ToString());



 