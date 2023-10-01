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
    int monster = monsters.Peek();
    int hit = strikes.Peek();
    while (monster > 0)
    {
        if (monster < hit)
        {
            monsters.Dequeue();
            totalKilled++;
            strikes.Pop();
            int remainingHitPoints = hit - monster;
            if (monsters.Any())
            {
                monster = monsters.Peek();
                if (monster - remainingHitPoints > 0)
                {
                    monster -= remainingHitPoints;
                }
            }
            else
            {
                break;
            }
        }
        else if (monster == strikes.Peek())
        {
            monsters.Dequeue();
            totalKilled++;
            strikes.Pop();
        }
        else
        {
            monster -= strikes.Pop();
            monsters.Enqueue(monsters.Dequeue());
            monster = monsters.Peek();
            if (strikes.Any())
            {
                hit = strikes.Peek();
            }
            else
            {
                break;
            }
        }
    }
}

if (!monsters.Any())
{
    Console.WriteLine("All monsters have been killed!");
}
else
{
    Console.WriteLine("The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {totalKilled}");



