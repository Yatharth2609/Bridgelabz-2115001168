using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
    private Dictionary<int, double> accountBalances = new Dictionary<int, double>();
    private SortedDictionary<int, double> sortedBalances = new SortedDictionary<int, double>();
    private Queue<(int, double)> withdrawalRequests = new Queue<(int, double)>();

    public void CreateAccount(int accountNumber, double initialBalance)
    {
        if (!accountBalances.ContainsKey(accountNumber))
        {
            accountBalances[accountNumber] = initialBalance;
            sortedBalances[accountNumber] = initialBalance;
        }
    }

    public void Deposit(int accountNumber, double amount)
    {
        if (accountBalances.ContainsKey(accountNumber))
        {
            accountBalances[accountNumber] += amount;
            sortedBalances[accountNumber] = accountBalances[accountNumber];
        }
    }

    public void RequestWithdrawal(int accountNumber, double amount)
    {
        if (accountBalances.ContainsKey(accountNumber) && accountBalances[accountNumber] >= amount)
        {
            withdrawalRequests.Enqueue((accountNumber, amount));
        }
    }

    public void ProcessWithdrawals()
    {
        while (withdrawalRequests.Count > 0)
        {
            var (accountNumber, amount) = withdrawalRequests.Dequeue();
            if (accountBalances[accountNumber] >= amount)
            {
                accountBalances[accountNumber] -= amount;
                sortedBalances[accountNumber] = accountBalances[accountNumber];
            }
        }
    }

    public Dictionary<int, double> GetAccountBalances()
    {
        return new Dictionary<int, double>(accountBalances);
    }

    public SortedDictionary<int, double> GetSortedBalances()
    {
        return new SortedDictionary<int, double>(sortedBalances);
    }

    static void Main()
    {
        BankingSystem bank = new BankingSystem();
        bank.CreateAccount(101, 5000);
        bank.CreateAccount(102, 3000);
        bank.CreateAccount(103, 7000);
        
        bank.Deposit(101, 2000);
        bank.RequestWithdrawal(102, 1000);
        bank.RequestWithdrawal(103, 500);
        
        bank.ProcessWithdrawals();
        
        Console.WriteLine("Account Balances:");
        foreach (var balance in bank.GetAccountBalances())
            Console.WriteLine($"Account {balance.Key}: {balance.Value:C}");
        
        Console.WriteLine("\nSorted Account Balances:");
        foreach (var balance in bank.GetSortedBalances().OrderBy(b => b.Value))
            Console.WriteLine($"Account {balance.Key}: {balance.Value:C}");
    }
}
