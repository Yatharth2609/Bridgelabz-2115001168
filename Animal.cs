using System;

public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

public class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} barks");
    }
}

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} meows");
    }
}

public class Bird : Animal
{
    public Bird(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} chirps");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal myDog = new Dog("Sheru", 3);
        Animal myCat = new Cat("Tommy", 5);
        Animal myBird = new Bird("Tappu", 2);

        myDog.MakeSound();
        myCat.MakeSound();
        myBird.MakeSound();
    }
}

