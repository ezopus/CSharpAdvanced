int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n,n];

for (int i = 0; i < n; i++)
{
    int[] oneRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int j = 0; j < n; j++)
    {
        matrix[i,j] = oneRow[j];
    }
}

int diagonalSum = 0;
for (int i = 0; i < n; i++)
{
    diagonalSum += matrix[i,i];
}

Console.WriteLine(diagonalSum);