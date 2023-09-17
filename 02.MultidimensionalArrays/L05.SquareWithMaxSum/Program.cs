int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

int rows = input[0];
int cols = input[1];

int[,] matrix = new int[rows, cols];

for (int i = 0; i < rows; i++)
{
    int[] inputRows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = inputRows[j];
    }
}

int maxSum = 0;
int maxRow = 0;
int maxCol = 0;

for (int i = 0; i < matrix.GetLength(0) - 1; i++)
{
    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
    {
        if (matrix[i, j] +
            matrix[i, j + 1] +
            matrix[i + 1, j] +
            matrix[i + 1, j + 1] > maxSum)
        {
            maxRow = i;
            maxCol = j;
            maxSum = matrix[i, j] +
                     matrix[i, j + 1] +
                     matrix[i + 1, j] +
                     matrix[i + 1, j + 1];
        }
    }
}

Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
Console.WriteLine(maxSum);