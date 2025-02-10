using System;

class Student
{
    public int RollNumber { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
    public Student Next { get; set; }

    public Student(int rollNumber, string name, int age, string grade)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Grade = grade;
        Next = null;
    }
}

class StudentList
{
    private Student head;

    public void AddAtBeginning(int rollNumber, string name, int age, string grade)
    {
        Student newStudent = new Student(rollNumber, name, age, grade);
        newStudent.Next = head;
        head = newStudent;
    }

    public void AddAtEnd(int rollNumber, string name, int age, string grade)
    {
        Student newStudent = new Student(rollNumber, name, age, grade);
        if (head == null)
        {
            head = newStudent;
            return;
        }

        Student current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newStudent;
    }

    public void AddAtPosition(int position, int rollNumber, string name, int age, string grade)
    {
        if (position < 1)
            return;

        if (position == 1)
        {
            AddAtBeginning(rollNumber, name, age, grade);
            return;
        }

        Student newStudent = new Student(rollNumber, name, age, grade);
        Student current = head;
        for (int i = 1; i < position - 1 && current != null; i++)
            current = current.Next;

        if (current == null)
            return;

        newStudent.Next = current.Next;
        current.Next = newStudent;
    }

    public void DeleteByRollNumber(int rollNumber)
    {
        if (head == null)
            return;

        if (head.RollNumber == rollNumber)
        {
            head = head.Next;
            return;
        }

        Student current = head;
        while (current.Next != null && current.Next.RollNumber != rollNumber)
            current = current.Next;

        if (current.Next != null)
            current.Next = current.Next.Next;
    }

    public Student SearchByRollNumber(int rollNumber)
    {
        Student current = head;
        while (current != null)
        {
            if (current.RollNumber == rollNumber)
                return current;
            current = current.Next;
        }
        return null;
    }

    public void UpdateGrade(int rollNumber, string newGrade)
    {
        Student student = SearchByRollNumber(rollNumber);
        if (student != null)
            student.Grade = newGrade;
    }

    public void DisplayAll()
    {
        Student current = head;
        while (current != null)
        {
            Console.WriteLine($"Roll: {current.RollNumber}, Name: {current.Name}, Age: {current.Age}, Grade: {current.Grade}");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentList list = new StudentList();
        
        list.AddAtEnd(1, "Rajesh", 20, "A");
        list.AddAtEnd(2, "Priyanka", 21, "B");
        list.AddAtBeginning(3, "Sumit", 19, "A");
        
        Console.WriteLine("All Students:");
        list.DisplayAll();
        
        list.UpdateGrade(2, "A");
        Console.WriteLine("\nAfter updating Rajesh's grade:");
        list.DisplayAll();
        
        list.DeleteByRollNumber(1);
        Console.WriteLine("\nAfter deleting Priyanka's record:");
        list.DisplayAll();
    }
}