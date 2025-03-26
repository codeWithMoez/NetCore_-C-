using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // =========== Using LINQ in Collections =========

        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        // Filtering and Sorting
        var filteredSortedInts = ints.Where(i => i > 4).OrderByDescending(i => i);

        Console.WriteLine("Filtered and Sorted Integers:");
        foreach (var i in filteredSortedInts)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("\nUsing LINQ in List:");

        List<string> list = new() { "Moiz", "Me", "Learning LINQ" };

        var filteredList = list.Where(l => l.Contains("M"));

        foreach (var l in filteredList)
        {
            Console.WriteLine(l);
        }

        // ======== LINQ Concept in SQL DB ==========
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

        // Sorting Students
        var sortedStudents = students.OrderBy(s => s.Name);

        Console.WriteLine("\nStudents (Sorted by Name):");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }

        // Aggregation Operations
        var totalStudents = students.Count();
        var averageAge = students.Average(s => s.Age);
        var maxAge = students.Max(s => s.Age);

        Console.WriteLine($"\nTotal Students: {totalStudents}");
        Console.WriteLine($"Average Age: {averageAge}");
        Console.WriteLine($"Oldest Student Age: {maxAge}");

        // ======== LINQ Join Example ==========
        List<Course> courses = new()
        {
            new Course { CourseId = 1, StudentId = 1, CourseName = "Math" },
            new Course { CourseId = 2, StudentId = 1, CourseName = "Physics" },
            new Course { CourseId = 3, StudentId = 2, CourseName = "Biology" }
        };

        // Inner Join
        var studentCourses = from s in students
                             join c in courses on s.Id equals c.StudentId
                             select new { s.Name, c.CourseName };

        Console.WriteLine("\nInner Join (Students and Courses):");
        foreach (var sc in studentCourses)
        {
            Console.WriteLine($"Student: {sc.Name}, Course: {sc.CourseName}");
        }

        // Left Join (Including students without courses)
        var leftJoin = from s in students
                       join c in courses on s.Id equals c.StudentId into sc
                       from subCourse in sc.DefaultIfEmpty()
                       select new { s.Name, Course = subCourse?.CourseName ?? "No Course" };

        Console.WriteLine("\nLeft Join (All Students and Their Courses):");
        foreach (var item in leftJoin)
        {
            Console.WriteLine($"Student: {item.Name}, Course: {item.Course}");
        }
    }
}

// Define Student Class
class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}

// Define Course Class
class Course
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public string? CourseName { get; set; }
}
