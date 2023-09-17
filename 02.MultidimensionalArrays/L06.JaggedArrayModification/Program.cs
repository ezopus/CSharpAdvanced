using System.Globalization;

int rows = int.Parse(Console.ReadLine());
int[][] matrix = new int[rows][];

for (int i = 0; i < rows; i++)
{
    int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
    matrix[i] = new int[row.Length];
    for (int j = 0; j < row.Length; j++)
    {
        matrix[i][j] = row[j];
    }
}

string command = "";
while ((command = Console.ReadLine()) != "END")
{
    string[] input = command.Split();
    int rowCoordinate = int.Parse(input[1]);
    int colCoordinate = int.Parse(input[2]);
    int value = int.Parse(input[3]);
    if (rowCoordinate < 0 || colCoordinate < 0 ||
        rowCoordinate >= matrix.Length || matrix[rowCoordinate].Length <= colCoordinate)
    {
        Console.WriteLine("Invalid coordinates");
    }
    else if (input[0] == "Add")
    {
        matrix[rowCoordinate][colCoordinate] += value;
    }
    else
    {
        matrix[rowCoordinate][colCoordinate] -= value;
    }
}

for (int i = 0; i < matrix.Length; i++)
{
    for (int j = 0; j < matrix[i].Length; j++)
    {
        Console.Write(matrix[i][j] + " ");
    }
    Console.WriteLine();
}


/*
4
1 2 3 4
5
8 7 6 5
4 3 2 1
Add 4 4 100
Add 3 3 100
Subtract -1 -1 42
Subtract 0 0 42
END

3
1 2 3
4 5 6 7
8 9 10
Add 0 0 5
Subtract 1 2 2
Subtract 1 4 7
END
*/
