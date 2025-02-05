using System;
using System.Collections.Generic;

class BankAccount
{
    public string AccountNumber { get; }
    public double Balance { get; private set; }
    public Bank Bank { get; }
    public Customer Customer { get; }

    public BankAccount(string accountNumber, double initialBalance, Bank bank, Customer customer)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Bank = bank;
        Customer = customer;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C} into Account {AccountNumber}. New Balance: {Balance:C}");
    }

    public void Withdraw(double amount)
    {
        if (amount > Balance)
            Console.WriteLine($"Insufficient balance in Account {AccountNumber}.");
        else
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C} from Account {AccountNumber}. New Balance: {Balance:C}");
        }
    }

    public void DisplayAccountDetails()
    {
        Console.WriteLine($"Account: {AccountNumber}, Balance: {Balance:C}, Bank: {Bank.Name}, Customer: {Customer.Name}");
    }
}

class Customer
{
    public string Name { get; }
    private List<BankAccount> accounts;

    public Customer(string name)
    {
        Name = name;
        accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account)
    {
        accounts.Add(account);
    }

    public void ViewBalance()
    {
        Console.WriteLine($"\nCustomer: {Name}'s Accounts:");
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found.");
            return;
        }
        foreach (var account in accounts)
        {
            account.DisplayAccountDetails();
        }
    }
}

class Bank
{
    public string Name { get; }
    private List<Customer> customers;

    public Bank(string name)
    {
        Name = name;
        customers = new List<Customer>();
    }

    public BankAccount OpenAccount(Customer customer, double initialDeposit)
    {
        string accountNumber = $"AC-{customers.Count + 1:000}";
        BankAccount account = new BankAccount(accountNumber, initialDeposit, this, customer);
        customer.AddAccount(account);
        if (!customers.Contains(customer))
        {
            customers.Add(customer);
        }
        Console.WriteLine($"Account {accountNumber} opened for {customer.Name} at {Name} with initial deposit of {initialDeposit:C}");
        return account;
    }
}

class Program
{
    static void Main()
    {
        Bank bank1 = new Bank("State Bank");
        Bank bank2 = new Bank("National Bank");

        Customer customer1 = new Customer("Tarun");
        Customer customer2 = new Customer("Harry");

        BankAccount acc1 = bank1.OpenAccount(customer1, 5000);
        BankAccount acc2 = bank1.OpenAccount(customer2, 3000);
        BankAccount acc3 = bank2.OpenAccount(customer1, 7000);

        acc1.Deposit(2000);
        acc2.Withdraw(1500);
        acc3.Withdraw(8000);

        customer1.ViewBalance();
        customer2.ViewBalance();
    }
}
