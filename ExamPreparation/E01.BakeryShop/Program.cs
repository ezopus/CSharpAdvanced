using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray());
            Stack<double> flour = new Stack<double>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray());
            
            Dictionary<string, int> products = new Dictionary<string, int>();
            products.Add("Croissant", 0);
            products.Add("Muffin", 0);
            products.Add("Baguette", 0);
            products.Add("Bagel", 0);
            
            while (water.Any() && flour.Any())
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double waterPercentage = (currentWater * 100) / (currentWater + currentFlour);
                double flowerPercentage = (currentFlour * 100) / (currentWater + currentFlour);
                if (currentFlour == currentWater)
                {
                    products["Croissant"]++;
                }
                else if (waterPercentage == 40 && flowerPercentage == 60)
                {
                    products["Muffin"]++;
                }
                else if (waterPercentage == 30 && flowerPercentage == 70)
                {
                    products["Baguette"]++;
                }
                else if (waterPercentage == 20 && flowerPercentage == 80)
                {
                    products["Bagel"]++;
                }
                else
                {
                    flour.Push(Math.Abs(currentFlour - currentWater));
                    products["Croissant"]++;
                }
            }
            
            if (products.Sum(x => x.Value) > 0)
            {
                foreach (var item in products.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            
            if (water.Any())
            {
                Console.WriteLine("Water left: " + string.Join(", ", water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            
            if (flour.Any())
            {
                Console.WriteLine("Flour left: " + string.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }

        }

    }
}
