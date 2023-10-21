namespace E02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] fishingArea = new char[size, size];
            int myRow = 0;
            int myCol = 0;

            for (int i = 0; i < size; i++)
            {
                string oneRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    fishingArea[i, j] = oneRow[j];
                    if (oneRow[j] == 'S')
                    {
                        myRow = i;
                        myCol = j;
                        fishingArea[i, j] = '-';
                    }
                }
            }

            int gatheredFish = 0;
            bool hasFallen = false;
            string command;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                int currentRow = myRow;
                int currentCol = myCol;
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

                if (IsValid(currentRow, currentCol, fishingArea))
                {
                    if (fishingArea[currentRow, currentCol] != '-' && fishingArea[currentRow, currentCol] != 'W')
                    {
                        gatheredFish += int.Parse(fishingArea[currentRow, currentCol].ToString());
                        fishingArea[currentRow, currentCol] = '-';
                    }

                    if (fishingArea[currentRow, currentCol] == 'W')
                    {
                        hasFallen = true;
                        myRow = currentRow;
                        myCol = currentCol;
                        break;
                    }
                }
                else
                {
                    MoveToOppositeSide(ref currentRow, ref currentCol, fishingArea);
                    if (fishingArea[currentRow, currentCol] != '-' && fishingArea[currentRow, currentCol] != 'W')
                    {
                        gatheredFish += int.Parse(fishingArea[currentRow, currentCol].ToString());
                        fishingArea[currentRow, currentCol] = '-';
                    }

                    if (fishingArea[currentRow, currentCol] == 'W')
                    {
                        hasFallen = true;
                        myRow = currentRow;
                        myCol = currentCol;
                        break;
                    }
                }

                myRow = currentRow;
                myCol = currentCol;
            }

            if (!hasFallen)
            {
                if (gatheredFish >= 20)
                {
                    Console.WriteLine("Success! You managed to reach the quota!");
                }
                else
                {
                    Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - gatheredFish} tons of fish more.");
                }

                if (gatheredFish > 0)
                {
                    Console.WriteLine($"Amount of fish caught: {gatheredFish} tons.");
                }

                fishingArea[myRow, myCol] = 'S';
                PrintMatrix(fishingArea);
            }
            else
            {
                Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{myRow},{myCol}]");
            }

        }

        public static void MoveToOppositeSide(ref int row, ref int col, char[,] fishingArea)
        {
            if (row < 0) row = fishingArea.GetLength(0) - 1;
            else if (row == fishingArea.GetLength(0)) row = 0;
            else if (col < 0) col = fishingArea.GetLength(1) - 1;
            else if (col == fishingArea.GetLength(1)) col = 0;
        }

        public static bool IsValid(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}