// using System;

// public class Student {
//     protected int rollNumber;
//     protected string name;
//     protected double CGPA;

//     public Student(int rollNumber, string name, double CGPA) {
//         this.rollNumber = rollNumber;
//         this.name = name;
//         this.CGPA = CGPA;
//     }

//     public void ModifyCGPA(double newCGPA) {
//         this.CGPA = newCGPA;
//     }

//     public void DisplayDetails() {
//         Console.WriteLine("Student Roll Number:  " + rollNumber);
//         Console.WriteLine("Student Name: " + name);
//         Console.WriteLine("Student CGPA: " + CGPA);
//     }
// }

// class PostgraduateStudent : Student {
//     public PostgraduateStudent(int rollNumber, string name, double CGPA) : base(rollNumber, name, CGPA) {
//     }

//     public new void DisplayDetails() {
//         Console.WriteLine("Postgraduate Student Details:");
//         base.DisplayDetails();
//     }
// }

// class Program {
//     public static void Main(string[] args) {
//         Student student = new Student(1, "John Doe", 8.0);
//         student.DisplayDetails();
//         student.ModifyCGPA(8.5);

//         PostgraduateStudent postgraduateStudent = new PostgraduateStudent(2, "Jane Doe", 9.0);
//         postgraduateStudent.DisplayDetails();
//     }
// }
