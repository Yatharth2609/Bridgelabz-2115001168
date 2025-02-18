using System;
using System.Collections.Generic;
using System.Linq;

public abstract class CourseType
{
    public string Name { get; set; }
    public abstract double CalculateGrade();
}

public class ExamCourse : CourseType
{
    public List<double> ExamScores { get; set; } = new List<double>();
    
    public override double CalculateGrade()
    {
        return ExamScores.Count > 0 ? ExamScores.Average() : 0;
    }
}

public class AssignmentCourse : CourseType
{
    public List<double> AssignmentScores { get; set; } = new List<double>();
    public double ParticipationScore { get; set; }
    
    public override double CalculateGrade()
    {
        double assignmentAverage = AssignmentScores.Count > 0 ? AssignmentScores.Average() : 0;
        return assignmentAverage * 0.8 + ParticipationScore * 0.2;
    }
}

public class ProjectCourse : CourseType
{
    public double ProjectScore { get; set; }
    public double PresentationScore { get; set; }
    
    public override double CalculateGrade()
    {
        return ProjectScore * 0.7 + PresentationScore * 0.3;
    }
}

public class Course<T> where T : CourseType
{
    public string CourseId { get; set; }
    public string Title { get; set; }
    public T CourseDetails { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    
    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }
    
    public void UnenrollStudent(Student student)
    {
        EnrolledStudents.Remove(student);
    }
    
    public double GetStudentGrade()
    {
        return CourseDetails.CalculateGrade();
    }
}

public class Department
{
    public string Name { get; set; }
    public List<ICourseContainer> Courses { get; set; } = new List<ICourseContainer>();
    
    public void AddCourse<T>(Course<T> course) where T : CourseType
    {
        Courses.Add(new CourseContainer<T>(course));
    }
    
    public List<string> GetAllCourseNames()
    {
        return Courses.Select(c => c.GetCourseTitle()).ToList();
    }
}

public interface ICourseContainer
{
    string GetCourseTitle();
    string GetCourseId();
    List<Student> GetEnrolledStudents();
}

public class CourseContainer<T> : ICourseContainer where T : CourseType
{
    private readonly Course<T> _course;
    
    public CourseContainer(Course<T> course)
    {
        _course = course;
    }
    
    public string GetCourseTitle() => _course.Title;
    public string GetCourseId() => _course.CourseId;
    public List<Student> GetEnrolledStudents() => _course.EnrolledStudents;
}

public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
}

public class University
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; } = new List<Department>();
    
    public void AddDepartment(Department department)
    {
        Departments.Add(department);
    }
    
    public List<string> GetAllCoursesFromAllDepartments()
    {
        return Departments.SelectMany(d => d.GetAllCourseNames()).ToList();
    }
}

class Program
{
    static void Main()
    {
        University university = new University { Name = "Tech University" };
        
        Department computerScience = new Department { Name = "Computer Science" };
        Department mathematics = new Department { Name = "Mathematics" };
        
        var algorithmsCourse = new Course<ExamCourse>
        {
            CourseId = "CS101",
            Title = "Algorithms",
            CourseDetails = new ExamCourse { Name = "Algorithms", ExamScores = new List<double> { 85, 90 } }
        };
        
        var programmingCourse = new Course<AssignmentCourse>
        {
            CourseId = "CS102",
            Title = "Programming",
            CourseDetails = new AssignmentCourse
            {
                Name = "Programming",
                AssignmentScores = new List<double> { 88, 92, 78 },
                ParticipationScore = 95
            }
        };
        
        var calculusCourse = new Course<ExamCourse>
        {
            CourseId = "MATH101",
            Title = "Integration",
            CourseDetails = new ExamCourse { Name = "Integration", ExamScores = new List<double> { 75, 82 } }
        };
        
        var capstoneProject = new Course<ProjectCourse>
        {
            CourseId = "CS400",
            Title = "Java",
            CourseDetails = new ProjectCourse
            {
                Name = "Java",
                ProjectScore = 92,
                PresentationScore = 88
            }
        };
        
        Student student1 = new Student { StudentId = "S001", Name = "Priya" };
        Student student2 = new Student { StudentId = "S002", Name = "Rakesh" };
        
        algorithmsCourse.EnrollStudent(student1);
        algorithmsCourse.EnrollStudent(student2);
        programmingCourse.EnrollStudent(student1);
        calculusCourse.EnrollStudent(student2);
        capstoneProject.EnrollStudent(student1);
        
        computerScience.AddCourse(algorithmsCourse);
        computerScience.AddCourse(programmingCourse);
        computerScience.AddCourse(capstoneProject);
        mathematics.AddCourse(calculusCourse);
        
        university.AddDepartment(computerScience);
        university.AddDepartment(mathematics);
        
        List<string> allCourses = university.GetAllCoursesFromAllDepartments();
        foreach (var course in allCourses)
        {
            Console.WriteLine(course);
        }
        
        Console.WriteLine($"Algorithm Grade: {algorithmsCourse.GetStudentGrade()}");
        Console.WriteLine($"Programming Grade: {programmingCourse.GetStudentGrade()}");
        Console.WriteLine($"Calculus Grade: {calculusCourse.GetStudentGrade()}");
        Console.WriteLine($"Capstone Project Grade: {capstoneProject.GetStudentGrade()}");
    }
}