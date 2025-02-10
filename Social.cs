using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public HashSet<int> FriendIds { get; set; }
    public User Next { get; set; }

    public User(int userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
        FriendIds = new HashSet<int>();
        Next = null;
    }
}

class SocialNetwork
{
    private User head;

    public void AddUser(int userId, string name, int age)
    {
        User newUser = new User(userId, name, age);
        newUser.Next = head;
        head = newUser;
    }

    public void AddFriendConnection(int userId1, int userId2)
    {
        User user1 = FindUserById(userId1);
        User user2 = FindUserById(userId2);

        if (user1 != null && user2 != null)
        {
            user1.FriendIds.Add(userId2);
            user2.FriendIds.Add(userId1);
        }
    }

    public void RemoveFriendConnection(int userId1, int userId2)
    {
        User user1 = FindUserById(userId1);
        User user2 = FindUserById(userId2);

        if (user1 != null && user2 != null)
        {
            user1.FriendIds.Remove(userId2);
            user2.FriendIds.Remove(userId1);
        }
    }

    public HashSet<int> FindMutualFriends(int userId1, int userId2)
    {
        User user1 = FindUserById(userId1);
        User user2 = FindUserById(userId2);

        if (user1 == null || user2 == null)
            return new HashSet<int>();

        return new HashSet<int>(user1.FriendIds.Intersect(user2.FriendIds));
    }

    public void DisplayUserFriends(int userId)
    {
        User user = FindUserById(userId);
        if (user == null) return;

        Console.WriteLine($"Friends of {user.Name} (ID: {user.UserId}):");
        foreach (int friendId in user.FriendIds)
        {
            User friend = FindUserById(friendId);
            if (friend != null)
                Console.WriteLine($"- {friend.Name} (ID: {friend.UserId})");
        }
    }

    public User FindUserById(int userId)
    {
        User current = head;
        while (current != null)
        {
            if (current.UserId == userId)
                return current;
            current = current.Next;
        }
        return null;
    }

    public List<User> SearchByName(string name)
    {
        List<User> results = new List<User>();
        User current = head;
        while (current != null)
        {
            if (current.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public Dictionary<int, int> CountFriendsForAllUsers()
    {
        Dictionary<int, int> friendCounts = new Dictionary<int, int>();
        User current = head;
        while (current != null)
        {
            friendCounts[current.UserId] = current.FriendIds.Count;
            current = current.Next;
        }
        return friendCounts;
    }
}

class Program
{
    static void Main()
    {
        SocialNetwork network = new SocialNetwork();

        network.AddUser(1, "Rajesh", 25);
        network.AddUser(2, "Priya", 28);
        network.AddUser(3, "Sonali", 22);
        
        network.AddFriendConnection(1, 2);
        network.AddFriendConnection(2, 3);
        network.AddFriendConnection(1, 3);
        
        network.DisplayUserFriends(1);
        
        network.RemoveFriendConnection(1, 2);
        
        var mutualFriends = network.FindMutualFriends(1, 2);
        Console.WriteLine("\nMutual friends between Rajesh and Priya:");
        foreach (var friendId in mutualFriends)
        {
            var friend = network.FindUserById(friendId);
            Console.WriteLine($"- {friend.Name}");
        }
        
        var friendCounts = network.CountFriendsForAllUsers();
        Console.WriteLine("\nFriend Counts:");
        foreach (var kvp in friendCounts)
        {
            var user = network.FindUserById(kvp.Key);
            Console.WriteLine($"{user.Name}: {kvp.Value} friends");
        }
    }
}