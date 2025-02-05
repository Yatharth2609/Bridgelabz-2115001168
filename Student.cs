using System;
using System.Collections.Generic;

class Course
{
    public string CourseName { get; }
    private List<Student> enrolledStudents;

    public Course(string courseName)
    {
        CourseName = courseName;
        enrolledStudents = new List<Student>();
    }

    public void EnrollStudent(Student student)
    {
        if (!enrolledStudents.Contains(student))
        {
            enrolledStudents.Add(student);
            student.AddCourse(this);
        }
    }

    public void DisplayStudents()
    {
        Console.WriteLine($"\nCourse: {CourseName} - Enrolled Students:");
        if (enrolledStudents.Count == 0)
        {
            Console.WriteLine(" No students enrolled.");
            return;
        }
        foreach (var student in enrolledStudents)
        {
            Console.WriteLine($" - {student.Name}");
        }
    }
}

class Student
{
    public string Name { get; }
    private List<Course> enrolledCourses;

    public Student(string name)
    {
        Name = name;
        enrolledCourses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        if (!enrolledCourses.Contains(course))
        {
            enrolledCourses.Add(course);
        }
    }

    public void DisplayCourses()
    {
        Console.WriteLine($"\nStudent: {Name} - Enrolled Courses:");
        if (enrolledCourses.Count == 0)
        {
            Console.WriteLine(" No courses enrolled.");
            return;
        }
        foreach (var course in enrolledCourses)
        {
            Console.WriteLine($" - {course.CourseName}");
        }
    }
}

class School
{
    public string Name { get; }
    private List<Student> students;
    private List<Course> courses;

    public School(string name)
    {
        Name = name;
        students = new List<Student>();
        courses = new List<Course>();
    }

    public void AddStudent(Student student)
    {
        if (!students.Contains(student))
        {
            students.Add(student);
        }
    }

    public void AddCourse(Course course)
    {
        if (!courses.Contains(course))
        {
            courses.Add(course);
        }
    }

    public void EnrollStudentInCourse(Student student, Course course)
    {
        if (students.Contains(student) && courses.Contains(course))
        {
            course.EnrollStudent(student);
        }
        else
        {
            Console.WriteLine("Student or Course not found in the school.");
        }
    }

    public void DisplaySchoolInfo()
    {
        Console.WriteLine($"\nSchool: {Name}");

        Console.WriteLine("\nStudents:");
        if (students.Count == 0)
            Console.WriteLine(" No students registered.");
        foreach (var student in students)
            Console.WriteLine($" - {student.Name}");

        Console.WriteLine("\nCourses:");
        if (courses.Count == 0)
            Console.WriteLine(" No courses available.");
        foreach (var course in courses)
            Console.WriteLine($" - {course.CourseName}");
    }
}


class Program
{
    static void Main()
    {
        // Creating a School
        School mySchool = new School("Greenwood High");

        Student student1 = new Student("Rajiv");
        Student student2 = new Student("Priyanka");

        Course course1 = new Course("Mathematics");
        Course course2 = new Course("Physics");

        mySchool.AddStudent(student1);
        mySchool.AddStudent(student2);
        mySchool.AddCourse(course1);
        mySchool.AddCourse(course2);

        mySchool.EnrollStudentInCourse(student1, course1);
        mySchool.EnrollStudentInCourse(student1, course2);
        mySchool.EnrollStudentInCourse(student2, course1);
        mySchool.DisplaySchoolInfo();

        student1.DisplayCourses();
        student2.DisplayCourses();

        course1.DisplayStudents();
        course2.DisplayStudents();
    }
}
