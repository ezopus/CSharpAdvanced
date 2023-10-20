namespace E01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            Stack<int> meds = new Stack<int>(Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> items = new Dictionary<string, int>();
            items.Add("Patch", 0);
            items.Add("Bandage", 0);
            items.Add("MedKit", 0);

            while (textiles.Any() && meds.Any())
            {
                int currentTextile = textiles.Dequeue();
                int currentMeds = meds.Pop();
                int sum = currentTextile + currentMeds;
                if (sum == 30)
                {
                    items["Patch"]++;
                }
                else if (sum == 40)
                {
                    items["Bandage"]++;
                }
                else if (sum >= 100)
                {
                    items["MedKit"]++;
                    if (sum - 100 > 0)
                    {
                        meds.Push(meds.Pop() + (sum - 100));
                    }
                }
                else
                {
                    meds.Push(currentMeds + 10);
                }
            }

            if (!textiles.Any() && meds.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!meds.Any() && textiles.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            foreach (var item in items.Where(i => i.Value > 0).OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (!textiles.Any() && meds.Any())
            {
                Console.WriteLine("Medicaments left: " + string.Join(", ", meds));
            }
            else if (!meds.Any() && textiles.Any())
            {
                Console.WriteLine("Textiles left: " + string.Join(", ", textiles));
            }
        }
    }
}