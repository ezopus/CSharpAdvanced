int n = int.Parse(Console.ReadLine());
long[][] pascal = new long[n][];
pascal[0] = new long[1] { 1 };

for (int row = 1; row < n; row++)
{
    pascal[row] = new long[row + 1];
    for (int col = 0; col < pascal[row].Length; col++)
    {
        if (col > 0)
        {
            pascal[row][col] = pascal[row - 1][col - 1];
        }
        if (col < pascal[row].Length - 1)
        {
            pascal[row][col] += pascal[row - 1][col];
        }
    }
}

for (int row = 0; row < n; row++)
{
    Console.WriteLine(string.Join(' ', pascal[row]));
}