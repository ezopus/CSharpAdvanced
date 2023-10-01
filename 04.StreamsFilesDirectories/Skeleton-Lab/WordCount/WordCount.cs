namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader words = new StreamReader(wordsFilePath))
            {
                using (StreamReader reader = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        var wordCount = new Dictionary<string, int>();
                        string[] currentWords = words.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string[] text = reader.ReadToEnd().Split(new char[] { ' ', '.', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string word in currentWords)
                        {
                            foreach (string textWord in text)
                            {
                                if (word.ToLower() == textWord.ToLower())
                                {
                                    if (!wordCount.ContainsKey(textWord.ToLower()))
                                    {
                                        wordCount.Add(word.ToLower(), 0);
                                    }

                                    wordCount[word.ToLower()]++;
                                }
                            }
                        }

                        foreach (var kp in wordCount.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{kp.Key} - {kp.Value}");
                        }
                    }

                }
            }
        }
    }
}
