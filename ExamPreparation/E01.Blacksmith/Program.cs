using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            Stack<int> carbon = new Stack<int>(Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);

            while (steel.Any() && carbon.Any())
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();
                int sum = currentSteel + currentCarbon;
                if (sum == 70)
                {
                    swords["Gladius"]++;
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                }
            }

            if (swords.Sum(sw => sw.Value) > 0)
            {
                Console.WriteLine($"You have forged {swords.Sum(sw => sw.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine("Steel left: " + string.Join(", ", steel));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Any())
            {
                Console.WriteLine("Carbon left: " + string.Join(", ", carbon));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var item in swords.Where(i => i.Value > 0).OrderBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
