var users = new Dictionary<string, Dictionary<string, int>>();
var submissions = new Dictionary<string, int>();

string input;
while ((input = Console.ReadLine()) != "exam finished")
{
    string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
    string username = tokens[0];
    string language = tokens[1];
    if (language == "banned")
    {
        if (users.ContainsKey(username))
        {
            users.Remove(username);
        }
        continue;
    }
    int points = int.Parse(tokens[2]);

    if (!users.ContainsKey(username))
    {
        users.Add(username, new Dictionary<string, int>());
        users[username].Add(language, points);
    }
    else
    {
        if (users[username].ContainsKey(language))
        {
            if (users[username][language] < points)
            {
                users[username][language] = points;
            }
        }
        else
        {
            users[username].Add(language, points);
        }
    }
    if (!submissions.ContainsKey(language))
    {
        submissions.Add(language, 0);
    }
    submissions[language]++;
}

Console.WriteLine("Results:");
foreach (var user in users.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key))
{
    string name = user.Key;
    foreach (var score in user.Value)
    {
        Console.WriteLine($"{name} | {score.Value}");
    }
}

Console.WriteLine("Submissions:");
foreach (var sub in submissions.OrderBy(x => x.Key))
{
    Console.WriteLine($"{sub.Key} - {sub.Value}");
}


/*
Peter-Java-84
George-C#-70
George-C#-84
Sam-C#-94
exam finished
 */