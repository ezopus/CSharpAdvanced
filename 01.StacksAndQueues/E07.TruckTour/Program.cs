int numberOfPumps = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < numberOfPumps; i++)
{
    int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
    pumps.Enqueue(tokens);
}

int firstPump = 0;

while (true)
{

    int fuel = 0;
    foreach (int[] pump in pumps)
    {
        fuel += pump[0];
        int distance = pump[1];
        if (fuel - distance < 0)
        {
            fuel = -1;
            break;
        }
        else
        {
            fuel -= distance;
        }
    }
    if (fuel >= 0)
    {
        break;
    }
    firstPump++;
    pumps.Enqueue(pumps.Dequeue());
}

Console.WriteLine(firstPump);


/*
3
1 5
10 3
3 4
 */