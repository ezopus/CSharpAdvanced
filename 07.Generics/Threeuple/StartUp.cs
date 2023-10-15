string[] nameCity = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] nameInt = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numberTokens = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Threeuple<string, string, string> person = new Threeuple<string, string, string>($"{nameCity[0]} {nameCity[1]}", nameCity[2], string.Join(' ', nameCity[3..]));

Threeuple<string, int, bool> mark = new Threeuple<string, int, bool>(nameInt[0], int.Parse(nameInt[1]), nameInt[2] == "drunk");

Threeuple<string, double, string> numbers =
    new Threeuple<string, double, string>(numberTokens[0], double.Parse(numberTokens[1]), numberTokens[2]);

Console.WriteLine(person);
Console.WriteLine(mark);
Console.WriteLine(numbers);
