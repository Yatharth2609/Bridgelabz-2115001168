using System;
using System.Collections.Generic;

class Product
{
    public string name { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }

}

class Customer
{
    public string name { get; set; }
    public List<Product> Products { get; set; }

    public Customer(string name)
    {
        this.name = name;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);

    }
}

class BillGenerator {
    public static double GenerateBill(Customer customer) {
        if(customer.Products.Count == 0)
            return 0;

        double total = 0;

        foreach (var product in customer.Products) {
            total += product.price * product.quantity;
        }

        return total;
    }
}

class Program {
    public static void Main(string[] args) {
        Customer customer = new Customer("Alice");
        customer.AddProduct(new Product("Apples", 3, 2));
        customer.AddProduct(new Product("Milk", 2, 1));

        double totalBill = BillGenerator.GenerateBill(customer);

        Console.WriteLine($"Customer: {customer.name}");
        Console.WriteLine($"Item Purchased: ");
        foreach (var product in customer.Products) {
            Console.WriteLine($"{product.name} - {product.quantity} x USD {product.price}");
        }
        Console.WriteLine($"Total Bill: USD {totalBill}");
    }
}