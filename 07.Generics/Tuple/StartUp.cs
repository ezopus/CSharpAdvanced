string[] nameCity = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] nameInt = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string[] numberTokens = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<string, string> person = new CustomTuple<string, string>($"{nameCity[0]} {nameCity[1]}", string.Join(' ', nameCity[2..]));

CustomTuple<string, int> mark = new CustomTuple<string, int>(nameInt[0], int.Parse(nameInt[1]));

CustomTuple<int, double> numbers =
    new CustomTuple<int, double>(int.Parse(numberTokens[0]), double.Parse(numberTokens[1]));

Console.WriteLine(person);
Console.WriteLine(mark);
Console.WriteLine(numbers);
