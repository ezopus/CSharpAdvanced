char[] input = Console.ReadLine().ToCharArray();

Stack<char> stack = new (input);

foreach (char c in stack)
{
    Console.Write(c);
}