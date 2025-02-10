using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int BookId { get; set; }
    public bool IsAvailable { get; set; }
    public Book Next { get; set; }
    public Book Previous { get; set; }

    public Book(string title, string author, string genre, int bookId, bool isAvailable = true)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookId = bookId;
        IsAvailable = isAvailable;
        Next = null;
        Previous = null;
    }
}

class Library
{
    private Book head;
    private Book tail;
    private int count;

    public void AddAtBeginning(string title, string author, string genre, int bookId)
    {
        Book newBook = new Book(title, author, genre, bookId);
        count++;

        if (head == null)
        {
            head = tail = newBook;
            return;
        }

        newBook.Next = head;
        head.Previous = newBook;
        head = newBook;
    }

    public void AddAtEnd(string title, string author, string genre, int bookId)
    {
        Book newBook = new Book(title, author, genre, bookId);
        count++;

        if (tail == null)
        {
            head = tail = newBook;
            return;
        }

        newBook.Previous = tail;
        tail.Next = newBook;
        tail = newBook;
    }

    public void AddAtPosition(int position, string title, string author, string genre, int bookId)
    {
        if (position < 1 || position > count + 1) return;

        if (position == 1)
        {
            AddAtBeginning(title, author, genre, bookId);
            return;
        }

        if (position == count + 1)
        {
            AddAtEnd(title, author, genre, bookId);
            return;
        }

        Book current = head;
        for (int i = 1; i < position - 1; i++)
            current = current.Next;

        Book newBook = new Book(title, author, genre, bookId);
        newBook.Next = current.Next;
        newBook.Previous = current;
        current.Next.Previous = newBook;
        current.Next = newBook;
        count++;
    }

    public void RemoveByBookId(int bookId)
    {
        Book current = head;
        while (current != null)
        {
            if (current.BookId == bookId)
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                count--;
                return;
            }
            current = current.Next;
        }
    }

    public List<Book> SearchByTitle(string title)
    {
        List<Book> results = new List<Book>();
        Book current = head;
        while (current != null)
        {
            if (current.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public List<Book> SearchByAuthor(string author)
    {
        List<Book> results = new List<Book>();
        Book current = head;
        while (current != null)
        {
            if (current.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public void UpdateAvailability(int bookId, bool isAvailable)
    {
        Book current = head;
        while (current != null)
        {
            if (current.BookId == bookId)
            {
                current.IsAvailable = isAvailable;
                return;
            }
            current = current.Next;
        }
    }

    public void DisplayForward()
    {
        Book current = head;
        while (current != null)
        {
            Console.WriteLine($"ID: {current.BookId}, Title: {current.Title}, Author: {current.Author}, " +
                            $"Genre: {current.Genre}, Available: {current.IsAvailable}");
            current = current.Next;
        }
    }

    public void DisplayReverse()
    {
        Book current = tail;
        while (current != null)
        {
            Console.WriteLine($"ID: {current.BookId}, Title: {current.Title}, Author: {current.Author}, " +
                            $"Genre: {current.Genre}, Available: {current.IsAvailable}");
            current = current.Previous;
        }
    }

    public int GetBookCount()
    {
        return count;
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        
        library.AddAtEnd("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 1);
        library.AddAtEnd("1984", "George Orwell", "Science Fiction", 2);
        library.AddAtBeginning("To Kill a Mockingbird", "Harper Lee", "Fiction", 3);
        
        Console.WriteLine($"Total Books: {library.GetBookCount()}");
        
        Console.WriteLine("\nBooks (Forward):");
        library.DisplayForward();
        
        library.UpdateAvailability(2, false);
        
        Console.WriteLine("\nBooks (Reverse):");
        library.DisplayReverse();
        
        var searchResults = library.SearchByAuthor("Orwell");
        Console.WriteLine("\nBooks by Orwell:");
        foreach (var book in searchResults)
            Console.WriteLine($"{book.Title} (Available: {book.IsAvailable})");
    }
}