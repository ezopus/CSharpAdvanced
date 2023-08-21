Stack<int> stack = new (
    Console.ReadLine()
        .Split()
        .Select(int.Parse));
string input = "";
while ((input = Console.ReadLine().ToLower()) != "end")
{
    string[] tokens = input.Split(' ');
    
    switch (tokens[0].ToLower())
    {
        case "add":
            int numberOne = int.Parse(tokens[1]);
            int numberTwo = int.Parse(tokens[2]);
            stack.Push(numberOne);
            stack.Push(numberTwo);
            break;
        case "remove":
            int count = int.Parse(tokens[1]);
            while (stack.Count - count >= 0 && stack.Any() && count > 0)
            {
                stack.Pop();
                count--;
            }
            break;
    }
}
Console.WriteLine("Sum: " + stack.Sum());