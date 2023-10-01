Func<List<int>, string, List<int>> actions = (numbers, operation) =>
{
    List<int> result = new();
    foreach (int number in numbers)
    {
        switch (operation)
        {
            case "add":
                result.Add(number + 1);
                break;
            case "multiply":
                result.Add(number * 2);
                break;
            case "subtract":
                result.Add(number - 1);
                break;
        }
    }
    return result;
};

List<int> input = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Action<List<int>> print = numbers =>
{
    Console.WriteLine(string.Join(" ", numbers));
};

string command;
while ((command = Console.ReadLine()) != "end")
{
    if (command == "print")
    {
        print(input);
    }
    else
    {
        input = actions(input, command);
    }
}