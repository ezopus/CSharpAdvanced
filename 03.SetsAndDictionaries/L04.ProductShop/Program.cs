var shops = new Dictionary<string, Dictionary<string, double>>();
string input = "";

while ((input = Console.ReadLine()) != "Revision")
{
    string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string shop = tokens[0];
    string product = tokens[1];
    double productValue = double.Parse(tokens[2]);
    if (shops.ContainsKey(shop))
    {
        if (shops[shop].ContainsKey(product))
        {
            shops[shop][product] = productValue;
        }
        else
        {
            shops[shop].Add(product, productValue);
        }
    }
    else
    {
        shops.Add(shop, new Dictionary<string, double>());
        shops[shop].Add(product, productValue);
    }
}

foreach (var kp in shops.OrderBy(x => x.Key))
{
    Console.WriteLine($"{kp.Key}->");
    foreach (var p in kp.Value)
    {
        Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
    }
}


/*
lidl, juice, 2.30
fantastico, apple, 1.20
kaufland, banana, 1.10
fantastico, grape, 2.20
Revision

tmarket, peanuts, 2.20
GoGrill, meatballs, 3.30
GoGrill, HotDog, 1.40
tmarket, sweets, 2.20
Revision
 */