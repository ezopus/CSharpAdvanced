string input = Console.ReadLine();

Stack<int> expressionStack = new ();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(')
    {
        expressionStack.Push(i);
    }
    else if (input[i] == ')')
    {
        int endIndex = i;
        int startIndex = expressionStack.Pop();
        string subexpression = input.Substring(startIndex, endIndex - startIndex + 1);
        Console.WriteLine(subexpression);
    }
}
