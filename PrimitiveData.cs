using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.dat";

        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                Console.Write("Enter roll number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter GPA: ");
                float gpa = float.Parse(Console.ReadLine());

                writer.Write(rollNumber);
                writer.Write(name);
                writer.Write(gpa);
            }

            Console.WriteLine("Student details saved successfully.");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                int rollNumber = reader.ReadInt32();
                string name = reader.ReadString();
                float gpa = reader.ReadSingle();

                Console.WriteLine("\nRetrieved Student Details:");
                Console.WriteLine($"Roll Number: {rollNumber}");
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"GPA: {gpa}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
