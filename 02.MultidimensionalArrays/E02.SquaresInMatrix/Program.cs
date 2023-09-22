int[] elements = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = elements[0];
int cols = elements[1];

string[,] matrix = new string[rows, cols];

for (int i = 0; i < rows; i++)
{
    string[] inputRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    for (int j = 0; j < inputRow.Length; j++)
    {
        matrix[i, j] = inputRow[j];
    }
}

int squares = 0;

for (int i = 0; i < rows - 1; i++)
{
    for (int j = 0; j < cols - 1; j++)
    {
        if (matrix[i, j] == matrix[i + 1, j] &&
            matrix[i, j] == matrix[i + 1, j + 1] &&
            matrix[i, j] == matrix[i, j + 1] &&
            matrix[i, j] == matrix[i + 1, j + 1])
        {
            squares++;
        }
    }
}

Console.WriteLine(squares);