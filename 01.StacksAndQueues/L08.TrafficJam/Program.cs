int throughput = int.Parse(Console.ReadLine());
Queue<string> cars = new();
string input = "";
int counter = 0;

while ((input = Console.ReadLine()) != "end")
{
    if (input != "green")
    {
        cars.Enqueue(input);
    }
    else if (input == "green")
    {
        for (int i = 0; i < throughput && cars.Any(); i++)
        {
            Console.WriteLine($"{cars.Dequeue()} passed!");
            counter++;
        }
    }
}

Console.WriteLine($"{counter} cars passed the crossroads.");