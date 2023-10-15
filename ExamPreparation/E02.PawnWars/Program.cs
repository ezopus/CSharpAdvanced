using System;
using System.Linq;

namespace E02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] field = new char[8, 8];
            var white = (0, 0);
            var black = (0, 0);
            string[] rows = new string[8] { "8", "7", "6", "5", "4", "3", "2", "1" };
            string[] cols = new string[8] { "a", "b", "c", "d", "e", "f", "g", "h" };

            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = inputRow[j];
                    if (field[i, j] == 'w')
                    {
                        white = (i, j);
                    }
                    else if (field[i, j] == 'b')
                    {
                        black = (i, j);
                    }
                }
            }

            bool isCaptured = false;
            bool isPromoted = false;
            
            while (!isPromoted && !isCaptured)
            {
                if (WhiteMove())
                {
                    break;
                }

                if (BlackMove())
                {
                    break;
                }
            }

            bool WhiteMove()
            {
                //update field
                field[white.Item1, white.Item2] = '-';

                //check if white can take black
                if (white.Item1 - 1 == black.Item1 && 
                    (white.Item2 - 1 == black.Item2 || white.Item2 + 1 == black.Item2)
                    )
                {
                    //white takes black
                    field[black.Item1, black.Item2] = 'w';
                    Console.WriteLine($"Game over! White capture on {cols[black.Item2]}{rows[black.Item1]}.");
                    return isCaptured = true;
                }

                //check if white can be promoted
                if (white.Item1 - 1 == 0)
                {
                    white.Item1 = 0;
                    field[white.Item1, white.Item2] = 'w';
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {cols[white.Item2]}{rows[white.Item1]}.");
                    return isPromoted = true;
                }

                //move white
                white.Item1 -= 1;
                field[white.Item1, white.Item2] = 'w';

                return isPromoted = false;
            }

            bool BlackMove()
            {
                //update field
                field[black.Item1, black.Item2] = '-';

                //check if black can take white
                if (black.Item1 + 1 == white.Item1 &&
                    (black.Item2 - 1 == white.Item2 || black.Item2 + 1 == white.Item2)
                    )
                {
                    //black takes white
                    field[white.Item1, white.Item2] = 'b';
                    Console.WriteLine($"Game over! Black capture on {cols[white.Item2]}{rows[white.Item1]}.");
                    return isCaptured = true;
                }

                //check if black can be promoted
                if (black.Item1 + 1 == field.GetLength(0) - 1)
                {
                    black.Item1 = field.GetLength(0) - 1;
                    field[black.Item1, black.Item2] = 'b';
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {cols[black.Item2]}{rows[black.Item1]}.");
                    return isPromoted = true;
                }

                //move black
                black.Item1 += 1;
                field[black.Item1, black.Item2] = 'b';

                return isPromoted = false;
            }

        }
    }
}


