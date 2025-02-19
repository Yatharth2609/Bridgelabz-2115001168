using System;
using System.Collections.Generic;
using System.Linq;

class ShoppingCart
{
    private Dictionary<string, double> productPrices = new Dictionary<string, double>();
    private LinkedList<string> productOrder = new LinkedList<string>();
    private SortedDictionary<string, double> sortedProducts = new SortedDictionary<string, double>();

    public void AddProduct(string product, double price)
    {
        if (!productPrices.ContainsKey(product))
        {
            productPrices[product] = price;
            sortedProducts[product] = price;
            productOrder.AddLast(product);
        }
    }

    public Dictionary<string, double> GetProducts()
    {
        return new Dictionary<string, double>(productPrices);
    }

    public SortedDictionary<string, double> GetSortedProducts()
    {
        return new SortedDictionary<string, double>(sortedProducts);
    }

    public List<string> GetProductOrder()
    {
        return productOrder.ToList();
    }

    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        cart.AddProduct("Laptop", 68000.99);
        cart.AddProduct("Phone", 19999.49);
        cart.AddProduct("Tablet", 32999.99);
        
        Console.WriteLine("Shopping Cart:");
        foreach (var item in cart.GetProducts())
            Console.WriteLine($"{item.Key}: {item.Value:C}");
        
        Console.WriteLine("\nSorted Products by Price:");
        foreach (var item in cart.GetSortedProducts().OrderBy(p => p.Value))
            Console.WriteLine($"{item.Key}: {item.Value:C}");
        
        Console.WriteLine("\nProduct Order:");
        foreach (var item in cart.GetProductOrder())
            Console.WriteLine(item);
    }
}