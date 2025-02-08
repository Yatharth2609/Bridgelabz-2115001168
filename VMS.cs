using System;

public class Vehicle
{
    public int MaxSpeed { get; set; }
    public string Model { get; set; }

    public Vehicle(int maxSpeed, string model)
    {
        MaxSpeed = maxSpeed;
        Model = model;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}, Max Speed: {MaxSpeed} km/h");
    }
}

public interface Refuelable
{
    void Refuel();
}

public class ElectricVehicle : Vehicle
{
    public ElectricVehicle(int maxSpeed, string model) : base(maxSpeed, model) { }

    public void Charge()
    {
        Console.WriteLine($"{Model} is charging.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Type: Electric Vehicle");
    }
}

public class PetrolVehicle : Vehicle, Refuelable
{
    public PetrolVehicle(int maxSpeed, string model) : base(maxSpeed, model) { }

    public void Refuel()
    {
        Console.WriteLine($"{Model} is refueling with petrol.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Type: Petrol Vehicle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ElectricVehicle electricCar = new ElectricVehicle(180, "Mahindra BEX6");
        PetrolVehicle petrolCar = new PetrolVehicle(220, "Honda City");

        electricCar.DisplayDetails();
        electricCar.Charge();

        petrolCar.DisplayDetails();
        petrolCar.Refuel();
    }
}