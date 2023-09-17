string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
Queue<string> songQueue
    = new Queue<string>(songs);
while (songQueue.Any())
{
    string[] command = Console.ReadLine().Split();
    switch (command[0])
    {
        case "Play":
            songQueue.Dequeue();
            break;
        case "Add":
            string newSong = string.Join(" ", command.Skip(1));
            if (!songQueue.Contains(newSong))
            {
                songQueue.Enqueue(newSong);
            }
            else
            {
                Console.WriteLine($"{newSong} is already contained!");
            }
            break;
        case "Show":
            Console.WriteLine(string.Join(", ", songQueue));
            break;
    }
}

Console.WriteLine("No more songs!");

/*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play
*/