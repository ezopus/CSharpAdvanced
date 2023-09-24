HashSet<string> vips = new HashSet<string>();
HashSet<string> regulars = new HashSet<string>();

int guestCounter = 0;
string input = "";
while ((input = Console.ReadLine()) != "PARTY")
{
    string guest = input;
    char first = guest[0];
    if (char.IsDigit(first))
    {
        vips.Add(guest);
    }
    else
    {
        regulars.Add(guest);
    }

    guestCounter++;
}

while ((input = Console.ReadLine()) != "END")
{
    if (vips.Contains(input))
    {
        vips.Remove(input);
    }
    else if (regulars.Contains(input))
    {
        regulars.Remove(input);
    }

    guestCounter--;
}

Console.WriteLine(guestCounter);
foreach (string vip in vips)
{
    Console.WriteLine(vip);
}

foreach (string regular in regulars)
{
    Console.WriteLine(regular);
}


/*
7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END
*/