// using System;

// public class Book2
// {
//     public string ISBN { get; set; }
//     protected string Title { get; set; }
//     private string author;

//     public Book2(string isbn, string title, string author)
//     {
//         ISBN = isbn;
//         Title = title;
//         this.author = author;
//     }

//     public string GetAuthor()
//     {
//         return author;
//     }

//     public void SetAuthor(string newAuthor)
//     {
//         author = newAuthor;
//     }

//     public static void Main(string[] args)
//     {
//         EBook ebook = new EBook("978-3-16-148410-0", "C# Programming", "John Doe");
//         ebook.DisplayBookDetails();

//         ebook.SetAuthor("Jane Smith");
//         ebook.DisplayBookDetails();
//     }
// }

// public class EBook : Book2
// {

//     public EBook(string isbn, string title, string authore)
//         : base(isbn, title, author)
//     {
//     }

//     public void DisplayBookDetails()
//     {
//         Console.WriteLine($"ISBN: {ISBN}"); // Accessible due to public modifier
//         Console.WriteLine($"Title: {Title}"); // Accessible due to protected modifier
//         Console.WriteLine($"Author: {GetAuthor()}"); // Accessed via public method
//     }
// }
