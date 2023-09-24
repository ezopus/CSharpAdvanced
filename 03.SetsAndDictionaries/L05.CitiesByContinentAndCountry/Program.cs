var continents = new Dictionary<string, Dictionary<string, List<string>>>();
int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string continent = input[0];
    string country = input[1];
    string city = input[2];
    if (continents.ContainsKey(continent))
    {
        if (continents[continent].ContainsKey(country))
        {
            continents[continent][country].Add(city);
        }
        else
        {
            continents[continent].Add(country, new List<string>() { city });
        }
    }
    else
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
        continents[continent].Add(country, new List<string>());
        continents[continent][country].Add(city);
    }
}

foreach (var kp in continents)
{
    Console.WriteLine($"{kp.Key}:");
    foreach (var countryCityPair in kp.Value)
    {
        Console.WriteLine($"  {countryCityPair.Key} -> {string.Join(", ", countryCityPair.Value)}");
    }
}

/*
9
Europe Bulgaria Sofia
Asia China Beijing
Asia Japan Tokyo
Europe Poland Warsaw
Europe Germany Berlin
Europe Poland Poznan
Europe Bulgaria Plovdiv
Africa Nigeria Abuja
Asia China Shanghai
 */