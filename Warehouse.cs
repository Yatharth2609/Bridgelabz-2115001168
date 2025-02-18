using System;
using System.Collections.Generic;

abstract class WarehouseItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}

class Electronics : WarehouseItem { }
class Groceries : WarehouseItem { }
class Furniture : WarehouseItem { }

class Storage<T> where T : WarehouseItem
{
    private List<T> items = new List<T>();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void DisplayItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"Name: {item.Name}, Quantity: {item.Quantity}");
        }
    }
}

class Program
{
    static void Main()
    {
        Storage<WarehouseItem> warehouse = new Storage<WarehouseItem>();

        warehouse.AddItem(new Electronics { Name = "Banana", Quantity = 10 });
        warehouse.AddItem(new Groceries { Name = "Apples", Quantity = 50 });
        warehouse.AddItem(new Furniture { Name = "Strawberry", Quantity = 30 });

        warehouse.DisplayItems();
    }
}