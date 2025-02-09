public abstract class Vehicle
{
    private string vehicleNumber;
    private string type;
    private decimal rentalRate;
    private string insurancePolicyNumber;

    public Vehicle(string vehicleNumber, string type, decimal rentalRate)
    {
        this.vehicleNumber = vehicleNumber;
        this.type = type;
        this.rentalRate = rentalRate;
        this.insurancePolicyNumber = Guid.NewGuid().ToString();
    }

    public string VehicleNumber => vehicleNumber;
    public string Type => type;
    public decimal RentalRate => rentalRate;

    public abstract decimal CalculateRentalCost(int days);
}

public interface IInsurable
{
    decimal CalculateInsurance();
    string GetInsuranceDetails();
}

public class Car : Vehicle, IInsurable
{
    private bool isLuxury;

    public Car(string vehicleNumber, decimal rentalRate, bool isLuxury) 
        : base(vehicleNumber, "Car", rentalRate)
    {
        this.isLuxury = isLuxury;
    }

    public override decimal CalculateRentalCost(int days)
    {
        decimal baseCost = RentalRate * days;
        return isLuxury ? baseCost * 1.2m : baseCost;
    }

    public decimal CalculateInsurance()
    {
        return isLuxury ? 50.0m : 30.0m;
    }

    public string GetInsuranceDetails()
    {
        return $"Standard car insurance with {(isLuxury ? "premium" : "basic")} coverage";
    }
}

public class Bike : Vehicle, IInsurable
{
    public Bike(string vehicleNumber, decimal rentalRate) 
        : base(vehicleNumber, "Bike", rentalRate)
    {
    }

    public override decimal CalculateRentalCost(int days)
    {
        return RentalRate * days;
    }

    public decimal CalculateInsurance()
    {
        return 15.0m;
    }

    public string GetInsuranceDetails()
    {
        return "Basic bike insurance coverage";
    }
}

public class Truck : Vehicle, IInsurable
{
    private decimal cargoCapacity;

    public Truck(string vehicleNumber, decimal rentalRate, decimal cargoCapacity) 
        : base(vehicleNumber, "Truck", rentalRate)
    {
        this.cargoCapacity = cargoCapacity;
    }

    public override decimal CalculateRentalCost(int days)
    {
        decimal baseCost = RentalRate * days;
        return baseCost + (cargoCapacity * 10.0m);
    }

    public decimal CalculateInsurance()
    {
        return 75.0m + (cargoCapacity * 0.5m);
    }

    public string GetInsuranceDetails()
    {
        return $"Commercial truck insurance with capacity coverage up to {cargoCapacity} tons";
    }
}

public class RentalSystem
{
    public static void Main()
    {
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Car("CAR001", 50.0m, true),
            new Car("CAR002", 30.0m, false),
            new Bike("BIKE001", 20.0m),
            new Truck("TRUCK001", 100.0m, 20.0m)
        };

        foreach (Vehicle vehicle in vehicles)
        {
            decimal rentalCost = vehicle.CalculateRentalCost(7);
            Console.WriteLine($"Vehicle {vehicle.VehicleNumber} ({vehicle.Type}):");
            Console.WriteLine($"Rental cost for 7 days: {rentalCost:C}");

            if (vehicle is IInsurable insurable)
            {
                decimal insuranceCost = insurable.CalculateInsurance();
                string insuranceDetails = insurable.GetInsuranceDetails();
                Console.WriteLine($"Insurance cost: {insuranceCost:C}");
                Console.WriteLine($"Insurance details: {insuranceDetails}");
            }
            Console.WriteLine();
        }
    }
}