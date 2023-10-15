using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace E02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeCol = 0;
            int foodEaten = 0;
            Dictionary<int, int> burrows = new Dictionary<int, int>();

            char[,] field = new char[sizeOfField, sizeOfField];

            //fill field
            for (int row = 0; row < sizeOfField; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    field[row, col] = currentRow[col];
                    if (currentRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if (currentRow[col] == 'B')
                    {
                        burrows.Add(row, col);
                    }
                }
            }

            //snake move
            bool isAlive = true;
            while (isAlive && foodEaten < 10)
            {
                string move = Console.ReadLine();
                field = SnakeMove(field, move);
            }

            //output
            if (isAlive && foodEaten >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else if (!isAlive)
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

            PrintMatrix(field);

            //move logic
            char[,] SnakeMove(char[,] field, string direction)
            {
                switch (direction)
                {
                    case "up":
                        if (snakeRow - 1 >= 0)
                        {
                            if (field[snakeRow - 1, snakeCol] == '*')
                            {
                                foodEaten++;
                            }
                            else if (field[snakeRow - 1, snakeCol] == 'B')
                            {
                                field = Burrow(field);
                                break;
                            }
                            field[snakeRow, snakeCol] = '.';
                            field[snakeRow - 1, snakeCol] = 'S';
                            snakeRow -= 1;
                        }
                        else
                        {
                            field[snakeRow, snakeCol] = '.';
                            isAlive = false;
                        }
                        break;
                    case "down":
                        if (snakeRow + 1 < field.GetLength(0))
                        {
                            if (field[snakeRow + 1, snakeCol] == '*')
                            {
                                foodEaten++;
                            }
                            else if (field[snakeRow + 1, snakeCol] == 'B')
                            {
                                field = Burrow(field);
                                break;
                            }
                            field[snakeRow, snakeCol] = '.';
                            field[snakeRow + 1, snakeCol] = 'S';
                            snakeRow += 1;
                        }
                        else
                        {
                            field[snakeRow, snakeCol] = '.';
                            isAlive = false;
                        }
                        break;
                    case "left":
                        if (snakeCol - 1 >= 0)
                        {
                            if (field[snakeRow, snakeCol - 1] == '*')
                            {
                                foodEaten++;
                            }
                            else if (field[snakeRow, snakeCol - 1] == 'B')
                            {
                                field = Burrow(field);
                                break;
                            }
                            field[snakeRow, snakeCol] = '.';
                            field[snakeRow, snakeCol - 1] = 'S';
                            snakeCol -= 1;
                        }
                        else
                        {
                            field[snakeRow, snakeCol] = '.';
                            isAlive = false;
                        }
                        break;
                    case "right":
                        if (snakeCol + 1 < field.GetLength(1))
                        {
                            if (field[snakeRow, snakeCol + 1] == '*')
                            {
                                foodEaten++;
                            }
                            else if (field[snakeRow, snakeCol + 1] == 'B')
                            {
                                field = Burrow(field);
                                break;
                            }
                            field[snakeRow, snakeCol] = '.';
                            field[snakeRow, snakeCol + 1] = 'S';
                            snakeCol += 1;
                        }
                        else
                        {
                            field[snakeRow, snakeCol] = '.';
                            isAlive = false;
                        }
                        break;
                }
                return field;
            }

            char[,] Burrow(char[,] field)
            {
                field[snakeRow, snakeCol] = '.';
                foreach (var kp in burrows)
                {
                    field[kp.Key, kp.Value] = '.';
                }
                snakeRow = burrows.Last().Key;
                snakeCol = burrows.Last().Value;
                field[snakeRow, snakeCol] = 'S';
                return field;
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
        }

    }
}

/*
6
-----S
----B-
------
------
--B---
--*---
left
down
down
down
left

7
--***S-
--*----
--***--
---**--
---*---
---*---
---*---
left
left
left
down
down
right
right
down
left
down
 */