using System;

class Vehicle
{

    private static double RegistrationFee = 5000.0; 

    public readonly string RegistrationNumber;
    public string OwnerName;
    public string VehicleType;

    public Vehicle(string RegistrationNumber, string OwnerName, string VehicleType)
    {
        this.RegistrationNumber = RegistrationNumber;
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        if (newFee >= 0)
        {
            RegistrationFee = newFee;
            Console.WriteLine($"Registration fee updated to: {RegistrationFee:C}");
        }
        else
        {
            Console.WriteLine("Invalid fee amount. It must be non-negative.");
        }
    }

    // Method to display vehicle details using 'is' operator
    public void DisplayVehicleDetails()
    {
        if (this is Vehicle)
        {
            Console.WriteLine($"Registration Number: {RegistrationNumber}");
            Console.WriteLine($"Owner Name: {OwnerName}");
            Console.WriteLine($"Vehicle Type: {VehicleType}");
            Console.WriteLine($"Registration Fee: {RegistrationFee:C}");
        }
    }
}

class Program
{
    static void Main()
    {

        Vehicle vehicle1 = new Vehicle("MH12AB1234", "Laxam", "Car");
        Vehicle vehicle2 = new Vehicle("DL8CXY5678", "Sunita", "Motorcycle");

        Console.WriteLine("Before Changing Registration Fee:");
        vehicle1.DisplayVehicleDetails();
        Console.WriteLine();
        vehicle2.DisplayVehicleDetails();

        Console.WriteLine("\nUpdating Registration Fee...\n");

        Vehicle.UpdateRegistrationFee(6000.0);

        Console.WriteLine("\nAfter Changing Registration Fee:");
        vehicle1.DisplayVehicleDetails();
        Console.WriteLine();
        vehicle2.DisplayVehicleDetails();
    }
}
