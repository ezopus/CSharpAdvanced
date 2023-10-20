using System;
using System.Linq;

namespace E02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];
            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int boarTrufflesEaten = 0;

            for (int i = 0; i < size; i++)
            {
                char[] oneRow = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < oneRow.Length; j++)
                {
                    forest[i, j] = oneRow[j];
                }

            }

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int currentRow = int.Parse(tokens[1]);
                int currentCol = int.Parse(tokens[2]);
                string direction = "";
                if (tokens[0] == "Collect")
                {
                    if (forest[currentRow, currentCol] == 'B')
                    {
                        blackTruffles++;
                    }
                    else if (forest[currentRow, currentCol] == 'S')
                    {
                        summerTruffles++;
                    }
                    else if (forest[currentRow, currentCol] == 'W')
                    {
                        whiteTruffles++;
                    }

                    forest[currentRow, currentCol] = '-';
                }
                else
                {
                    direction = tokens[3];
                    switch (direction)
                    {
                        case "up":
                            for (int i = currentRow; i >= 0; i -= 2)
                            {
                                if (forest[i, currentCol] != '-')
                                {
                                    boarTrufflesEaten++;
                                    forest[i, currentCol] = '-';
                                }
                            }
                            break;
                        case "down":
                            for (int i = currentRow; i < size; i += 2)
                            {
                                if (forest[i, currentCol] != '-')
                                {
                                    boarTrufflesEaten++;
                                    forest[i, currentCol] = '-';
                                }
                            }
                            break;
                        case "right":
                            for (int i = currentCol; i < size; i += 2)
                            {
                                if (forest[currentRow, i] != '-')
                                {
                                    boarTrufflesEaten++;
                                    forest[currentRow, i] = '-';
                                }
                            }
                            break;
                        case "left":
                            for (int i = currentCol; i >= 0; i -= 2)
                            {
                                if (forest[currentRow, i] != '-')
                                {
                                    boarTrufflesEaten++;
                                    forest[currentRow, i] = '-';
                                }
                            }
                            break;
                    }
                    forest[currentRow, currentCol] = '-';

                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTrufflesEaten} truffles.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(forest[i, j] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}


/*
5
B W S - -
S S B W W
S S - W B
B B S - W
S S - - -
Collect 0 2
Collect 3 0
Collect 4 2
Collect 3 4
Collect 2 3
Wild_Boar 2 2 up
Wild_Boar 1 1 right
Stop the hunt
 */