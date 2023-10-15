using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lillies = new Stack<int>(
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            Queue<int> roses = new Queue<int>(
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            List<int> stored = new List<int>();
            int wreaths = 0;

            while (lillies.Any() && roses.Any())
            {
                int currentLilly = lillies.Pop();
                int currentRose = roses.Peek();
                if (currentLilly + currentRose == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                }
                else if (currentLilly + currentRose > 15)
                {
                    currentLilly -= 2;
                    lillies.Push(currentLilly);
                }
                else
                {
                    stored.Add(currentLilly);
                    stored.Add(roses.Dequeue());
                }
            }

            if (stored.Sum() > 0)
            {
                wreaths += stored.Sum() / 15;
            }

            if (wreaths > 4)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
