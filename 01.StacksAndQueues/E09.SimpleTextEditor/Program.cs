using System.Text;

StringBuilder sb = new StringBuilder();
Stack<string> states = new Stack<string>();
int numberOfOperations = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfOperations; i++)
{
    string[] tokens = Console.ReadLine()
        .Split();
    switch (tokens[0])
    {
        case "1":
            states.Push(sb.ToString());
            sb.Append(tokens[1]);
            break;
        case "2":
            states.Push(sb.ToString());
            int length = int.Parse(tokens[1]);
            sb.Remove(sb.Length - length, length);
            break;
        case "3":
            int index = int.Parse(tokens[1]);
            if (index <= sb.Length)
            {
                Console.WriteLine(sb[index - 1]);
            }
            break;
        case "4":
            sb.Clear();
            sb.Append(states.Pop());
            break;
    }
}
