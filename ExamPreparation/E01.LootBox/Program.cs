using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.LootBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondBox = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> boxOne = new Queue<int>(firstBox);
            Stack<int> boxTwo = new Stack<int>(secondBox);

            int claimedItems = 0;

            while (boxOne.Any() && boxTwo.Any())
            {
                int lootOne = boxOne.Peek();
                int lootTwo = boxTwo.Peek();
                if ((lootOne + lootTwo) % 2 == 0)
                {
                    claimedItems += lootOne + lootTwo;
                    boxOne.Dequeue();
                    boxTwo.Pop();
                }
                else
                {
                    boxTwo.Pop();
                    boxOne.Enqueue(lootTwo);
                }
            }

            if (!boxOne.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!boxTwo.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}

