namespace E01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new Stack<int>(Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> additionalConsumption = new Queue<int>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            Queue<int> amountNeeded = new Queue<int>(
                Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            int altitudeReached = 0;
            List<string> altitudes = new List<string>();

            while (amountNeeded.Any() && fuel.Any())
            {
                int currentFuel = fuel.Peek();
                int currentAdditionalConsumption = additionalConsumption.Peek();
                int currentAmountNeeded = amountNeeded.Peek();

                int sum = currentFuel - currentAdditionalConsumption;

                if (sum >= currentAmountNeeded)
                {
                    fuel.Pop();
                    additionalConsumption.Dequeue();
                    amountNeeded.Dequeue();
                    altitudeReached++;
                    altitudes.Add("Altitude " + altitudeReached);

                    Console.WriteLine($"John has reached: Altitude {altitudeReached}");
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {altitudeReached + 1}");
                    break;
                }
            }

            if (altitudes.Any() && amountNeeded.Any())
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("Reached altitudes: " + string.Join(", ", altitudes));
            }
            else if (!altitudes.Any())
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
            else if (!amountNeeded.Any())
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }



        }
    }
}