Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

int wastedWater = 0;

while (bottles.Any() && cups.Any())
{
    int currentCup = cups.Peek();
    while (currentCup > 0)
    {
        if (currentCup <= bottles.Peek())
        {
            wastedWater += bottles.Pop() - currentCup;
            cups.Dequeue();
            currentCup = 0;
        }
        else
        {
            currentCup -= bottles.Pop();
        }
    }
}

if (bottles.Any() && !cups.Any())
{
    Console.WriteLine("Bottles: " + string.Join(" ", bottles));
}
else if (cups.Any() && !bottles.Any())
{
    Console.WriteLine("Cups: " + string.Join(" ", cups));
}

Console.WriteLine($"Wasted litters of water: {wastedWater}");



/*
4 2 10 5
3 15 15 11 6

1 5 28 1 4
3 18 1 9 30 4 5

10 20 30 40 50
20 11

*/
