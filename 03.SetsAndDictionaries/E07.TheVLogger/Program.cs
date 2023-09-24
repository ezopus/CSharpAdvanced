var vloggers = new Dictionary<string, Dictionary<string, List<string>>>();
string input;

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string username = token[0];
    string action = token[1];

    if (action == "joined" && !vloggers.ContainsKey(username))
    {
        vloggers.Add(username, new Dictionary<string, List<string>>());
        vloggers[username].Add("followers", new List<string>());
        vloggers[username].Add("following", new List<string>());
    }
    else if (vloggers.ContainsKey(token[0]) && vloggers.ContainsKey(token[2]) && token[0] != token[2])
    {
        string followed = token[2];
        if (!vloggers[username]["following"].Contains(followed))
        {
            vloggers[username]["following"].Add(followed);
        }
        if (!vloggers[followed]["followers"].Contains(username))
        {
            vloggers[followed]["followers"].Add(username);
        }
    }
}

Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

int outputCounter = 1;
foreach (var username in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
{

    Console.WriteLine($"{outputCounter}. {username.Key} : {username.Value["followers"].Count} followers, {username.Value["following"].Count} following");
    if (outputCounter == 1 && username.Value["followers"].Count > 0)
    {
        foreach (var follower in username.Value["followers"].OrderBy(x => x))
        {
            Console.WriteLine($"*  {follower}");
        }
    }
    outputCounter++;
}


/*
EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics

JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics
*/