int[] input = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int pushElements = input[0];
int popElements = input[1];
int findElement = input[2];

Queue<int> stack = new Queue<int>();

int[] numbers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

foreach (int number in numbers)
{
    stack.Enqueue(number);
}

for (int i = 0; i < popElements; i++)
{
    stack.Dequeue();
}

if (stack.Any())
{
    if (stack.Contains(findElement))
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine(stack.Min());
    }
}
else
{
    Console.WriteLine(0);
}
