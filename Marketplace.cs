using System;

class BookCategory { }
class ClothingCategory { }

class Product<T>
{
    public string Name { get; set; }
    public double Price { get; set; }
}

class Catalog
{
    public void ApplyDiscount<T>(Product<T> product, double percentage) where T : class
    {
        product.Price -= product.Price * (percentage / 100);
    }
}

class Program
{
    static void Main()
    {
        Catalog catalog = new Catalog();

        Product<BookCategory> book = new Product<BookCategory> { Name = "C# Programming", Price = 500 };
        Product<ClothingCategory> shirt = new Product<ClothingCategory> { Name = "T-Shirt", Price = 800 };

        catalog.ApplyDiscount(book, 10);
        catalog.ApplyDiscount(shirt, 15);

        Console.WriteLine($"Book: {book.Name}, Discounted Price: {book.Price:C}");
        Console.WriteLine($"Shirt: {shirt.Name}, Discounted Price: {shirt.Price:C}");
    }
}