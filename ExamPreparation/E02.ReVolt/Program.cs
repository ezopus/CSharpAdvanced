using System;

namespace E02.ReVolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int countOfCommands = int.Parse(Console.ReadLine());

            int playerRow = 0;
            int playerCol = 0;

            for (int i = 0; i < n; i++)
            {
                char[] oneRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = oneRow[j];
                    if (field[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                        field[i, j] = '-';
                    }
                }
            }

            bool hasWon = false;

            while (countOfCommands >= 0 && !hasWon)
            {
                string command = Console.ReadLine();

                int currentRow = playerRow;
                int currentCol = playerCol;

                switch (command)
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

                if (IsInRange(field, currentRow, currentCol))
                {
                    if (field[currentRow, currentCol] == 'F')
                    {
                        hasWon = true;
                        field[currentRow, currentCol] = 'f';
                        break;
                    }
                    if (field[currentRow, currentCol] == 'B')
                    {
                        BonusField(ref currentRow, ref currentCol, command);
                        if (!IsInRange(field, currentRow, currentCol))
                        {
                            WarpPlayer(field, ref currentRow, ref currentCol);
                        }
                    }
                    if (field[currentRow, currentCol] == 'T')
                    {
                        TrapField(ref currentRow, ref currentCol, command);
                        if (!IsInRange(field, currentRow, currentCol))
                        {
                            WarpPlayer(field, ref currentRow, ref currentCol);
                        }
                    }
                }
                else
                {
                    WarpPlayer(field, ref currentRow, ref currentCol);
                }
                playerRow = currentRow;
                playerCol = currentCol;
                countOfCommands--;
            }
            if (hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                field[playerRow, playerCol] = 'f';
                Console.WriteLine("Player lost!");
            }

            PrintMatrix(field);


            void WarpPlayer(char[,] field, ref int currentRow, ref int currentCol)
            {
                if (currentRow >= field.GetLength(0))
                {
                    currentRow = 0;
                }
                else if (currentRow < 0)
                {
                    currentRow = field.GetLength(0) - 1;
                }

                if (currentCol >= field.GetLength(1))
                {
                    currentCol = 0;
                }
                else if (currentCol < 0)
                {
                    currentCol = field.GetLength(1) - 1;
                }
            }

            bool IsInRange(char[,] field, int currentRow, int currentCol)
            {
                return currentRow >= 0 && currentRow < field.GetLength(0) && currentCol >= 0 && currentCol < field.GetLength(1);
            }

            void BonusField(ref int currentRow, ref int currentCol, string command)
            {
                switch (command)
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
            }

            void TrapField(ref int currentRow, ref int currentCol, string command)
            {
                switch (command)
                {
                    case "up":
                        currentRow++;
                        break;
                    case "down":
                        currentRow--;
                        break;
                    case "left":
                        currentCol++;
                        break;
                    case "right":
                        currentCol--;
                        break;
                }
            }

            void PrintMatrix(char[,] field)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        Console.Write(field[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}


/*
5
5
-----
-f---
-B---
--T--
-F---
down
right
down

4
3
----
-f-B
--T-
---F
up
up
left
*/