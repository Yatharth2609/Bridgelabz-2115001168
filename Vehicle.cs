// public class Vehicle {
//     private string ownerName;
//     private string vehicleType;

//     public static int registrationFee;

//     public Vehicle(string ownerName, string vehicleType) {
//         this.ownerName = ownerName;
//         this.vehicleType = vehicleType;
//     }

//     public void DisplayVeicleDetails() {
//         Console.WriteLine("Owner Name: " + ownerName);
//         Console.WriteLine("Vehicle Type: " + vehicleType);
//     }

//     public void UpdateRegistrationFee(int newFee) {
//         registrationFee = newFee;
//     }

//     public static void Main(string[] args) {
//         Vehicle vehicle1 = new Vehicle("John Doe", "Car");
//         Vehicle vehicle2 = new Vehicle("Jane Smith", "Bike");

//         vehicle1.DisplayVeicleDetails();
//         Console.WriteLine("Registration Fee: " + Vehicle.registrationFee);

//         vehicle2.DisplayVeicleDetails();
//         Console.WriteLine("Registration Fee: " + Vehicle.registrationFee);
//     }
// }