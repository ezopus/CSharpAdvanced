int[] elements = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = elements[0];
int cols = elements[1];

int[,] matrix = new int[rows, cols];

int[,] maxSumMatrix = new int[3, 3];
int maxSum = 0;
int[] maxSumIndex = new int[2];

for (int i = 0; i < rows; i++)
{
    int[] inputRow = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int j = 0; j < inputRow.Length; j++)
    {
        matrix[i, j] = inputRow[j];
    }
}


for (int i = 0; i < rows - 2; i++)
{
    for (int j = 0; j < cols - 2; j++)
    {
        int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                         matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                         matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            maxSumIndex[0] = i;
            maxSumIndex[1] = j;
        }
    }
}

Console.WriteLine("Sum = " + maxSum);
for (int i = maxSumIndex[0]; i <= maxSumIndex[0] + 2; i++)
{
    for (int j = maxSumIndex[1]; j <= maxSumIndex[1] + 2; j++)
    {
        Console.Write(matrix[i,j] + " ");
    }
    Console.WriteLine();
}