int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

int rows = input[0];
int cols = input[1];

int[,] matrix = new int[rows, cols];
int sum = 0;


for (int i = 0; i < rows; i++)
{
    int[] inputRows = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
    for (int j = 0; j < cols; j++)
    {
        matrix[i, j] = inputRows[j];
        sum += matrix[i, j];
    }
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sum);

