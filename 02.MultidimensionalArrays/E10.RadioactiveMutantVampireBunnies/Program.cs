int[] fieldSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int fieldRows = fieldSize[0];
int fieldCols = fieldSize[1];

char[,] field = new char[fieldRows, fieldCols];

//initialize player
int playerRow = 0;
int playerCol = 0;
bool isAlive = true;
bool hasWon = false;

//read field info
for (int rows = 0; rows < fieldRows; rows++)
{
    string oneRow = Console.ReadLine();
    for (int cols = 0; cols < fieldCols; cols++)
    {
        if (oneRow[cols] == 'P')
        {
            playerRow = rows;
            playerCol = cols;
        }
        field[rows, cols] = oneRow[cols];
    }
}

//read commands
string commands = Console.ReadLine();
int commandCounter = 0;

//game start
while (isAlive && !hasWon)
{
    //get current command
    char currentCommand = commands[commandCounter++];

    //player move
    PlayerStep(ref playerRow, ref playerCol, field, currentCommand, ref isAlive, ref hasWon);

    //find all current bunnies
    Queue<int[]> bunnies = new Queue<int[]>();
    for (int row = 0; row < fieldRows; row++)
    {
        for (int col = 0; col < fieldCols; col++)
        {
            if (field[row, col] == 'B')
            {
                int[] currentBunny = new int[2];
                bunnies.Enqueue(currentBunny);
            }
        }
    }

    //bunny spread
    while(bunnies.Any())
    {
        int[] bunny = bunnies.Dequeue();
        int bunnyRow = bunny[0];
        int bunnyCol = bunny[1];
        BunnySpread(field, bunnyRow, bunnyCol);
    }
}

for (int row = 0; row < fieldRows; row++)
{
    for (int col = 0; col < fieldCols; col++)
    {
        Console.Write(field[row, col]);
    }

    Console.WriteLine();
}

if (hasWon)
{
    Console.WriteLine($"won: {playerRow} {playerCol}");
}
else
{
    Console.WriteLine($"dead: {playerRow} {playerCol}");
}

void PlayerStep(ref int playerRow, ref int playerCol, char[,] field, char command, ref bool isAlive, ref bool hasWon)
{
    switch (command)
    {
        case 'U':
            if (playerRow - 1 >= 0)
            {
                if (field[playerRow - 1, playerCol] != 'B')
                {
                    field[playerRow - 1, playerCol] = 'P';
                    field[playerRow, playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                }
                playerRow -= 1;
            }
            else
            {
                hasWon = true;
            }
            break;
        case 'D':
            if (playerRow + 1 < fieldRows)
            {
                if (field[playerRow + 1, playerCol] != 'B')
                {
                    field[playerRow + 1, playerCol] = 'P';
                    field[playerRow, playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                }
                playerRow += 1;
            }
            else
            {
                hasWon = true;
            }
            break;
        case 'L':
            if (playerCol - 1 >= 0)
            {
                if (field[playerRow, playerCol - 1] != 'B')
                {
                    field[playerRow, playerCol - 1] = 'P';
                    field[playerRow, playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                }
                playerCol -= 1;
            }
            else
            {
                hasWon = true;
            }
            break;
        case 'R':
            if (playerCol + 1 < fieldCols)
            {
                if (field[playerRow, playerCol + 1] != 'B')
                {
                    field[playerRow, playerCol + 1] = 'P';
                    field[playerRow, playerCol] = '.';
                }
                else
                {
                    isAlive = false;
                }
                playerCol += 1;
            }
            else
            {
                hasWon = true;
            }
            break;
    }
}

void BunnySpread(char[,] field, int currentBunnyRow, int currentBunnyCol)
{
    //up left
    if (currentBunnyRow - 1 >= 0 &&
        currentBunnyCol - 1 >= 0 &&
        field[currentBunnyRow - 1, currentBunnyCol - 1] != 'B')
    {
        field[currentBunnyRow - 1, currentBunnyCol - 1] = 'B';
    }
    //up mid
    if (currentBunnyRow - 1 >= 0 &&
        field[currentBunnyRow - 1, currentBunnyCol] != 'B')
    {
        field[currentBunnyRow - 1, currentBunnyCol] = 'B';
    }
    //up right
    if (currentBunnyRow - 1 >= 0 &&
        currentBunnyCol + 1 < field.GetLength(1) &&
        field[currentBunnyRow - 1, currentBunnyCol + 1] != 'B')
    {
        field[currentBunnyRow - 1, currentBunnyCol + 1] = 'B';
    }
    //left
    if (currentBunnyCol - 1 >= 0 &&
        field[currentBunnyRow, currentBunnyCol - 1] != 'B')
    {
        field[currentBunnyRow, currentBunnyCol - 1] = 'B';
    }
    //right
    if (currentBunnyCol + 1 < field.GetLength(1) &&
        field[currentBunnyRow, currentBunnyCol + 1] != 'B')
    {
        field[currentBunnyRow, currentBunnyCol + 1] = 'B';
    }
    //down left
    if (currentBunnyRow + 1 < field.GetLength(0) &&
        currentBunnyCol - 1 >= 0 &&
        field[currentBunnyRow + 1, currentBunnyCol - 1] != 'B')
    {
        field[currentBunnyRow + 1, currentBunnyCol - 1] = 'B';
    }
    //down mid
    if (currentBunnyRow + 1 < field.GetLength(0) &&
        field[currentBunnyRow + 1, currentBunnyCol] != 'B')
    {
        field[currentBunnyRow + 1, currentBunnyCol] = 'B';
    }
    //down right
    if (currentBunnyRow + 1 < field.GetLength(0) &&
        currentBunnyCol + 1 < field.GetLength(1) &&
        field[currentBunnyRow + 1, currentBunnyCol + 1] != 'B')
    {
        field[currentBunnyRow + 1, currentBunnyCol + 1] = 'B';
    }
}

/*
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

4 5
.....
.....
.B...
...P.
LLLLLLLL
 */