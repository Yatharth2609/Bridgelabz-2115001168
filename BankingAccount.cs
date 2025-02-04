using System;

class BankAccount
{
    private static string bankName = "Axis Bank";
    private static int totalAccounts = 0;

    public readonly int AccountNumber;
    public string AccountHolderName;
    public double Balance;

    // Static property to get or update the bank name
    public static string BankName
    {
        get { return bankName; }
        set 
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                bankName = value;
                Console.WriteLine($"Bank name updated to: {bankName}");
            }
            else
            {
                Console.WriteLine("Bank name cannot be empty.");
            }
        }
    }

    public BankAccount(string AccountHolderName, int AccountNumber, double initialBalance)
    {
        this.AccountHolderName = AccountHolderName;
        this.AccountNumber = AccountNumber;
        this.Balance = initialBalance;
        totalAccounts++;
    }

    // Static method to get total number of accounts
    public static void GetTotalAccounts()
    {
        Console.WriteLine($"Total Bank Accounts: {totalAccounts}");
    }

    // Method to display account details using 'is' operator
    public void DisplayAccountDetails()
    {
        if (this is BankAccount)
        {
            Console.WriteLine($"Bank Name: {bankName}");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }

    // Method to deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}. New Balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid withdrawal amount.");
        }
    }
}

class Program
{
    static void Main()
    {
   
        BankAccount acc1 = new BankAccount("Rajiv", 1001, 5000);
        BankAccount acc2 = new BankAccount("Priya", 1002, 3000);


        Console.WriteLine("Before Changing Bank Name:");
        acc1.DisplayAccountDetails();
        Console.WriteLine();
        acc2.DisplayAccountDetails();

        Console.WriteLine("\nChanging Bank Name...\n");
        
    
        BankAccount.BankName = "ICICI Bank";

        Console.WriteLine("\nAfter Changing Bank Name:");
        acc1.DisplayAccountDetails();
        Console.WriteLine();
        acc2.DisplayAccountDetails();
        
        Console.WriteLine();

        BankAccount.GetTotalAccounts();
    }
}
