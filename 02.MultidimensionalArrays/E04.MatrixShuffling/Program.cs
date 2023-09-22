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

string input = "";
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split();
    if (tokens[0].ToLower() == "swap" && tokens.Length == 5)
    {
        int rowFirst = int.Parse(tokens[1]);
        int colFirst = int.Parse(tokens[2]);
        int rowSecond = int.Parse(tokens[3]);
        int colSecond = int.Parse(tokens[4]);
        if (rowFirst >= 0 && rowFirst < matrix.GetLength(0) &&
            colFirst >= 0 && colFirst < matrix.GetLength(1) &&
            rowSecond >= 0 && rowSecond < matrix.GetLength(0) &&
            colSecond >= 0 && colSecond < matrix.GetLength(1)
           )
        {
            string swappable = matrix[rowFirst, colFirst];
            matrix[rowFirst, colFirst] = matrix[rowSecond, colSecond];
            matrix[rowSecond, colSecond] = swappable;
            PrintMatrix(matrix);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}

void PrintMatrix(string[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j] + " ");
        }

        Console.WriteLine();
    }
}