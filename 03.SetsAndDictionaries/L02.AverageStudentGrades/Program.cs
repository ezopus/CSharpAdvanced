int studentCount = int.Parse(Console.ReadLine());
var students = new Dictionary<string, List<decimal>>();

for (int i = 0; i < studentCount; i++)
{
    string[] currentStudent = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string studentName = currentStudent[0];
    decimal studentGrade = decimal.Parse(currentStudent[1]);
    if (students.ContainsKey(studentName))
    {
        students[studentName].Add(studentGrade);
    }
    else
    {
        students.Add(studentName, new List<decimal>());
        students[studentName].Add(studentGrade);
    }
}

foreach (var kp in students)
{
    Console.Write($"{kp.Key} -> ");
    foreach (var grade in kp.Value)
    {
        Console.Write($"{grade:f2} ");
    }
     
    Console.Write($"(avg: {kp.Value.Average(x => x):f2})");
    Console.WriteLine();
}

/*
4
Vlad 4.50
Peter 3.00
Vlad 5.00
Peter 3.66

5
George 6.00
George 5.50
George 6.00
John 4.40
Peter 3.30
*/