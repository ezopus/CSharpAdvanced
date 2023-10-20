using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray());
            Stack<int> calories = new Stack<int>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            int mealsEaten = 0;
            while (meals.Any() && calories.Any())
            {
                string currentMeal = meals.Dequeue();
                int mealCalories = 0;
                int currentCalories = calories.Peek();
                switch (currentMeal)
                {
                    case "salad":
                        mealCalories = 350;
                        break;
                    case "soup":
                        mealCalories = 490;
                        break;
                    case "pasta":
                        mealCalories = 680;
                        break;
                    case "steak":
                        mealCalories = 790;
                        break;
                }
                mealsEaten++;

                if (currentCalories > mealCalories)
                {
                    currentCalories -= mealCalories;
                    calories.Pop();
                    calories.Push(currentCalories);
                    continue;
                }
                else
                {
                    calories.Pop();
                    if (calories.Any())
                    {
                        int remainder = mealCalories - currentCalories;
                        if (remainder == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int nextDay = calories.Pop();
                            calories.Push(nextDay - remainder);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }

            if (!calories.Any())
            {
                Console.WriteLine($"John ate enough, he had {mealsEaten} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

        }
    }
}
