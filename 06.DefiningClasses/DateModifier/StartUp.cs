using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            Console.WriteLine(DateModifier.GetDifferenceInDays(start, end));

        }
    }
}
