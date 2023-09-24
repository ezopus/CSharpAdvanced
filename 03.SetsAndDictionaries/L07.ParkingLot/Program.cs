HashSet<string> cars = new HashSet<string>();
string input = "";
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string car = tokens[1];
    if (command == "IN")
    {
        cars.Add(car);
    }
    else if (command == "OUT")
    {
        cars.Remove(car);
    }
}

if (cars.Count > 0)
{
    foreach (string car in cars)
    {
    Console.WriteLine(car);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}


/*
IN, CA2844AA
IN, CA1234TA
OUT, CA2844AA
IN, CA9999TT
IN, CA2866HI
OUT, CA1234TA
IN, CA2844AA
OUT, CA2866HI
IN, CA9876HH
IN, CA2822UU
END
*/