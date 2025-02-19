using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    private Dictionary<string, int> votes = new Dictionary<string, int>();
    private SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>();
    private LinkedList<string> voteOrder = new LinkedList<string>();

    public void CastVote(string candidate)
    {
        if (votes.ContainsKey(candidate))
            votes[candidate]++;
        else
            votes[candidate] = 1;

        if (!sortedVotes.ContainsKey(candidate))
            sortedVotes[candidate] = 0;
        sortedVotes[candidate]++;

        voteOrder.AddLast(candidate);
    }

    public Dictionary<string, int> GetVoteResults()
    {
        return new Dictionary<string, int>(votes);
    }

    public SortedDictionary<string, int> GetSortedResults()
    {
        return new SortedDictionary<string, int>(sortedVotes);
    }

    public List<string> GetVoteOrder()
    {
        return voteOrder.ToList();
    }

    static void Main()
    {
        VotingSystem voting = new VotingSystem();
        voting.CastVote("Dev");
        voting.CastVote("Rajesh");
        voting.CastVote("Supriya");
        voting.CastVote("Neha");
        voting.CastVote("Praful");
        
        Console.WriteLine("Vote Results:");
        foreach (var result in voting.GetVoteResults())
            Console.WriteLine($"{result.Key}: {result.Value}");
        
        Console.WriteLine("\nSorted Results:");
        foreach (var result in voting.GetSortedResults())
            Console.WriteLine($"{result.Key}: {result.Value}");
        
        Console.WriteLine("\nVote Order:");
        foreach (var name in voting.GetVoteOrder())
            Console.WriteLine(name);
    }
}
