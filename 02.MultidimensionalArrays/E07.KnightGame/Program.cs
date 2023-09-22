int boardSize = int.Parse(Console.ReadLine());

char[,] board = new char[boardSize, boardSize];

for (int rows = 0; rows < boardSize; rows++)
{
    string oneRow = Console.ReadLine();

    for (int cols = 0; cols < boardSize; cols++)
    {
        board[rows, cols] = oneRow[cols];
    }
}

int minimumKnights = 0;
int maxAttacks = 0;
int maxAttackRow = 0;
int maxAttackCol = 0;

while (true)
{
    int attacks = 0;
    for (int row = 0; row < boardSize; row++)
    {
        for (int col = 0; col < boardSize; col++)
        {
            char currentTile = board[row, col];
            if (currentTile == 'K')
            {
                if ((attacks = CheckAttacks(board, row, col, boardSize)) > 0)
                {
                    if (attacks > maxAttacks)
                    {
                        maxAttackRow = row;
                        maxAttackCol = col;
                        maxAttacks = attacks;
                    }
                }
            }
        }
    }

    if (maxAttacks != 0)
    {
        board[maxAttackRow, maxAttackCol] = '0';
        minimumKnights++;
        maxAttacks = 0;
    }
    else
    {
        break;
    }
}

Console.WriteLine(minimumKnights);
static int CheckAttacks(char[,] board, int row, int col, int boardSize)
{
    int attacks = 0;
    if (col - 2 >= 0 && row - 1 >= 0 && board[row - 1, col - 2] == 'K') //left, up
    {
        attacks++;
    }
    if (col - 2 >= 0 && row + 1 < boardSize && board[row + 1, col - 2] == 'K') //left, down
    {
        attacks++;
    }
    if (col + 2 < boardSize && row - 1 >= 0 && board[row - 1, col + 2] == 'K') //right, up
    {
        attacks++;
    }
    if (col + 2 < boardSize && row + 1 < boardSize && board[row + 1, col + 2] == 'K') //right, down
    {
        attacks++;
    }
    if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2, col - 1] == 'K') //up, left
    {
        attacks++;
    }
    if (row - 2 >= 0 && col + 1 < boardSize && board[row - 2, col + 1] == 'K') //up, right
    {
        attacks++;
    }
    if (row + 2 < boardSize && col - 1 >= 0 && board[row + 2, col - 1] == 'K') //down, left
    {
        attacks++;
    }
    if (row + 2 < boardSize && col + 1 < boardSize && board[row + 2, col + 1] == 'K') //down, right
    {
        attacks++;
    }

    return attacks;
}