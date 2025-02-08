using System;

public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, ID: {Id}");
    }
}

public interface Worker
{
    void PerformDuties();
}

public class Chef : Person, Worker
{
    public string Specialization { get; set; }

    public Chef(string name, int id, string specialization) : base(name, id)
    {
        Specialization = specialization;
    }

    public void PerformDuties()
    {
        Console.WriteLine($"{Name} is cooking {Specialization} dishes.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Chef, Specialization: {Specialization}");
    }
}

public class Waiter : Person, Worker
{
    public int TablesAssigned { get; set; }

    public Waiter(string name, int id, int tablesAssigned) : base(name, id)
    {
        TablesAssigned = tablesAssigned;
    }

    public void PerformDuties()
    {
        Console.WriteLine($"{Name} is serving {TablesAssigned} tables.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Role: Waiter, Tables Assigned: {TablesAssigned}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker chef = new Chef("Ranveer Brar", 101, "Indian");
        Worker waiter = new Waiter("Ramesh", 102, 5);

        chef.PerformDuties();
        waiter.PerformDuties();

        ((Person)chef).DisplayDetails();
        ((Person)waiter).DisplayDetails();
    }
}