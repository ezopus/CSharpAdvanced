int[] elements = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = elements[0];
int cols = elements[1];

char[,] matrix = new char[rows, cols];

string snake = Console.ReadLine();

int charCounter = 0;
int rowCounter = 0;

while (rowCounter < rows)
{
    if (rowCounter % 2 == 0)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (charCounter >= snake.Length)
            {
                charCounter = 0;
            }
            matrix[rowCounter, i] = snake[charCounter];
            charCounter++;
        }
    }
    else
    {
        for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
        {
            if (charCounter >= snake.Length)
            {
                charCounter = 0;
            }
            matrix[rowCounter, i] = snake[charCounter];
            charCounter++;
        }
    }

    rowCounter++;
}

PrintMatrix(matrix);
void PrintMatrix(char[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j]);
        }

        Console.WriteLine();
    }
}