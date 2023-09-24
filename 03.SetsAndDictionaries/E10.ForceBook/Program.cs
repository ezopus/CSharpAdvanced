var forces = new SortedDictionary<string, SortedSet<string>>();

string input;

while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    if (input.Contains("|"))
    {
        string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
        string forceSide = tokens[0];
        string forceUser = tokens[1];
        if (!forces.Values.Any(x => x.Contains(forceUser)))
        {
            if (!forces.ContainsKey(forceSide))
            {
                forces.Add(forceSide, new SortedSet<string>());
            }
            forces[forceSide].Add(forceUser);
        }
    }
    else
    {
        string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
        string forceUser = tokens[0];
        string forceSide = tokens[1];

        //check if user exists in current forces
        foreach (var kp in forces)
        {
            if (kp.Value.Contains(forceUser))
            {
                kp.Value.Remove(forceUser);
                break;
            }
        }

        //check if user forceSide exists, if not add new forceSide
        if (!forces.ContainsKey(forceSide))
        {
            forces.Add(forceSide, new SortedSet<string>());
        }
        forces[forceSide].Add(forceUser);
        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
}

foreach (var side in forces.OrderByDescending(x => x.Value.Count))
{
    if (side.Value.Count > 0)
    {
        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
        foreach (var user in side.Value.OrderBy(x => x))
        {
            Console.WriteLine($"! {user}");
        }
    }
}


/*
Lighter | Royal
Darker | DCay
John Johnys -> Lighter
DCay -> Lighter
Lumpawaroo
*/