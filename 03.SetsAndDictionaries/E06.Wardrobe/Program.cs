var colors = new Dictionary<string, Dictionary<string, int>>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string[] input = Console
        .ReadLine()
        .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

    string color = input[0];
    if (!colors.ContainsKey(color))
    {
        colors.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < input.Length; j++)
    {
        string item = input[j];
        if (!colors[color].ContainsKey(item))
        {
            colors[color].Add(item, 0);
        }
        colors[color][item]++;
    }
}

string[] wantedClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string wantedColor = wantedClothes[0];
string wantedItem = wantedClothes[1];

foreach (var kp in colors)
{
    Console.WriteLine($"{kp.Key} clothes:");
    foreach (var items in kp.Value)
    {
        string output = $"* {items.Key} - {items.Value}";
        if (wantedColor == kp.Key && wantedItem == items.Key)
        {
            output += " (found!)";
        }
            Console.WriteLine(output);
    }
}

/*
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress

4
Red -> hat
Red -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
White tanktop
 */