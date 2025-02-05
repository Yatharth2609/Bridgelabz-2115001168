using System;
using System.Collections.Generic;

class Student
{
    public int Id { get; }
    public string Name { get; }
    private List<Course> enrolledCourses;

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
        enrolledCourses = new List<Course>();
    }

    public void EnrollCourse(Course course)
    {
        if (!enrolledCourses.Contains(course))
        {
            enrolledCourses.Add(course);
            course.AddStudent(this);
            Console.WriteLine($"{Name} has enrolled in {course.CourseName}");
        }
    }

    public void DisplayEnrolledCourses()
    {
        Console.WriteLine($"\n{Name}'s Enrolled Courses:");
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

class Professor
{
    public int Id { get; }
    public string Name { get; }
    private List<Course> teachingCourses;

    public Professor(int id, string name)
    {
        Id = id;
        Name = name;
        teachingCourses = new List<Course>();
    }

    public void AssignProfessor(Course course)
    {
        if (!teachingCourses.Contains(course))
        {
            teachingCourses.Add(course);
            course.SetProfessor(this);
            Console.WriteLine($"{Name} has been assigned to teach {course.CourseName}");
        }
    }

    public void DisplayTeachingCourses()
    {
        Console.WriteLine($"\nProfessor {Name} is Teaching:");
        if (teachingCourses.Count == 0)
        {
            Console.WriteLine(" No courses assigned.");
            return;
        }
        foreach (var course in teachingCourses)
        {
            Console.WriteLine($" - {course.CourseName}");
        }
    }
}

class Course
{
    public int CourseId { get; }
    public string CourseName { get; }
    private Professor? professor;
    private List<Student> enrolledStudents;

    public Course(int courseId, string courseName)
    {
        CourseId = courseId;
        CourseName = courseName;
        enrolledStudents = new List<Student>();
    }

    public void SetProfessor(Professor prof)
    {
        professor = prof;
    }

    public void AddStudent(Student student)
    {
        if (!enrolledStudents.Contains(student))
        {
            enrolledStudents.Add(student);
        }
    }

    public void DisplayCourseInfo()
    {
        Console.WriteLine($"\nCourse: {CourseName}");
        Console.WriteLine(" Professor: " + (professor != null ? professor.Name : "Not Assigned"));
        Console.WriteLine(" Enrolled Students:");
        if (enrolledStudents.Count == 0)
        {
            Console.WriteLine("  No students enrolled.");
            return;
        }
        foreach (var student in enrolledStudents)
        {
            Console.WriteLine($"  - {student.Name}");
        }
    }
}

class UniversityManagement
{
    private List<Student> students;
    private List<Professor> professors;
    private List<Course> courses;

    public UniversityManagement()
    {
        students = new List<Student>();
        professors = new List<Professor>();
        courses = new List<Course>();
    }

    public void AddStudent(Student student) => students.Add(student);
    public void AddProfessor(Professor professor) => professors.Add(professor);
    public void AddCourse(Course course) => courses.Add(course);

    public void DisplayAllCourses()
    {
        Console.WriteLine("\nAvailable Courses:");
        foreach (var course in courses)
        {
            Console.WriteLine($" - {course.CourseName}");
        }
    }
}

class Program
{
    static void Main()
    {
        UniversityManagement university = new UniversityManagement();

        Student student1 = new Student(201, "Harry");
        Student student2 = new Student(202, "Priya");

        university.AddStudent(student1);
        university.AddStudent(student2);

        Professor professor1 = new Professor(301, "Dr. Hitesh");
        Professor professor2 = new Professor(302, "Dr. Robin");

        university.AddProfessor(professor1);
        university.AddProfessor(professor2);

        Course math = new Course(101, "Mathematics");
        Course cs = new Course(102, "Computer Science");

        university.AddCourse(math);
        university.AddCourse(cs);

        professor1.AssignProfessor(math);
        professor2.AssignProfessor(cs);

        student1.EnrollCourse(math);
        student1.EnrollCourse(cs);
        student2.EnrollCourse(cs);

        university.DisplayAllCourses();
        student1.DisplayEnrolledCourses();
        student2.DisplayEnrolledCourses();
        professor1.DisplayTeachingCourses();
        professor2.DisplayTeachingCourses();
        math.DisplayCourseInfo();
        cs.DisplayCourseInfo();
    }
}
