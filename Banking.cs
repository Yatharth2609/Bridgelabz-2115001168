public abstract class BankAccount
{
    private string accountNumber;
    private string holderName;
    public double balance;
    protected readonly double minimumBalance;

    public BankAccount(string accountNumber, string holderName, double initialDeposit, double minimumBalance)
    {
        this.accountNumber = accountNumber;
        this.holderName = holderName;
        this.balance = initialDeposit;
        this.minimumBalance = minimumBalance;
    }

    public string AccountNumber => accountNumber;
    public string HolderName => holderName;
    public double Balance => balance;

    public virtual bool Deposit(double amount)
    {
        if (amount <= 0)
            return false;
            
        balance += amount;
        return true;
    }

    public virtual bool Withdraw(double amount)
    {
        if (amount <= 0 || (balance - amount) < minimumBalance)
            return false;
            
        balance -= amount;
        return true;
    }

    public abstract double CalculateInterest();
}

public interface ILoanable
{
    bool ApplyForLoan(double amount);
    double CalculateLoanEligibility();
}

public class SavingsAccount : BankAccount, ILoanable
{
    private const double InterestRate = 0.045;
    private const double LoanInterestRate = 0.12;

    public SavingsAccount(string accountNumber, string holderName, double initialDeposit)
        : base(accountNumber, holderName, initialDeposit, 500)
    {
    }

    public override double CalculateInterest()
    {
        return Balance * InterestRate;
    }

    public bool ApplyForLoan(double amount)
    {
        if (amount <= 0 || amount > CalculateLoanEligibility())
            return false;
            
        Deposit(amount);
        return true;
    }

    public double CalculateLoanEligibility()
    {
        return Balance * 3;
    }
}

public class CurrentAccount : BankAccount, ILoanable
{
    private const double InterestRate = 0.01;
    private const double OverdraftLimit = 10000;

    public CurrentAccount(string accountNumber, string holderName, double initialDeposit)
        : base(accountNumber, holderName, initialDeposit, -OverdraftLimit)
    {
    }

    public override double CalculateInterest()
    {
        return Balance > 0 ? Balance * InterestRate : 0;
    }

    public bool ApplyForLoan(double amount)
    {
        if (amount <= 0 || amount > CalculateLoanEligibility())
            return false;
            
        Deposit(amount);
        return true;
    }

    public double CalculateLoanEligibility()
    {
        return Balance > 0 ? Balance * 5 : 0;
    }

    public override bool Withdraw(double amount)
    {
        if (amount <= 0 || (Balance - amount) < minimumBalance)
            return false;
            
        if (Balance - amount < 0)
        {
            double overdraftFee = 25;
            balance -= overdraftFee;
        }
        
        balance -= amount;
        return true;
    }
}

public class Bank
{
    public static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("Axis Bank", "Yatharth", 5000),
            new CurrentAccount("ICICI Bank", "Harry", 10000),
            new SavingsAccount("PnB Bank", "Adnan", 7500)
        };

        foreach (BankAccount account in accounts)
        {
            Console.WriteLine($"Account: {account.AccountNumber}");
            Console.WriteLine($"Holder: {account.HolderName}");
            Console.WriteLine($"Balance: ${account.Balance}");
            Console.WriteLine($"Annual Interest: {account.CalculateInterest():C}");

            if (account is ILoanable loanable)
            {
                double eligibility = loanable.CalculateLoanEligibility();
                Console.WriteLine($"Loan Eligibility: {eligibility:C}");
                
                if (eligibility > 0)
                {
                    double loanAmount = eligibility / 2;
                    bool loanApproved = loanable.ApplyForLoan(loanAmount);
                    Console.WriteLine($"Loan Application for {loanAmount:C}: {(loanApproved ? "Approved" : "Denied")}");
                }
            }
            Console.WriteLine();
        }
    }
}