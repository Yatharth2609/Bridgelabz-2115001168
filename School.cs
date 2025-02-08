using System;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

public class Teacher : Person
{
    public string Subject { get; set; }

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Teacher, Subject: {Subject}");
    }
}

public class Student : Person
{
    public string Grade { get; set; }

    public Student(string name, int age, string grade) : base(name, age)
    {
        Grade = grade;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Student, Grade: {Grade}");
    }
}

public class Staff : Person
{
    public string Department { get; set; }

    public Staff(string name, int age, string department) : base(name, age)
    {
        Department = department;
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Staff, Department: {Department}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person teacher = new Teacher("Mr. Gajendra", 40, "Mathematics");
        Person student = new Student("Alice", 15, "10th Grade");
        Person staff = new Staff("Mr. Hitendra", 50, "Administration");

        teacher.DisplayDetails();
        student.DisplayDetails();
        staff.DisplayDetails();
    }
}