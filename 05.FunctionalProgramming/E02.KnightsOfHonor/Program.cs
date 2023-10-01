Action<string[]> printer = (string[] input) =>
{
    foreach (string s in input)
    {
        Console.WriteLine("Sir " + s);
    }
};

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printer(input);