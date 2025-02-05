using System;
using System.Collections.Generic;

class Product
{
    public int Id { get; }
    public string Name { get; }
    public double Price { get; }

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public void DisplayProduct()
    {
        Console.WriteLine($" - {Name} (₹{Price})");
    }
}

class Order
{
    public int OrderId { get; }
    public Customer Customer { get; }
    private List<Product> products;

    public Order(int orderId, Customer customer)
    {
        OrderId = orderId;
        Customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"\nOrder ID: {OrderId} - Customer: {Customer.Name}");
        if (products.Count == 0)
        {
            Console.WriteLine(" No products in this order.");
            return;
        }
        Console.WriteLine(" Products:");
        foreach (var product in products)
            product.DisplayProduct();
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
            total += product.Price;
        return total;
    }
}

class Customer
{
    public int CustomerId { get; }
    public string Name { get; }
    private List<Order> orders;

    public Customer(int customerId, string name)
    {
        CustomerId = customerId;
        Name = name;
        orders = new List<Order>();
    }

    public void PlaceOrder(Order order)
    {
        orders.Add(order);
    }

    public void DisplayOrders()
    {
        Console.WriteLine($"\nCustomer: {Name} - Orders:");
        if (orders.Count == 0)
        {
            Console.WriteLine(" No orders placed.");
            return;
        }
        foreach (var order in orders)
        {
            order.DisplayOrder();
            Console.WriteLine($" Total Price: ₹{order.GetTotalPrice()}");
        }
    }
}

class ECommercePlatform
{
    private List<Customer> customers;
    private List<Product> products;

    public ECommercePlatform()
    {
        customers = new List<Customer>();
        products = new List<Product>();
    }

    public void AddCustomer(Customer customer)
    {
        if (!customers.Contains(customer))
            customers.Add(customer);
    }

    public void AddProduct(Product product)
    {
        if (!products.Contains(product))
            products.Add(product);
    }

    public void DisplayProducts()
    {
        Console.WriteLine("\nAvailable Products:");
        foreach (var product in products)
            product.DisplayProduct();
    }
}

class Program
{
    static void Main()
    {
        ECommercePlatform myStore = new ECommercePlatform();

        Product laptop = new Product(1, "Laptop", 50000);
        Product phone = new Product(2, "Smartphone", 25000);
        Product headphones = new Product(3, "Headphones", 3000);

        myStore.AddProduct(laptop);
        myStore.AddProduct(phone);
        myStore.AddProduct(headphones);

        Customer customer1 = new Customer(101, "Ramesh");
        Customer customer2 = new Customer(102, "Priya");

        myStore.AddCustomer(customer1);
        myStore.AddCustomer(customer2);

        Order order1 = new Order(1001, customer1);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        customer1.PlaceOrder(order1);

        Order order2 = new Order(1002, customer2);
        order2.AddProduct(phone);
        customer2.PlaceOrder(order2);

        myStore.DisplayProducts();

        customer1.DisplayOrders();
        customer2.DisplayOrders();
    }
}
