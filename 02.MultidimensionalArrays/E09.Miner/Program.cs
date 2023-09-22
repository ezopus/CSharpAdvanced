int fieldSize = int.Parse(Console.ReadLine());

char[,] field = new char[fieldSize, fieldSize];

string[] commands = Console.ReadLine().Split(" ");

int totalCoal = 0;

//get field info
for (int rows = 0; rows < fieldSize; rows++)
{
    char[] oneRow = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
    for (int cols = 0; cols < fieldSize; cols++)
    {
        if (oneRow[cols] == 'c')
        {
            totalCoal++;
        }
        field[rows, cols] = oneRow[cols];
    }
}

int minerRow = 0;
int minerCol = 0;

// get miner starting position
for (int rows = 0; rows < fieldSize; rows++)
{
    for (int cols = 0; cols < fieldSize; cols++)
    {
        if (field[rows, cols] == 's')
        {
            minerRow = rows;
            minerCol = cols;
        }
    }
}

int coalGathered = 0;
bool hasAllCoal = false;

for (int i = 0; i < commands.Length; i++)
{
    switch (commands[i])
    {
        case "up":
            if (minerRow - 1 >= 0)
            {
                if (field[minerRow - 1, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow - 1}, {minerCol})");
                    return;
                }
                if (field[minerRow - 1, minerCol] == 'c')
                {
                    coalGathered++;
                }
                field[minerRow, minerCol] = '*';
                field[minerRow - 1, minerCol] = 's';
                minerRow -= 1;
                hasAllCoal = CoalCheck(coalGathered, totalCoal);
            }
            break;
        case "down":
            if (minerRow + 1 < fieldSize)
            {
                if (field[minerRow + 1, minerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow + 1}, {minerCol})");
                    return;
                }
                if (field[minerRow + 1, minerCol] == 'c')
                {
                    coalGathered++;
                }
                field[minerRow, minerCol] = '*';
                field[minerRow + 1, minerCol] = 's';
                minerRow += 1;
                hasAllCoal = CoalCheck(coalGathered, totalCoal);
            }
            break;
        case "left":
            if (minerCol - 1 >= 0)
            {
                if (field[minerRow, minerCol - 1] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol - 1})");
                    return;
                }
                if (field[minerRow, minerCol - 1] == 'c')
                {
                    coalGathered++;
                }
                field[minerRow, minerCol] = '*';
                field[minerRow, minerCol - 1] = 's';
                minerCol -= 1;
                hasAllCoal = CoalCheck(coalGathered, totalCoal);
            }
            break;
        case "right":
            if (minerCol + 1 < fieldSize)
            {
                if (field[minerRow, minerCol + 1] == 'e')
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol + 1})");
                    return;
                }
                if (field[minerRow, minerCol + 1] == 'c')
                {
                    coalGathered++;
                }
                field[minerRow, minerCol] = '*';
                field[minerRow, minerCol + 1] = 's';
                minerCol += 1;
                hasAllCoal = CoalCheck(coalGathered, totalCoal);
            }
            break;
    }

    if (hasAllCoal)
    {
        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
        return;
    }
}

if (coalGathered < totalCoal)
{
    Console.WriteLine($"{totalCoal - coalGathered} coals left. ({minerRow}, {minerCol})");
}

bool CoalCheck(int coalGathered, int totalCoal)
{
    if (coalGathered == totalCoal)
    {
        return true;
    }
    return false;
}

