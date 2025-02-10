using System;
using System.Collections.Generic;
using System.Linq;

class InventoryItem
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public InventoryItem Next { get; set; }

    public InventoryItem(string name, int id, int quantity, decimal price)
    {
        Name = name;
        Id = id;
        Quantity = quantity;
        Price = price;
        Next = null;
    }
}

class Inventory
{
    private InventoryItem head;

    public void AddAtBeginning(string name, int id, int quantity, decimal price)
    {
        InventoryItem newItem = new InventoryItem(name, id, quantity, price);
        newItem.Next = head;
        head = newItem;
    }

    public void AddAtEnd(string name, int id, int quantity, decimal price)
    {
        InventoryItem newItem = new InventoryItem(name, id, quantity, price);
        if (head == null)
        {
            head = newItem;
            return;
        }

        InventoryItem current = head;
        while (current.Next != null)
            current = current.Next;
        current.Next = newItem;
    }

    public void AddAtPosition(int position, string name, int id, int quantity, decimal price)
    {
        if (position < 1) return;
        if (position == 1)
        {
            AddAtBeginning(name, id, quantity, price);
            return;
        }

        InventoryItem newItem = new InventoryItem(name, id, quantity, price);
        InventoryItem current = head;
        for (int i = 1; i < position - 1 && current != null; i++)
            current = current.Next;

        if (current == null) return;
        newItem.Next = current.Next;
        current.Next = newItem;
    }

    public void RemoveById(int id)
    {
        if (head == null) return;

        if (head.Id == id)
        {
            head = head.Next;
            return;
        }

        InventoryItem current = head;
        while (current.Next != null && current.Next.Id != id)
            current = current.Next;

        if (current.Next != null)
            current.Next = current.Next.Next;
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
        InventoryItem item = SearchById(id);
        if (item != null)
            item.Quantity = newQuantity;
    }

    public InventoryItem SearchById(int id)
    {
        InventoryItem current = head;
        while (current != null)
        {
            if (current.Id == id)
                return current;
            current = current.Next;
        }
        return null;
    }

    public List<InventoryItem> SearchByName(string name)
    {
        List<InventoryItem> results = new List<InventoryItem>();
        InventoryItem current = head;
        while (current != null)
        {
            if (current.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public decimal CalculateTotalValue()
    {
        decimal total = 0;
        InventoryItem current = head;
        while (current != null)
        {
            total += current.Price * current.Quantity;
            current = current.Next;
        }
        return total;
    }

    public void Sort(string criteria, bool ascending = true)
    {
        if (head == null || head.Next == null) return;

        List<InventoryItem> items = new List<InventoryItem>();
        InventoryItem current = head;
        while (current != null)
        {
            items.Add(current);
            current = current.Next;
        }

        if (criteria.Equals("name", StringComparison.OrdinalIgnoreCase))
            items = ascending ? items.OrderBy(x => x.Name).ToList() : items.OrderByDescending(x => x.Name).ToList();
        else if (criteria.Equals("price", StringComparison.OrdinalIgnoreCase))
            items = ascending ? items.OrderBy(x => x.Price).ToList() : items.OrderByDescending(x => x.Price).ToList();

        for (int i = 0; i < items.Count - 1; i++)
            items[i].Next = items[i + 1];
        items[items.Count - 1].Next = null;
        head = items[0];
    }

    public void DisplayInventory()
    {
        InventoryItem current = head;
        while (current != null)
        {
            Console.WriteLine($"ID: {current.Id}, Name: {current.Name}, Quantity: {current.Quantity}, Price: {current.Price:C}");
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();
        
        inventory.AddAtEnd("Laptop", 1, 10, 999.99m);
        inventory.AddAtEnd("Mouse", 2, 50, 29.99m);
        inventory.AddAtBeginning("Keyboard", 3, 30, 59.99m);
        
        Console.WriteLine("Original Inventory:");
        inventory.DisplayInventory();
        
        inventory.Sort("price", true);
        Console.WriteLine("\nSorted by Price (Ascending):");
        inventory.DisplayInventory();
        
        Console.WriteLine($"\nTotal Inventory Value: {inventory.CalculateTotalValue():C}");
    }
}