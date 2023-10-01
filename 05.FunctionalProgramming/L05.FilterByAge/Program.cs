int numberOfPeople = int.Parse(Console.ReadLine());

List<Person> students = ReadPeople(numberOfPeople);

//read filters
string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();



static List<Person> ReadPeople(int numberOfPeople)
{
    //read input
    List<Person> people = new();
    for (int i = 0; i < numberOfPeople; i++)
    {
        string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
        string name = input[0];
        int age = int.Parse(input[1]);
        people.Add(new Person(name, age));
    }
    return people;
}


Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

students = students.Where(filter).ToList();


Func<Person, bool> CreateFilter (string condition, int ageThreshold)
{
    switch (condition)
    {
        case "older":
            return p => p.Age >= ageThreshold;
        case "younger":
            return p => p.Age < ageThreshold;
        default:
            return default;
    }
};

Action<Person> printer = CreatePrinter(format);


Action<Person> CreatePrinter(string format)
{
    switch (format)
    {
        case "name age":
            return p => Console.WriteLine($"{p.Name} - {p.Age}");
        case "name":
            return p => Console.WriteLine($"{p.Name}");
        case "age":
            return p => Console.WriteLine($"{p.Age}");
        default:
            return null;
    }
}

foreach (var person in students)
{
    printer(person);
}
class Person
{
    public Person (string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}