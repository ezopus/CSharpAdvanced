int n = int.Parse(Console.ReadLine());
char[,] matrix = new char[n, n];

for (int i = 0; i < n; i++)
{
    char[] oneRow = Console.ReadLine().ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i, j] = oneRow[j];
    }
}

char match = char.Parse(Console.ReadLine());

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == match)
        {
            Console.WriteLine($"({i}, {j})");
            return;
        }
    }
}

Console.WriteLine($"{match} does not occur in the matrix");