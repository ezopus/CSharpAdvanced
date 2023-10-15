int[] fieldSize = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
char[,] field = new char[fieldSize[0], fieldSize[1]];

int mouseRow = -1;
int mouseCol = -1;
int cheeseOnField = 0;
int cheeseGathered = 0;

for (int i = 0; i < fieldSize[0]; i++)
{
    char[] row = Console.ReadLine().ToCharArray();
    for (int j = 0; j < row.Length; j++)
    {
        field[i, j] = row[j];

        if (row[j] == 'M')
        {
            mouseRow = i;
            mouseCol = j;
            field[mouseRow, mouseCol] = '*';
        }
        if (row[j] == 'C')
        {
            cheeseOnField++;
        }
    }
}

bool isTrapped = false;
string input;
while ((input = Console.ReadLine()) != "danger")
{
    int currentRow = mouseRow;
    int currentCol = mouseCol;
    switch (input)
    {
        case "up":
            currentRow--;
            break;
        case "down":
            currentRow++;
            break;
        case "right":
            currentCol++;
            break;
        case "left":
            currentCol--;
            break;
    }
    if (IsMoveValid(currentRow, currentCol))
    {
        if (field[currentRow, currentCol] == '@')
        {
            continue;
        }
        field[mouseRow, mouseCol] = '*';
        MouseMove(currentRow, currentCol);
    }
    else
    {
        Console.WriteLine("No more cheese for tonight!");
        break;
    }

    if (cheeseOnField <= 0)
    {
        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
        break;
    }

    if (isTrapped)
    {
        Console.WriteLine("Mouse is trapped!");
        break;
    }
}

if (input == "danger")
{
    Console.WriteLine("Mouse will come back later!");
}

field[mouseRow, mouseCol] = 'M';
PrintMatrix(field);

bool IsMoveValid(int currentRow, int currentCol)
{
    if (currentRow >= 0 && currentRow < field.GetLength(0) && currentCol >= 0 && currentCol < field.GetLength(1))
    {
        return true;
    }
    return false;
}

void MouseMove(int currentRow, int currentCol)
{
    if (field[currentRow, currentCol] == 'C')
    {
        cheeseOnField--;
    }
    else if (field[currentRow, currentCol] == 'T')
    {
        isTrapped = true;
    }
    field[currentRow, currentCol] = 'M';
    mouseRow = currentRow;
    mouseCol = currentCol;
}

void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(field[row, col]);
        }
        Console.WriteLine();
    }
}


/*
5,5
**M**
T@@**
CC@**
**@@*
**CC*
left
down
left
down
down
down
right
danger

4,8
CC@**C*M
T*@**CT*
**@@@@**
T***C***
down
right
left
down
left
danger

6,3
@CC
@TC
@C*
@M*
@**
@**
left
up
left
right
up
up
left
left
danger
*/