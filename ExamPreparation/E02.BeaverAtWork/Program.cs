using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int beaverRow = 0;
            int beaverCol = 0;
            int branchesTotal = 0;
            int branchesLost = 0;
            List<char> branchesCollected = new List<char>();

            for (int i = 0; i < n; i++)
            {
                char[] oneRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    pond[i, j] = oneRow[j];
                    if (oneRow[j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                        pond[beaverRow, beaverCol] = '-';
                    }
                    else if (oneRow[j] != '-' && oneRow[j] != 'F')
                    {
                        branchesTotal++;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int currentRow = beaverRow;
                int currentCol = beaverCol;
                switch (input)
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

                if (IsValid(currentRow, currentCol, pond))
                {
                    if (pond[currentRow, currentCol] != 'F' && pond[currentRow, currentCol] != '-')
                    {
                        branchesCollected.Add(pond[currentRow, currentCol]);
                        pond[currentRow, currentCol] = '-';
                    }
                    else if (pond[currentRow, currentCol] == 'F')
                    {
                        pond[currentRow, currentCol] = '-';
                        Swim(ref currentRow, ref currentCol, input, ref pond);
                        if (pond[currentRow, currentCol] != '-')
                        {
                            branchesCollected.Add(pond[currentRow, currentCol]);
                            pond[currentRow, currentCol] = '-';
                        }
                    }

                }
                else
                {
                    currentRow = beaverRow;
                    currentCol = beaverCol;
                    if (branchesCollected.Count > 0)
                    {
                        branchesCollected.RemoveAt(branchesCollected.Count - 1);
                        branchesTotal--;
                    }
                }

                beaverRow = currentRow;
                beaverCol = currentCol;

                if (branchesTotal == branchesCollected.Count)
                {
                    break;
                }
            }
            pond[beaverRow, beaverCol] = 'B';

            if (branchesCollected.Count == branchesTotal)
            {
                Console.WriteLine($"The Beaver successfully collect {branchesCollected.Count} wood branches: {string.Join(", ", branchesCollected)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesTotal - branchesCollected.Count} branches left.");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(pond[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



        static bool IsValid(int row, int col, char[,] pond)
        {
            return row >= 0 && row < pond.GetLength(0) && col >= 0 && col < pond.GetLength(1);
        }

        static void Swim(ref int row, ref int col, string direction, ref char[,] pond)
        {
            if (direction == "up")
            {
                if (row != 0) row = 0;
                else row = pond.GetLength(0) - 1;
            }

            if (direction == "down")
            {
                if (row != pond.GetLength(0) - 1) row = pond.GetLength(0) - 1;
                else row = 0;
            }

            if (direction == "left")
            {
                if (col != 0) col = 0;
                else col = pond.GetLength(1) - 1;
            }

            if (direction == "right")
            {
                if (col != pond.GetLength(1) - 1) col = pond.GetLength(1) - 1;
                else col = 0;
            }
        }
    }
}

/*
4
-Fe-
-BFy
---q
--zx
up
right
right
right
up
end

3
---
BF-
dbm
down
left
right
right
right
 */
