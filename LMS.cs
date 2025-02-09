public abstract class LibraryItem
{
    private string itemId;
    private string title;
    private string author;
    private bool isLoaned;
    private string borrowerId;
    private DateTime? loanDate;

    public LibraryItem(string itemId, string title, string author)
    {
        this.itemId = itemId;
        this.title = title;
        this.author = author;
        this.isLoaned = false;
    }

    public string ItemId => itemId;
    public string Title => title;
    public string Author => author;
    public bool IsLoaned => isLoaned;

    public abstract int GetLoanDuration();

    public string GetItemDetails()
    {
        return $"ID: {itemId}, Title: {title}, Author: {author}, Status: {(isLoaned ? "Loaned" : "Available")}";
    }

    public bool LoanItem(string borrowerId)
    {
        if (isLoaned) return false;
        
        this.borrowerId = borrowerId;
        this.loanDate = DateTime.Now;
        this.isLoaned = true;
        return true;
    }

    public bool ReturnItem()
    {
        if (!isLoaned) return false;
        
        this.borrowerId = null;
        this.loanDate = null;
        this.isLoaned = false;
        return true;
    }
}

public interface IReservable
{
    bool ReserveItem(string userId);
    bool CheckAvailability();
}

public class Book : LibraryItem, IReservable
{
    private string isbn;
    private string reservedBy;

    public Book(string itemId, string title, string author, string isbn) 
        : base(itemId, title, author)
    {
        this.isbn = isbn;
    }

    public override int GetLoanDuration()
    {
        return 21;
    }

    public bool ReserveItem(string userId)
    {
        if (IsLoaned && reservedBy == null)
        {
            reservedBy = userId;
            return true;
        }
        return false;
    }

    public bool CheckAvailability()
    {
        return !IsLoaned || reservedBy == null;
    }
}

public class Magazine : LibraryItem, IReservable
{
    private string issueNumber;
    private string reservedBy;

    public Magazine(string itemId, string title, string author, string issueNumber) 
        : base(itemId, title, author)
    {
        this.issueNumber = issueNumber;
    }

    public override int GetLoanDuration()
    {
        return 7;
    }

    public bool ReserveItem(string userId)
    {
        if (IsLoaned && reservedBy == null)
        {
            reservedBy = userId;
            return true;
        }
        return false;
    }

    public bool CheckAvailability()
    {
        return !IsLoaned || reservedBy == null;
    }
}

public class DVD : LibraryItem
{
    private int duration;

    public DVD(string itemId, string title, string author, int duration) 
        : base(itemId, title, author)
    {
        this.duration = duration;
    }

    public override int GetLoanDuration()
    {
        return 14;
    }
}

public class Library
{
    public static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>
        {
            new Book("B001", "Two States", "Chetan Bhagat", "978-0743273565"),
            new Magazine("M001", "National Geographic", "NA", "2024-02"),
            new DVD("D001", "Inception", "Christopher Nolan", 148)
        };

        foreach (LibraryItem item in items)
        {
            Console.WriteLine(item.GetItemDetails());
            Console.WriteLine($"Loan Duration: {item.GetLoanDuration()} days");

            if (item is IReservable reservable)
            {
                bool isAvailable = reservable.CheckAvailability();
                Console.WriteLine($"Available for reservation: {isAvailable}");
                
                if (isAvailable)
                {
                    string userId = "Yatharth";
                    bool reserved = reservable.ReserveItem(userId);
                    Console.WriteLine($"Reservation attempt: {(reserved ? "Successful" : "Failed")}");
                }
            }
            
            bool loanResult = item.LoanItem("Harry");
            Console.WriteLine($"Loan attempt: {(loanResult ? "Successful" : "Failed")}");
            Console.WriteLine();
        }
    }
}