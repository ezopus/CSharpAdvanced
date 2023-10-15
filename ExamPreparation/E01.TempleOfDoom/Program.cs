using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace E01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(
                Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            Stack<int> substances = new Stack<int>(
                Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            List<int> challenges = new List<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            while (tools.Any() && substances.Any() && challenges.Any())
            {
                int currentTool = tools.Dequeue();
                int currentSubstance = substances.Pop();
                if (challenges.Contains(currentTool * currentSubstance))
                {
                    challenges.Remove(currentSubstance * currentTool);
                }
                else
                {
                    tools.Enqueue(currentTool + 1);
                    if (currentSubstance - 1 > 0)
                    {
                        substances.Push(currentSubstance - 1);
                    }
                }
            }

            if (challenges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine("Tools: " + string.Join(", ", tools));
            }

            if (substances.Any())
            {
                Console.WriteLine("Substances: " + string.Join(", ", substances));
            }

            if (challenges.Any())
            {
                Console.WriteLine("Challenges: " + string.Join(", ", challenges));
            }

        }
    }
}

