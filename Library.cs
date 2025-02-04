// public class Library
// {
//     private string author;
//     private int price;
//     public static int availaibility = 10;

//     public Library(string author, int price) {
//         this.author = author;
//         this.price = price;
//     }

//     public void BorrowBook() {
//         if(availaibility > 0) {
//             availaibility--;
//             Console.WriteLine("Book borrowed successfully");
//         } else {
//             Console.WriteLine("Book not available");
//         }
//     }

//     public void DisplayDetails() {
//         Console.WriteLine("Book Details:");
//         Console.WriteLine($"Author: {author}");
//         Console.WriteLine($"Price: {price:C}");
//         Console.WriteLine($"Availability: {availaibility}");
//     }

//     public static void Main(string[] args) {
//         Library book1 = new Library("Author1", 100);
//         book1.DisplayDetails();

//         book1.BorrowBook();
//     }
// }