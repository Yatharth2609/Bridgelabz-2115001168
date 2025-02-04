// public class Employee {
//     public int employeeId;
//     protected string department;
//     private int salary;

//     public Employee(int id, string dept, int sal) {
//         this.employeeId = id;
//         this.department = dept;
//         this.salary = sal;
//     }

//     public int modifySalary(int newSalary) {
//         this.salary = newSalary;
//         return this.salary;
//     }

//     public void displayDetails() {
//         Console.WriteLine("Employee Details: ");
//         Console.WriteLine("Employee ID: " + this.employeeId);
//         Console.WriteLine("Department: " + this.department);
//         Console.WriteLine("Salary: " + this.salary);
//     }

//     public static void Main(string[] args) {

//         Manager mgr = new Manager(2, "IT", 70000);
//         mgr.displayDetails();
//     }
// }

// public class Manager : Employee {
//     public Manager(int id, string dept, int sal) : base(id, dept, sal) {
//     }

//     public void displayDetails() {
//         Console.WriteLine("Manager Details: ");
//         base.displayDetails();
//     }
// }