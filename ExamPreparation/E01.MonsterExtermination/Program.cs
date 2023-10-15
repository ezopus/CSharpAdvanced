int[] armor = Console
    .ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] soldierStrikes = Console
    .ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> monsters = new Queue<int>(armor);
Stack<int> strikes = new Stack<int>(soldierStrikes);

int totalKilled = 0;

while (monsters.Any() && strikes.Any())
{
    int monster = monsters.Dequeue();
    int hit = strikes.Pop();
    if (hit >= monster)
    {
        totalKilled++;
        hit -= monster;
        if (hit > 0)
        {
            if (strikes.Any())
            {
                int remainder = strikes.Pop() + hit;
                strikes.Push(remainder);
            }
            else
            {
                strikes.Push(hit);
            }
        }
    }
    else
    {
        monster -= hit;
        monsters.Enqueue(monster);
    }
}

if (!monsters.Any())
{
    Console.WriteLine("All monsters have been killed!");
}

if (!strikes.Any())
{
    Console.WriteLine("The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {totalKilled}");

/*
20,15,10
5,15,10,25
 */

