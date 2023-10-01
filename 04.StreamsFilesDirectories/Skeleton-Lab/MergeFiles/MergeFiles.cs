namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader readerFileOne = new StreamReader(firstInputFilePath))
            {
                using (StreamReader readerFileTwo = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        if (readerFileOne.ReadToEnd().Length >= readerFileTwo.ReadToEnd().Length)
                        {
                            readerFileOne.DiscardBufferedData();
                            readerFileTwo.DiscardBufferedData();
                            while (readerFileTwo.ReadLine() != null)
                            {
                                string firstFile = readerFileOne.ReadLine();
                                string secondFile = readerFileTwo.ReadLine();
                                writer.WriteLine(firstFile);
                                writer.WriteLine(secondFile);
                            }

                            string remaining = readerFileOne.ReadToEnd();
                            writer.WriteLine(remaining);
                        }
                        else
                        {
                            while (readerFileOne.ReadLine() != null)
                            {
                                string firstFile = readerFileOne.ReadLine();
                                string secondFile = readerFileTwo.ReadLine();
                                writer.WriteLine(firstFile);
                                writer.WriteLine(secondFile);
                            }

                            string remaining = readerFileTwo.ReadToEnd();
                            writer.WriteLine(remaining);
                        }

                    }

                }
            }
        }
    }
}
