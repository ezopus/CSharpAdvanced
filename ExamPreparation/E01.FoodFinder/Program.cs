using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.FoodFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[] vowelInput = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            char[] consonantInput = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
            Queue<char> vowels = new Queue<char>(vowelInput);
            Stack<char> consonants = new Stack<char>(consonantInput);

            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>();
            words.Add("pear", new HashSet<char>());
            words.Add("flour", new HashSet<char>());
            words.Add("pork", new HashSet<char>());
            words.Add("olive", new HashSet<char>());

            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(currentVowel))
                    {
                        word.Value.Add(currentVowel);
                    }

                    if (word.Key.Contains(currentConsonant))
                    {
                        word.Value.Add(currentConsonant);
                    }
                }
                vowels.Enqueue(currentVowel);
            }

            Console.WriteLine($"Words found: {words.Count(x => x.Key.Length == x.Value.Count)}");

            foreach (var word in words.Where(x => x.Key.Length == x.Value.Count))
            {
                Console.WriteLine($"{word.Key}");
            }
        }
    }
}