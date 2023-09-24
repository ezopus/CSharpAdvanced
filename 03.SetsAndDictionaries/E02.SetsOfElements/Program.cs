HashSet<int> first = new HashSet<int>();
HashSet<int> second = new HashSet<int>();
int[] totalLength = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int firstLength = totalLength[0];
int secondLength = totalLength[1];

for (int i = 1; i <= firstLength + secondLength; i++)
{
    int input = int.Parse(Console.ReadLine());
    if (i <= firstLength)
    {
        first.Add(input);
    }
    else
    {
        second.Add(input);
    }
}

// foreach (int number in second)
// {
//     if (first.Contains(number))
//     {
//         Console.Write(number + " ");
//     }
// }

first.IntersectWith(second);

Console.WriteLine(string.Join(" ", first));


/*
4 3
1
3
5
7
3
4
5
*/