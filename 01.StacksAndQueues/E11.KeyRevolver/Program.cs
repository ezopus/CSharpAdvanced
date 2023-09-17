int bulletPrice = int.Parse(Console.ReadLine());
int barrelSize = int.Parse(Console.ReadLine());
Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
int reward = int.Parse(Console.ReadLine());

int shotsFired = 0;

while (bullets.Count > 0)
{
    int currentLock = locks.Peek();
    int currentBullet = bullets.Pop();

    if (currentBullet <= currentLock)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }
    shotsFired++;
    if (shotsFired % barrelSize == 0 && bullets.Any())
    {
        Console.WriteLine("Reloading!");
    }

    if (!locks.Any())
    {
        break;
    }
}

if (bullets.Count >= 0 && !locks.Any())
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${reward - shotsFired * bulletPrice}");
}
else
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}


/*
50
2
11 10 5 11 10 20
15 13 16
1500

20
6
14 13 12 11 10 5
13 3 11 10
800

33
1
12 11 10
10 20 30
100

*/
