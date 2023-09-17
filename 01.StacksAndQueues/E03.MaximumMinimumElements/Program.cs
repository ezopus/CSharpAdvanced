var stack = new  Stack<int>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
    switch (command[0])
    {
        case 1:
            stack.Push(command[1]);
            break;
        case 2:
            stack.Pop();
            break;
        case 3:
            if (stack.Any())
            {
                Console.WriteLine(stack.Max());
            }
            break;
        case 4:
            if (stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            break;
    }
}

Console.WriteLine(string.Join(", ", stack));

