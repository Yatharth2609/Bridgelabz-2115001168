using System;

class Student
{

    private static string universityName = "Global University";
    private static int totalStudents = 0;

    public readonly int RollNumber;
    public string Name;
    public string Grade;

    public static string UniversityName
    {
        get { return universityName; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                universityName = value;
                Console.WriteLine($"University name updated to: {universityName}");
            }
            else
            {
                Console.WriteLine("University name cannot be empty.");
            }
        }
    }

    public Student(string Name, int RollNumber, string Grade)
    {
        this.Name = Name;
        this.RollNumber = RollNumber;
        this.Grade = Grade;
        totalStudents++;
    }

    // Static method to display total number of students
    public static void DisplayTotalStudents()
    {
        Console.WriteLine($"Total Students Enrolled: {totalStudents}");
    }

    // Method to display student details using 'is' operator
    public void DisplayStudentDetails()
    {
        if (this is Student)
        {
            Console.WriteLine($"University: {universityName}");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Roll Number: {RollNumber}");
            Console.WriteLine($"Grade: {Grade}");
        }
    }

    // Method to update student grade
    public void UpdateGrade(string newGrade)
    {
        if (this is Student)
        {
            Grade = newGrade;
            Console.WriteLine($"{Name}'s grade has been updated to: {Grade}");
        }
    }
}

class Program
{
    static void Main()
    {
 
        Student student1 = new Student("Rajiv", 101, "A");
        Student student2 = new Student("Priya", 102, "B");

        Console.WriteLine("Before Changing University Name:");
        student1.DisplayStudentDetails();
        Console.WriteLine();
        student2.DisplayStudentDetails();

        Console.WriteLine("\nChanging University Name...\n");

        Student.UniversityName = "GLA University";

        Console.WriteLine("\nAfter Changing University Name:");
        student1.DisplayStudentDetails();
        Console.WriteLine();
        student2.DisplayStudentDetails();

        Console.WriteLine("\nUpdating Student Grade...\n");

        student1.UpdateGrade("A+");

        Console.WriteLine();

        Student.DisplayTotalStudents();
    }
}
