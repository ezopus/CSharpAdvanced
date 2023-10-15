using System;

namespace E02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            int pollinatedFlowers = 0;

            for (int i = 0; i < n; i++)
            {
                string oneRow = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = oneRow[j];
                    if (field[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                        field[i, j] = '.';
                    }
                }
            }

            bool isLost = false;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int currentRow = beeRow;
                int currentCol = beeCol;
                field[beeRow, beeCol] = '.';
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

                if (IsValid(currentRow, currentCol, field))
                {
                    if (field[currentRow, currentCol] == 'f')
                    {
                        field[currentRow, currentCol] = 'B';
                        pollinatedFlowers++;
                    }
                    else if (field[currentRow, currentCol] == 'O')
                    {
                        field[currentRow, currentCol] = '.';
                        if (command == "up") currentRow--;
                        if (command == "down") currentRow++;
                        if (command == "left") currentCol--;
                        if (command == "right") currentCol++;
                        if (field[currentRow, currentCol] == 'f')
                        {
                            field[currentRow, currentCol] = 'B';
                            pollinatedFlowers++;
                        }
                    }
                    beeRow = currentRow;
                    beeCol = currentCol;
                }
                else
                {
                    isLost = true;
                    break;
                }
            }

            if (isLost)
            {
                field[beeRow, beeCol] = '.';
                Console.WriteLine("The bee got lost!");
            }
            else
            {
                field[beeRow, beeCol] = 'B';
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            PrintMatrix(field);
        }
        public static bool IsValid(int currentRow, int currentCol, char[,] field)
        {
            return currentRow >= 0 && currentRow < field.GetLength(0) && currentCol >= 0 && currentCol < field.GetLength(1);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}