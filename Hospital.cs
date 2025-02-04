using System;

class Patient
{

    private static string HospitalName = "City General Hospital";
    private static int totalPatients = 0;


    public readonly int PatientID;
    public string Name;
    public int Age;
    public string Ailment;

    public static string Hospital
    {
        get { return HospitalName; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                HospitalName = value;
                Console.WriteLine($"Hospital name updated to: {HospitalName}");
            }
            else
            {
                Console.WriteLine("Hospital name cannot be empty.");
            }
        }
    }

    public Patient(int PatientID, string Name, int Age, string Ailment)
    {
        this.PatientID = PatientID;
        this.Name = Name;
        this.Age = Age;
        this.Ailment = Ailment;
        totalPatients++;
    }

    // Static method to display total number of admitted patients
    public static void GetTotalPatients()
    {
        Console.WriteLine($"Total Patients Admitted: {totalPatients}");
    }

    // Method to display patient details using 'is' operator
    public void DisplayPatientDetails()
    {
        if (this is Patient)
        {
            Console.WriteLine($"Hospital: {HospitalName}");
            Console.WriteLine($"Patient ID: {PatientID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Ailment: {Ailment}");
        }
    }
}

class Program
{
    static void Main()
    {

        Patient patient1 = new Patient(101, "Rajiv", 30, "Fever");
        Patient patient2 = new Patient(102, "Harry", 45, "Fracture");

        Console.WriteLine("Before Changing Hospital Name:");
        patient1.DisplayPatientDetails();
        Console.WriteLine();
        patient2.DisplayPatientDetails();

        Console.WriteLine("\nChanging Hospital Name...\n");

        Patient.Hospital = "Appolo Hospital";

        Console.WriteLine("\nAfter Changing Hospital Name:");
        patient1.DisplayPatientDetails();
        Console.WriteLine();
        patient2.DisplayPatientDetails();

        Console.WriteLine();

        Patient.GetTotalPatients();
    }
}
