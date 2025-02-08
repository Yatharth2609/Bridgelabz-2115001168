using System;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public double Balance { get; set; }

    public BankAccount(string accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void DisplayAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Balance: ${Balance}");
    }
}

public class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(string accountNumber, double balance, double interestRate) : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void DisplayAccountDetails()
    {
        base.DisplayAccountDetails();
        Console.WriteLine($"Account Type: Savings, Interest Rate: {InterestRate}%");
    }
}

public class CheckingAccount : BankAccount
{
    public double WithdrawalLimit { get; set; }

    public CheckingAccount(string accountNumber, double balance, double withdrawalLimit) : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public override void DisplayAccountDetails()
    {
        base.DisplayAccountDetails();
        Console.WriteLine($"Account Type: Checking, Withdrawal Limit: ${WithdrawalLimit}");
    }
}

public class FixedDepositAccount : BankAccount
{
    public DateTime MaturityDate { get; set; }

    public FixedDepositAccount(string accountNumber, double balance, DateTime maturityDate) : base(accountNumber, balance)
    {
        MaturityDate = maturityDate;
    }

    public override void DisplayAccountDetails()
    {
        base.DisplayAccountDetails();
        Console.WriteLine($"Account Type: Fixed Deposit, Maturity Date: {MaturityDate.ToShortDateString()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount savingsAccount = new SavingsAccount("Axis Bank", 5000, 3.5);
        BankAccount checkingAccount = new CheckingAccount("ICICI Bank", 3000, 1000);
        BankAccount fixedDepositAccount = new FixedDepositAccount("PnB Bank", 10000, DateTime.Now.AddYears(1));

        savingsAccount.DisplayAccountDetails();
        checkingAccount.DisplayAccountDetails();
        fixedDepositAccount.DisplayAccountDetails();
    }
}