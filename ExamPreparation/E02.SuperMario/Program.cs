using System;

namespace E02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int marioRow = 0;
            int marioCol = 0;
            bool isAlive = true;
            bool hasPrincess = false;

            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];

            //create field
            for (int i = 0; i < rows; i++)
            {
                char[] col = Console.ReadLine().ToCharArray();
                field[i] = new char[col.Length];

                for (int j = 0; j < col.Length; j++)
                {
                    if (col[j] == 'M')
                    {
                        marioRow = i;
                        marioCol = j;
                    }
                    field[i][j] = col[j];
                }
            }

            //start game logic
            while (isAlive && !hasPrincess)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                char move = char.Parse(tokens[0]);
                int spawnRow = int.Parse(tokens[1]);
                int spawnCol = int.Parse(tokens[2]);

                //first bowser spawns
                field[spawnRow][spawnCol] = 'B';

                //next mario moves
                field[marioRow][marioCol] = '-';
                MarioMove(move, spawnRow, spawnCol);

                //check if he's alive after move
                CheckMario();
            }

            //output checks
            if (!isAlive)
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            if (isAlive && hasPrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            //print field
            PrintMatrix(field);

            void MarioMove(char move, int spawnRow, int spawnCol)
            {
                switch (move)
                {
                    //up
                    case 'W':
                        field = MoveUp(field);
                        break;
                    //down
                    case 'S':
                        field = MoveDown(field);
                        break;
                    //left
                    case 'A':
                        field = MoveLeft(field);
                        break;
                    //right
                    case 'D':
                        field = MoveRight(field);
                        break;
                    default:
                        break;
                }

                //decrease lives by 1 because of move
                lives--;
            }
            char[][] MoveUp(char[][] field)
            {
                if (marioRow - 1 >= 0)
                {
                    marioRow -= 1;
                    if (field[marioRow][marioCol] == 'B')
                    {
                        lives -= 2;
                        //check if mario wins against enemy
                        if (lives > 0)
                        {
                            field[marioRow][marioCol] = '-';
                        }
                    }
                    else if (field[marioRow][marioCol] == 'P')
                    {
                        field[marioRow][marioCol] = '-';
                        hasPrincess = true;
                    }
                }
                return field;
            }
            char[][] MoveDown(char[][] field)
            {
                if (marioRow + 1 < field.Length)
                {
                    marioRow += 1;
                    if (field[marioRow][marioCol] == 'B')
                    {
                        lives -= 2;
                        //check if mario wins against enemy
                        if (lives > 0)
                        {
                            field[marioRow][marioCol] = '-';
                        }
                    }
                    else if (field[marioRow][marioCol] == 'P')
                    {
                        field[marioRow][marioCol] = '-';
                        hasPrincess = true;
                    }
                }
                return field;
            }
            char[][] MoveRight(char[][] field)
            {
                if (marioCol + 1 < field[marioRow].Length)
                {
                    marioCol += 1;
                    if (field[marioRow][marioCol] == 'B')
                    {
                        lives -= 2;
                        //check if mario wins against enemy
                        if (lives > 0)
                        {
                            field[marioRow][marioCol] = '-';
                        }
                    }
                    else if (field[marioRow][marioCol] == 'P')
                    {
                        field[marioRow][marioCol] = '-';
                        hasPrincess = true;
                    }
                }
                return field;
            }
            char[][] MoveLeft(char[][] field)
            {
                if (marioCol - 1 >= 0)
                {
                    marioCol -= 1;
                    if (field[marioRow][marioCol] == 'B')
                    {
                        lives -= 2;
                        //check if mario wins against enemy
                        if (lives > 0)
                        {
                            field[marioRow][marioCol] = '-';
                        }
                    }
                    else if (field[marioRow][marioCol] == 'P')
                    {
                        field[marioRow][marioCol] = '-';
                        hasPrincess = true;
                    }
                }
                return field;
            }
            void CheckMario()
            {
                if (lives <= 0 && !hasPrincess)
                {
                    isAlive = false;
                    field[marioRow][marioCol] = 'X';
                }
                else if (lives <= 0 && hasPrincess)
                {
                    field[marioRow][marioCol] = '-';
                }
            }
            void PrintMatrix(char[][] field)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field[i].GetLength(0); j++)
                    {
                        Console.Write(field[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

/*
100
5
--P--
-----
-----
-----
--M--
W 3 0
W 3 1
W 3 2
W 3 3

3
5
--P--
-----
-----
-----
--M--
W 3 2
 */