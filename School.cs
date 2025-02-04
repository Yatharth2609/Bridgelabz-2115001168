using System;
using System.Collections.Generic;

// Class representing a Subject
class Subject
{
    public string Name { get; set; }
    public int Marks { get; set; }

    public Subject(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }
}

// Class representing a Student
class Student
{
    public string Name { get; set; }
    public List<Subject> Subjects { get; set; }

    public Student(string name)
    {
        Name = name;
        Subjects = new List<Subject>();
    }

    public void AddSubject(Subject subject)
    {
        Subjects.Add(subject);
    }
}

// Grade Calculator Class
class GradeCalculator
{
    public static double CalculateAverage(Student student)
    {
        if (student.Subjects.Count == 0) return 0;

        int totalMarks = 0;
        foreach (var subject in student.Subjects)
        {
            totalMarks += subject.Marks;
        }
        return (double)totalMarks / student.Subjects.Count;
    }
}

// Main Program Execution
class Program
{
    static void Main()
    {

        Student student = new Student("John");
        student.AddSubject(new Subject("Maths", 90));
        student.AddSubject(new Subject("Science", 85));

        double average = GradeCalculator.CalculateAverage(student);
        Console.WriteLine($"Student: {student.Name}");
        Console.WriteLine("Subjects and Marks:");
        foreach (var subject in student.Subjects)
        {
            Console.WriteLine($"{subject.Name}: {subject.Marks}");
        }
        Console.WriteLine($"Average Marks: {average}");
    }
}
