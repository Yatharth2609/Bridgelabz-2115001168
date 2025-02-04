// using System;

// // Base class
// public class BankAccount
// {
//     public int AccountNumber { get; set; }
//     protected string AccountHolder { get; set; }
//     private decimal balance;

//     public BankAccount(int accountNumber, string accountHolder, decimal initialBalance)
//     {
//         AccountNumber = accountNumber;
//         AccountHolder = accountHolder;
//         balance = initialBalance;
//     }

//     public decimal GetBalance()
//     {
//         return balance;
//     }

//     public void Deposit(decimal amount)
//     {
//         if (amount > 0)
//         {
//             balance += amount;
//             Console.WriteLine($"Deposited: {amount:C}. New Balance: {balance:C}");
//         }
//         else
//         {
//             Console.WriteLine("Deposit amount must be positive.");
//         }
//     }

//     public void Withdraw(decimal amount)
//     {
//         if (amount > 0 && amount <= balance)
//         {
//             balance -= amount;
//             Console.WriteLine($"Withdrawn: {amount:C}. New Balance: {balance:C}");
//         }
//         else
//         {
//             Console.WriteLine("Invalid withdrawal amount.");
//         }
//     }
// }

// // Derived class
// public class SavingsAccount : BankAccount
// {
//     public decimal InterestRate { get; set; }

//     public SavingsAccount(int accountNumber, string accountHolder, decimal initialBalance, decimal interestRate)
//         : base(accountNumber, accountHolder, initialBalance)
//     {
//         InterestRate = interestRate;
//     }

//     public void DisplayAccountDetails()
//     {
//         Console.WriteLine($"Account Number: {AccountNumber}");
//         Console.WriteLine($"Account Holder: {AccountHolder}"); // Accessible due to protected modifier
//         Console.WriteLine($"Balance: {GetBalance():C}");
//         Console.WriteLine($"Interest Rate: {InterestRate}%");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         SavingsAccount savings = new SavingsAccount(12345, "John Doe", 5000, 2.5m);
//         savings.DisplayAccountDetails();

//         savings.Deposit(1500);
//         savings.Withdraw(2000);
//         savings.DisplayAccountDetails();
//     }
// }
