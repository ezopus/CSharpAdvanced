using System;

namespace E02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] armory = new char[size, size];
            int officerRow = 0;
            int officerCol = 0;

            for (int i = 0; i < size; i++)
            {
                string oneRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    armory[i, j] = oneRow[j];
                    if (oneRow[j] == 'A')
                    {
                        officerRow = i;
                        officerCol = j;
                        armory[i, j] = '-';
                    }
                }
            }

            int swords = 0;
            bool isOut = false;

            while (!isOut)
            {
                string command = Console.ReadLine();
                int currentRow = officerRow;
                int currentCol = officerCol;
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

                if (IsValid(currentRow, currentCol, armory))
                {
                    if (armory[currentRow, currentCol] == 'M')
                    {
                        armory[currentRow, currentCol] = '-';
                        
                        for (int i = 0; i < size; i++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (armory[i, j] == 'M' && (i != currentRow || j != currentCol))
                                {
                                    currentRow = i;
                                    currentCol = j;
                                    armory[i, j] = '-';
                                }
                            }
                        }
                    }

                    if (armory[currentRow, currentCol] != '-')
                    {
                        swords += int.Parse(armory[currentRow, currentCol].ToString());
                        armory[currentRow, currentCol] = '-';
                    }

                }
                else
                {
                    isOut = true;
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                officerRow = currentRow;
                officerCol = currentCol;

                if (swords >= 65)
                {
                    armory[officerRow, officerCol] = 'A';
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;

                }

            }

            Console.WriteLine($"The king paid {swords} gold coins.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsValid(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
