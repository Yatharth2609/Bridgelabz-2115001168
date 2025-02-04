// public class CarRental {
//     private string customerName;
//     private string carModel;
//     private int rentalDays;
//     public static int RentalCost = 500;

//     public CarRental(string customerName, string carModel, int rentalDays) {
//         this.customerName = customerName;
//         this.carModel = carModel;
//         this.rentalDays = rentalDays;
//     }

//     public void CalculateRentalCost() {
//         Console.WriteLine($"Rental cost for {rentalDays} days is {rentalDays * RentalCost}");
//     }

//     public void DisplayDetails() {
//         Console.WriteLine("Car Rental Details:");
//         Console.WriteLine($"Customer Name: {customerName}");
//         Console.WriteLine($"Car Model: {carModel}");
//         Console.WriteLine($"Rental Days: {rentalDays}");
//     }

//     public static void Main(string[] args) {
//         CarRental rental1 = new CarRental("John Doe", "Toyota", 5);
//         rental1.DisplayDetails();

//         rental1.CalculateRentalCost();
//     }
// }