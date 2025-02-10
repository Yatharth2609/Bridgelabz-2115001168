using System;
using System.Collections.Generic;

class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public double Rating { get; set; }
    public Movie Next { get; set; }
    public Movie Previous { get; set; }

    public Movie(string title, string director, int year, double rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
        Next = null;
        Previous = null;
    }
}

class MovieList
{
    private Movie head;
    private Movie tail;

    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        Movie newMovie = new Movie(title, director, year, rating);
        if (head == null)
        {
            head = tail = newMovie;
            return;
        }
        newMovie.Next = head;
        head.Previous = newMovie;
        head = newMovie;
    }

    public void AddAtEnd(string title, string director, int year, double rating)
    {
        Movie newMovie = new Movie(title, director, year, rating);
        if (tail == null)
        {
            head = tail = newMovie;
            return;
        }
        newMovie.Previous = tail;
        tail.Next = newMovie;
        tail = newMovie;
    }

    public void AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position < 1) return;
        if (position == 1)
        {
            AddAtBeginning(title, director, year, rating);
            return;
        }

        Movie current = head;
        for (int i = 1; i < position - 1 && current != null; i++)
            current = current.Next;

        if (current == null) return;

        Movie newMovie = new Movie(title, director, year, rating);
        newMovie.Next = current.Next;
        newMovie.Previous = current;
        if (current.Next != null)
            current.Next.Previous = newMovie;
        else
            tail = newMovie;
        current.Next = newMovie;
    }

    public void RemoveByTitle(string title)
    {
        Movie current = head;
        while (current != null)
        {
            if (current.Title == title)
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;
                return;
            }
            current = current.Next;
        }
    }

    public List<Movie> SearchByDirector(string director)
    {
        List<Movie> results = new List<Movie>();
        Movie current = head;
        while (current != null)
        {
            if (current.Director == director)
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public List<Movie> SearchByRating(double rating)
    {
        List<Movie> results = new List<Movie>();
        Movie current = head;
        while (current != null)
        {
            if (current.Rating == rating)
                results.Add(current);
            current = current.Next;
        }
        return results;
    }

    public void UpdateRating(string title, double newRating)
    {
        Movie current = head;
        while (current != null)
        {
            if (current.Title == title)
            {
                current.Rating = newRating;
                return;
            }
            current = current.Next;
        }
    }

    public void DisplayForward()
    {
        Movie current = head;
        while (current != null)
        {
            Console.WriteLine($"Title: {current.Title}, Director: {current.Director}, Year: {current.Year}, Rating: {current.Rating}");
            current = current.Next;
        }
    }

    public void DisplayReverse()
    {
        Movie current = tail;
        while (current != null)
        {
            Console.WriteLine($"Title: {current.Title}, Director: {current.Director}, Year: {current.Year}, Rating: {current.Rating}");
            current = current.Previous;
        }
    }
}

class Program
{
    static void Main()
    {
        MovieList list = new MovieList();
        
        list.AddAtEnd("Inception", "Christopher Nolan", 2010, 8.8);
        list.AddAtEnd("Golmaal", "Rohit Shetty", 2014, 8.7);
        list.AddAtBeginning("Housefull", "Sajid Khan", 2016, 8.6);
        
        Console.WriteLine("Movies (Forward):");
        list.DisplayForward();
        
        Console.WriteLine("\nMovies (Reverse):");
        list.DisplayReverse();
        
        var nolanMovies = list.SearchByDirector("Christopher Nolan");
        Console.WriteLine("\nNolan Movies:");
        foreach (var movie in nolanMovies)
            Console.WriteLine($"{movie.Title} ({movie.Year})");
    }
}