Stack<int> clothesStack = new Stack<int>(
    Console
        .ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray());
int rackSum = int.Parse(Console.ReadLine());
int rackCount = 1;
int tempSum = 0;
while(clothesStack.Any())
{
    if (clothesStack.Peek() + tempSum <= rackSum)
    {
        tempSum += clothesStack.Pop();
    }
    else
    {
        rackCount++;
        tempSum = 0;
    }
    
}

Console.WriteLine(rackCount);