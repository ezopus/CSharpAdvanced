using System.IO;
using System.Linq;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {

            string[] text = File.ReadAllLines(inputFilePath);
           
            int num = 1;

            foreach (var line in text)
            {
                int letters = line.Count(char.IsLetter);
                int symbols = line.Count(char.IsPunctuation);
                
             File.AppendAllText(outputFilePath, $"Line {num}: {line} ({letters})({symbols}) \n");
                num++;
            }
        }
    }
}
