
int rows = int.Parse(Console.ReadLine());

double[][] matrix = new double[rows][];

for (int i = 0; i < rows; i++)
{
    double[] cols = Console
        .ReadLine()
        .Split(' ')
        .Select(double.Parse)
        .ToArray();
    matrix[i] = new double[cols.Length];
    matrix[i] = cols;
}

CheckMatrix(matrix);

string input = "";
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    int row = int.Parse(tokens[1]);
    int col = int.Parse(tokens[2]);
    double value = double.Parse(tokens[3]);
    if (command == "Add")
    {
        if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
        {
            matrix[row][col] += value;
        }
    }
    else if (command == "Subtract")
    {
        if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
        {
            matrix[row][col] -= value;
        }
    }

}

PrintMatrix(matrix);
void PrintMatrix(double[][] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix[i].GetLength(0); j++)
        {
            Console.Write(matrix[i][j] + " ");
        }

        Console.WriteLine();
    }
}

void CheckMatrix(double[][] matrix)
{
    for (int i = 0; i < rows - 1; i++)
    {
        if (matrix[i].Length == matrix[i + 1].Length)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] *= 2;
            }
            for (int j = 0; j < matrix[i + 1].Length; j++)
            {
                matrix[i + 1][j] *= 2;
            }
        }
        else
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] /= 2;
            }
            for (int j = 0; j < matrix[i + 1].Length; j++)
            {
                matrix[i + 1][j] /= 2;
            }

        }
    }
}