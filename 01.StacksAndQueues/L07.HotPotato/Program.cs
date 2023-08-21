Queue<string> players = new(
    Console.ReadLine()
        .Split()
        .ToArray());
int potatoNumber = int.Parse(Console.ReadLine());

while (players.Count > 1)
{
    for (int i = 1; i < potatoNumber; i++)
    {
        string playerName = players.Peek();
        players.Dequeue();
        players.Enqueue(playerName);
    }

    Console.WriteLine($"Removed {players.Peek()}");
    players.Dequeue();
}

Console.WriteLine($"Last is {players.Peek()}");