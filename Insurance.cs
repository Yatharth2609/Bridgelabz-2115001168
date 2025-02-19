using System;
using System.Collections.Generic;
using System.Linq;

class Policy
{
    public string PolicyNumber { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Policy policy)
            return PolicyNumber == policy.PolicyNumber;
        return false;
    }

    public override int GetHashCode() => PolicyNumber.GetHashCode();
}

class InsurancePolicyManager
{
    private HashSet<Policy> uniquePolicies = new HashSet<Policy>();
    private LinkedList<Policy> orderedPolicies = new LinkedList<Policy>();
    private SortedSet<Policy> sortedPolicies = new SortedSet<Policy>(Comparer<Policy>.Create((a, b) => a.ExpiryDate.CompareTo(b.ExpiryDate)));
    private Dictionary<string, List<Policy>> policyNumberMap = new Dictionary<string, List<Policy>>();

    public void AddPolicy(Policy policy)
    {
        if (uniquePolicies.Add(policy))
        {
            orderedPolicies.AddLast(policy);
            sortedPolicies.Add(policy);
        }
        if (!policyNumberMap.ContainsKey(policy.PolicyNumber))
            policyNumberMap[policy.PolicyNumber] = new List<Policy>();
        policyNumberMap[policy.PolicyNumber].Add(policy);
    }

    public IEnumerable<Policy> GetAllPolicies() => uniquePolicies;

    public IEnumerable<Policy> GetPoliciesExpiringSoon()
    {
        DateTime threshold = DateTime.Now.AddDays(30);
        return sortedPolicies.TakeWhile(p => p.ExpiryDate <= threshold);
    }

    public IEnumerable<Policy> GetPoliciesByCoverageType(string coverageType)
    {
        return uniquePolicies.Where(p => p.CoverageType.Equals(coverageType, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Policy> GetDuplicatePolicies()
    {
        return policyNumberMap.Values.Where(list => list.Count > 1).SelectMany(list => list);
    }
}

class Program
{
    static void Main()
    {
        InsurancePolicyManager manager = new InsurancePolicyManager();
        manager.AddPolicy(new Policy { PolicyNumber = "P123", CoverageType = "Health", ExpiryDate = DateTime.Now.AddDays(15) });
        manager.AddPolicy(new Policy { PolicyNumber = "P124", CoverageType = "Auto", ExpiryDate = DateTime.Now.AddDays(45) });
        manager.AddPolicy(new Policy { PolicyNumber = "P123", CoverageType = "Health", ExpiryDate = DateTime.Now.AddDays(15) });
        
        Console.WriteLine("All Policies:");
        foreach (var policy in manager.GetAllPolicies())
            Console.WriteLine(policy.PolicyNumber);
        
        Console.WriteLine("\nExpiring Soon:");
        foreach (var policy in manager.GetPoliciesExpiringSoon())
            Console.WriteLine(policy.PolicyNumber);
        
        Console.WriteLine("\nDuplicate Policies:");
        foreach (var policy in manager.GetDuplicatePolicies())
            Console.WriteLine(policy.PolicyNumber);
    }
}