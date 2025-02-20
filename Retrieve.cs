using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

[Serializable]
class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}

class Program
{
    static void Main()
    {
        string filePath = "employees.dat";
        List<Employee> employees = new List<Employee>();
        
        try
        {
            Console.Write("Enter number of employees: ");
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                
                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());
                
                Console.Write("Enter position: ");
                string position = Console.ReadLine();
                
                employees.Add(new Employee { Name = name, Age = age, Position = position });
            }
            
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, employees);
            }
            
            Console.WriteLine("Employees saved successfully.");

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                List<Employee> loadedEmployees = (List<Employee>)formatter.Deserialize(stream);
                Console.WriteLine("\nRetrieved Employees:");
                foreach (var emp in loadedEmployees)
                {
                    Console.WriteLine($"Name: {emp.Name}, Age: {emp.Age}, Position: {emp.Position}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
