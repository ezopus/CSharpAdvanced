int fieldSize = int.Parse(Console.ReadLine());
int[,] field = new int[fieldSize, fieldSize];

for (int rows = 0; rows < fieldSize; rows++)
{
    int[] oneRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    for (int cols = 0; cols < fieldSize; cols++)
    {
        field[rows, cols] = oneRow[cols];
    }
}

Queue<string> bombs = new Queue<string>(Console
    .ReadLine()
    .Split(" ")
    .ToArray()
    );

while (bombs.Any())
{
    string[] currentBomb = bombs.Dequeue().Split(",");
    int currentBombRow = int.Parse(currentBomb[0]);
    int currentBombCol = int.Parse(currentBomb[1]);
    int value = field[currentBombRow, currentBombCol];

    if (field[currentBombRow, currentBombCol] <= 0)
    {
        continue;
    }

    //up left
    if (currentBombRow - 1 >= 0 &&
        currentBombCol - 1 >= 0 &&
        field[currentBombRow - 1, currentBombCol - 1] > 0)
    {
        field[currentBombRow - 1, currentBombCol - 1] -= value;
    }
    //up mid
    if (currentBombRow - 1 >= 0 &&
        field[currentBombRow - 1, currentBombCol] > 0)
    {
        field[currentBombRow - 1, currentBombCol] -= value;
    }
    //up right
    if (currentBombRow - 1 >= 0 &&
        currentBombCol + 1 < fieldSize &&
        field[currentBombRow - 1, currentBombCol + 1] > 0)
    {
        field[currentBombRow - 1, currentBombCol + 1] -= value;
    }
    //left
    if (currentBombCol - 1 >= 0 &&
        field[currentBombRow, currentBombCol - 1] > 0)
    {
        field[currentBombRow, currentBombCol - 1] -= value;
    }
    //bomb
    if (field[currentBombRow, currentBombCol] > 0)
    {
        field[currentBombRow, currentBombCol] -= value;
    }
    //right
    if (currentBombCol + 1 < fieldSize &&
        field[currentBombRow, currentBombCol + 1] > 0)
    {
        field[currentBombRow, currentBombCol + 1] -= value;
    }
    //down left
    if (currentBombRow + 1 < fieldSize &&
        currentBombCol - 1 >= 0 &&
        field[currentBombRow + 1, currentBombCol - 1] > 0)
    {
        field[currentBombRow + 1, currentBombCol - 1] -= value;
    }
    //down mid
    if (currentBombRow + 1 < fieldSize &&
        field[currentBombRow + 1, currentBombCol] > 0)
    {
        field[currentBombRow + 1, currentBombCol] -= value;
    }
    //down right
    if (currentBombRow + 1 < fieldSize &&
        currentBombCol + 1 < fieldSize &&
        field[currentBombRow + 1, currentBombCol + 1] > 0)
    {
        field[currentBombRow + 1, currentBombCol + 1] -= value;
    }

}

int sumAlive = 0;
int totalAlive = 0;
for (int row = 0; row < fieldSize; row++)
{
    for (int col = 0; col < fieldSize; col++)
    {
        if (field[row, col] > 0)
        {
            sumAlive += field[row, col];
            totalAlive++;
        }
    }
}

Console.WriteLine($"Alive cells: {totalAlive}");
Console.WriteLine($"Sum: {sumAlive}");

for (int row = 0; row < fieldSize; row++)
{
    for (int col = 0; col < fieldSize; col++)
    {
        Console.Write(field[row, col] + " ");
    }

    Console.WriteLine();
}
