int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];
int sumMainDiagonal = 0;
int sumReverseDiagonal = 0;

for (int i = 0; i < matrixSize; i++)
{
    int[] inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

    for (int j = 0; j < inputRow.Length; j++)
    {
        matrix[i, j] = inputRow[j];
    }
}

for (int rows = 0; rows < matrix.GetLength(0); rows++)
{
    for (int cols = 0; cols < matrix.GetLength(1); cols++)
    {
        if (rows == cols)
        {
            sumMainDiagonal += matrix[rows, cols ];
        }

        if (cols == matrix.GetLength(1) - 1 - rows)
        {
            sumReverseDiagonal += matrix[rows, cols];
        }
    }
}


Console.WriteLine(Math.Abs(sumMainDiagonal - sumReverseDiagonal));