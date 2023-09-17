int greenLight = int.Parse(Console.ReadLine());
int greenLightOriginal = greenLight;
int freeWindow = int.Parse(Console.ReadLine());
Queue<string> cars = new Queue<string>();
int totalCars = 0;
string input = "";
bool hasCrashHappened = false;

while ((input = Console.ReadLine()) != "END")
{
    greenLight = greenLightOriginal;
    if (input != "green")
    {
        cars.Enqueue(input);
    }
    else
    {
        while (greenLight > 0 && cars.Any())
        {
            if (greenLight - cars.Peek().Length >= 0)
            {
                greenLight -= cars.Peek().Length;
                cars.Dequeue();
                totalCars++;
            }
            else
            {
                if ((greenLight + freeWindow) - cars.Peek().Length >= 0)
                {
                    cars.Dequeue();
                    totalCars++;
                    greenLight = 0;
                }
                else
                {
                    int crashIndex = cars.Peek().Length - greenLight - freeWindow;
                    char crashChar = cars.Peek()[cars.Peek().Length - crashIndex];
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{cars.Peek()} was hit at {crashChar}.");
                    return;
                }
            }
        }
    }

}
Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{totalCars} total cars passed the crossroads.");

/*
10
5
Mercedes
green
Mercedes
BMW
Skoda
green
END

9
3
Mercedes
Hummer
green
Hummer
Mercedes
green
END

10
5
Mercedes
Toyota
green
Pontiac
Mercedes
Skoda
Ferrari
green
Audi
green
END
*/