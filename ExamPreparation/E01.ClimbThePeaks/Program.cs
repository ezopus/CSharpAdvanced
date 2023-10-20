namespace E01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> food = new Stack<int>(
                Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            Queue<int> stamina = new Queue<int>(
                Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            List<string> climbed = new List<string>();
            Dictionary<string, int> peaks = new Dictionary<string, int>();
            peaks.Add("Vihren", 80);
            peaks.Add("Kutelo", 90);
            peaks.Add("Banski Suhodol", 100);
            peaks.Add("Polezhan", 60);
            peaks.Add("Kamenitza", 70);

            while (peaks.Count > 0 && food.Any() && stamina.Any())
            {
                int dailyFood = food.Pop();
                int dailyStamina = stamina.Dequeue();
                if (peaks.Count > 0)
                {
                    var peak = peaks.First();
                    if (dailyFood + dailyStamina >= peak.Value)
                    {
                        climbed.Add(peak.Key);
                        peaks.Remove(peak.Key);
                    }
                }
                else
                {
                    break;
                }
            }

            if (peaks.Count == 0)
            {
                Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }
            if (climbed.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in climbed)
                {
                    Console.WriteLine(peak);
                }
            }
        }
    }
}