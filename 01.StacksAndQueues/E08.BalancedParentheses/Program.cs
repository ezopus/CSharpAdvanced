string input = Console.ReadLine();
Stack<char> parentheses = new Stack<char>();

foreach (char c in input)
{
    parentheses.TryPeek(out var s);
    if (c == '(' || c == '[' || c == '{')
    {
        parentheses.Push(c);
        continue;
    }
    if (c == ')' && s == '(')
    {
        parentheses.Pop();
    }
    else if (c == ']' && s == '[')
    {
        parentheses.Pop();
    }
    else if (c == '}' && s == '{')
    {
        parentheses.Pop();
    }
    else
    {
        parentheses.Push(c);
    }
    
}

if (parentheses.Any())
{
    Console.WriteLine("NO");
}
else
{
    Console.WriteLine("YES");
}