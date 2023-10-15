int[] inputField = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

char[,] field = new char[inputField[0],inputField[1]];

int boyRow = 0;
int boyCol = 0;

for (int i = 0; i < inputField[0]; i++)
{
    char[] row = Console.ReadLine().ToCharArray();
    for (int j = 0; j < inputField[1]; j++)
    {
        field[i, j] = row[j];
        if (row[j] == 'B')
        {
            boyRow = i;
            boyCol = j;
        }
    }
}

int boyStartRow = boyRow;
int boyStartCol = boyCol;

bool isLate = false;
bool isDelivered = false;

while (!isDelivered && !isLate)
{
    string token = Console.ReadLine();
    int currentRow = boyRow;
    int currentCol = boyCol;

    switch (token)
    {
        case "up":
            currentRow--;
            break;
        case "down":
            currentRow++;
            break;
        case "left":
            currentCol--;
            break;
        case "right":
            currentCol++;
            break;
    }

    if (IsPositionValid(field, currentRow, currentCol))
    {
        if (field[currentRow, currentCol] == 'P')
        {
            field[currentRow, currentCol] = 'R';
            Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
        }
        else if (field[currentRow, currentCol] == '*')
        {
            //boy remains in same position
            continue;
        }
        else if (field[currentRow, currentCol] == '-' || field[currentRow, currentCol] == '.')
        {
            field[currentRow, currentCol] = '.';
        }
        else if (field[currentRow, currentCol] == 'A')
        {
            field[currentRow, currentCol] = 'P';
            Console.WriteLine("Pizza is delivered on time! Next order...");
            isDelivered = true;
            break;
        }
        boyRow = currentRow;
        boyCol = currentCol;
    }
    else
    {
        field[boyStartCol, boyStartRow] = ' ';
        isLate = true;
        break;
    }
}

if (isLate)
{
    Console.WriteLine("The delivery is late. Order is canceled.");
}

PrintMatrix(field);

bool IsPositionValid(char[,] field, int row, int col)
{
    return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
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
5 6
*----A
*B***-
*-***-
*----P
******
down
down
right
right
right
right
up
up
up

5 6
*----A
*B***-
*-***-
*----P
******
down
down
left
right
right
right
right
right
up
*/
