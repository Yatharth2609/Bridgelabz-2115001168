// public class Product {
//     private string ProductName;
//     private int price;
//     public static int totalProducts = 10;

//     public Product(string productName, int price) {
//         this.ProductName = productName;
//         this.price = price;
//     }

//     public void DisplayProductDetails() {
//         Console.WriteLine($"Product Name: {ProductName}");
//         Console.WriteLine($"Price: {price:C}");
//     }

//     public static void DisplayTotalProducts() {
//         Console.WriteLine($"Total Products: {totalProducts}");
//     }


//     public static void Main(string[] args) {
//         Product product1 = new Product("Laptop", 1000);
//         Product product2 = new Product("Smartphone", 500);

//         product1.DisplayProductDetails();
//         DisplayTotalProducts();

//         Console.WriteLine();

//         product2.DisplayProductDetails();
//         DisplayTotalProducts();
//     }


// }