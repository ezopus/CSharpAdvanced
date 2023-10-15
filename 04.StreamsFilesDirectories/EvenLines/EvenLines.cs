using System.IO;
using System.Text;
using System.Xml;

namespace EvenLines
{
    using System;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string output = string.Empty;
            using (StreamReader input = new StreamReader(inputFilePath))
            {
                int lineNum = 0;

                while (!input.EndOfStream)
                {
                        string currentLine = input.ReadLine();
                        if (lineNum % 2 == 0)
                        {
                            char[] toReplace = new char[] { '-', ',', '.', '!', '!' };
                            string replaced =
                                new string(currentLine.Select(c => toReplace.Contains(c) ? '@' : c).ToArray());
                            string[] reversed = replaced.Split().ToArray();

                            for (int i = reversed.Length - 1; i >= 0; i--)
                            {
                                output += (reversed[i] + " ");
                            }

                            output += "\n";
                        }

                        lineNum++;
                }
            }
                return output;
        }
    }
}
