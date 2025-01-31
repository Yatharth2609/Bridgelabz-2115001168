using System;

public class Book {
    private string title;
    private string author;
    private int price;

    public Book(string title, string author, int price) {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void Display() {
        Console.WriteLine("Book Details:");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Price: {price:C}");
    }

    public static void Main(string[] args) {
        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine();
        Console.Write("Enter the price of the book: ");
        int price = int.Parse(Console.ReadLine());

        Book book1 = new Book(title, author, price);
        book1.Display();
    }
}