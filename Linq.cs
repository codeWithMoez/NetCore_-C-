using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // =========== Using LINQ in Collections =========

        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        // var linqResult = from i in ints where i > 4 orderby i descending select i;
        var linqResult = ints.Where(i => i > 4)
                             .OrderByDescending(i => i);

        Console.WriteLine("Filtered and Sorted Integers:");
        foreach (var i in linqResult)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nUsing in List:");

        List<string> list = new() { "Moiz", "Me", "Learning LINQ" };

        var filteredList = list.Where(l => l.Contains("M"));

        foreach (var l in filteredList)
        {
            Console.WriteLine(l);
        }

        // ======== LINQ concept in SQL DB ==========
        // Table --> Class
        // Column --> Property
        // Rows --> Objects
        // Procedures --> Methods

        // Student Table Simulation
        List<Student> students = new()
        {
            new Student { Id = 1, Name = "Ali", Age = 20 },
            new Student { Id = 2, Name = "Sara", Age = 22 },
            new Student { Id = 3, Name = "Ahmed", Age = 21 }
        };

        // LINQ Query using Modern Method Syntax
        var sortedStudents = students.OrderBy(s => s.Name);

        Console.WriteLine("\nStudents Objects:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }
    }
}

// Define the Student class
class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
