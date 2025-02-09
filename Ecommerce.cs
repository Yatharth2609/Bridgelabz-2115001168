using System;
using System.Collections.Generic;

abstract class Product
{
    private int productId;
    private string name;
    private double price;

    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public abstract double CalculateDiscount();
}

class Electronics : Product, ITaxable
{
    public override double CalculateDiscount()
    {
        return Price * 0.10;
    }

    public double CalculateTax()
    {
        return Price * 0.15;
    }

    public string GetTaxDetails()
    {
        return "Electronics Tax: 15%";
    }
}

class Clothing : Product, ITaxable
{
    public override double CalculateDiscount()
    {
        return Price * 0.05;
    }

    public double CalculateTax()
    {
        return Price * 0.10;
    }

    public string GetTaxDetails()
    {
        return "Clothing Tax: 10%";
    }
}

class Groceries : Product
{
    public override double CalculateDiscount()
    {
        return Price * 0.02;
    }
}

interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

class Program
{
    static void CalculateFinalPrice(List<Product> products)
    {
        foreach (var product in products)
        {
            double discount = product.CalculateDiscount();
            double tax = 0;

            if (product is ITaxable taxableProduct)
            {
                tax = taxableProduct.CalculateTax();
            }

            double finalPrice = product.Price + tax - discount;
            Console.WriteLine($"Product: {product.Name}, Final Price: {finalPrice}");
        }
    }

    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        Electronics laptop = new Electronics();
        laptop.ProductId = 1;
        laptop.Name = "Laptop";
        laptop.Price = 152000;
        products.Add(laptop);

        Clothing shirt = new Clothing();
        shirt.ProductId = 2;
        shirt.Name = "Shirt";
        shirt.Price = 500;
        products.Add(shirt);

        Groceries bread = new Groceries();
        bread.ProductId = 3;
        bread.Name = "Bread";
        bread.Price = 50;
        products.Add(bread);

        CalculateFinalPrice(products);
    }
}