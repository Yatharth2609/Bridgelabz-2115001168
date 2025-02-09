public struct Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}

public abstract class Vehicle
{
    private string vehicleId;
    private string driverName;
    private string licenseNumber;
    private double ratePerKm;
    private bool isAvailable;

    public Vehicle(string vehicleId, string driverName, string licenseNumber, double ratePerKm)
    {
        this.vehicleId = vehicleId;
        this.driverName = driverName;
        this.licenseNumber = licenseNumber;
        this.ratePerKm = ratePerKm;
        this.isAvailable = true;
    }

    public string VehicleId => vehicleId;
    public string DriverName => driverName;
    public double RatePerKm => ratePerKm;
    public bool IsAvailable
    {
        get => isAvailable;
        set => isAvailable = value;
    }

    public abstract double CalculateFare(double distance);

    public string GetVehicleDetails()
    {
        return $"Vehicle ID: {vehicleId}\nDriver: {driverName}\nLicense: {licenseNumber}\nRate per km: {ratePerKm:C}";
    }
}

public interface IGPS
{
    Location GetCurrentLocation();
    void UpdateLocation(Location newLocation);
}

public class Car : Vehicle, IGPS
{
    private string model;
    private bool hasAC;
    private Location currentLocation;

    public Car(string vehicleId, string driverName, string licenseNumber, string model, bool hasAC)
        : base(vehicleId, driverName, licenseNumber, 2.0)
    {
        this.model = model;
        this.hasAC = hasAC;
        this.currentLocation = new Location(0, 0);
    }

    public override double CalculateFare(double distance)
    {
        double baseFare = distance * RatePerKm;
        double acCharge = hasAC ? baseFare * 0.2 : 0;
        return baseFare + acCharge + 5.0;
    }

    public Location GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(Location newLocation)
    {
        currentLocation = newLocation;
    }
}

public class Bike : Vehicle, IGPS
{
    private Location currentLocation;

    public Bike(string vehicleId, string driverName, string licenseNumber)
        : base(vehicleId, driverName, licenseNumber, 1.0)
    {
        this.currentLocation = new Location(0, 0);
    }

    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm + 2.0;
    }

    public Location GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(Location newLocation)
    {
        currentLocation = newLocation;
    }
}

public class Auto : Vehicle, IGPS
{
    private Location currentLocation;

    public Auto(string vehicleId, string driverName, string licenseNumber)
        : base(vehicleId, driverName, licenseNumber, 1.5)
    {
        this.currentLocation = new Location(0, 0);
    }

    public override double CalculateFare(double distance)
    {
        return distance * RatePerKm + 3.0;
    }

    public Location GetCurrentLocation()
    {
        return currentLocation;
    }

    public void UpdateLocation(Location newLocation)
    {
        currentLocation = newLocation;
    }
}

public class RideHailingApp
{
    private List<Vehicle> vehicles;
    private Dictionary<string, List<string>> rideHistory;

    public RideHailingApp()
    {
        vehicles = new List<Vehicle>();
        rideHistory = new Dictionary<string, List<string>>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void BookRide(string userId, string vehicleId, double distance)
    {
        var vehicle = vehicles.Find(v => v.VehicleId == vehicleId && v.IsAvailable);
        
        if (vehicle == null)
        {
            Console.WriteLine("Vehicle not available");
            return;
        }

        double fare = vehicle.CalculateFare(distance);
        vehicle.IsAvailable = false;

        if (!rideHistory.ContainsKey(userId))
            rideHistory[userId] = new List<string>();

        string rideDetails = $"Vehicle: {vehicleId}, Distance: {distance}km, Fare: {fare:C}";
        rideHistory[userId].Add(rideDetails);

        Console.WriteLine($"\nRide Booked:\n{vehicle.GetVehicleDetails()}\nFare: {fare:C}");

        if (vehicle is IGPS gps)
        {
            Location rideLocation = gps.GetCurrentLocation();
            Console.WriteLine($"Current Location: {rideLocation.Latitude}, {rideLocation.Longitude}");
        }
    }

    public static void Main()
    {
        RideHailingApp app = new RideHailingApp();

        app.AddVehicle(new Car("C001", "Harry", "DL001", "Skoda Kushaq", true));
        app.AddVehicle(new Bike("B001", "Priya", "DL002"));
        app.AddVehicle(new Auto("A001", "Sujal", "DL003"));

        app.BookRide("USER001", "C001", 10.5);
        app.BookRide("USER001", "B001", 5.0);
        app.BookRide("USER002", "A001", 7.5);
    }
}