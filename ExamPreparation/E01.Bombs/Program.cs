using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeBombs = 0;

            int[] inputBombEffects = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> bombEffects = new Queue<int>(inputBombEffects);

            int[] inputBombCasings = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> bombCasings = new Stack<int>(inputBombCasings);

            while (bombEffects.Any() && bombCasings.Any())
            {
                int currentEffect = bombEffects.Peek();
                int currentCasing = bombCasings.Peek();

                switch (currentEffect + currentCasing)
                {
                    case 40:
                        daturaBombs++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    case 60:
                        cherryBombs++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    case 120:
                        smokeBombs++;
                        bombCasings.Pop();
                        bombEffects.Dequeue();
                        break;
                    default:
                        bombCasings.Pop();
                        bombCasings.Push(currentCasing - 5);
                        break;
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
                {
                    break;
                }

            }

            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeBombs >= 3)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (!bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombEffects));
            }

            if (!bombCasings.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasings));
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombs}");



            Console.WriteLine();


            /*
            5, 25, 50, 115
            5, 15, 25, 35

            30, 40, 5, 55, 50, 100, 110, 35, 40, 35, 100, 80
            20, 25, 20, 5, 20, 20, 70, 5, 35, 0, 10
             */
        }
    }
}
