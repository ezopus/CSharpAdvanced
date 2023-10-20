namespace E02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[size, size];
            int submarineRow = 0;
            int submarineCol = 0;
            int cruisers = 3;
            int lives = 3;

            for (int i = 0; i < size; i++)
            {
                string oneRow = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    battlefield[i, j] = oneRow[j];
                    if (oneRow[j] == 'S')
                    {
                        submarineRow = i;
                        submarineCol = j;
                        battlefield[i, j] = '-';
                    }
                }
            }

            while (lives != 0 && cruisers != 0)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        submarineRow--;
                        break;
                    case "down":
                        submarineRow++;
                        break;
                    case "left":
                        submarineCol--;
                        break;
                    case "right":
                        submarineCol++;
                        break;
                }

                if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    cruisers--;
                }
                else if (battlefield[submarineRow, submarineCol] == '*')
                {
                    lives--;
                }
                //update field
                battlefield[submarineRow, submarineCol] = '-';

            }

            battlefield[submarineRow, submarineCol] = 'S';

            if (cruisers == 0)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }

            if (lives == 0)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(battlefield[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}