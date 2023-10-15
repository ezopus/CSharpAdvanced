using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatTokens = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> hats = new Stack<int>(hatTokens);

            int[] scarfTokens = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> scarves = new Queue<int>(scarfTokens);

            List<int> sets = new List<int>();

            while (hats.Any() && scarves.Any())
            {
                int currentHat = hats.Peek();
                int currentScarf = scarves.Peek();

                if (currentHat > currentScarf)
                {
                    sets.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarves.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarves.Dequeue();
                    hats.Push((hats.Pop() + 1));
                }

            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
