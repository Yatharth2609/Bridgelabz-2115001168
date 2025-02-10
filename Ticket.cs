using System;

class Ticket
{
    public int TicketID { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingTime { get; set; }
    public Ticket Next { get; set; }
}

class TicketReservationSystem
{
    private Ticket head;

    public void AddTicket(int id, string customer, string movie, string seat)
    {
        Ticket newTicket = new Ticket
        {
            TicketID = id,
            CustomerName = customer,
            MovieName = movie,
            SeatNumber = seat,
            BookingTime = DateTime.Now,
            Next = null
        };
        
        if (head == null)
        {
            head = newTicket;
            head.Next = head;
        }
        else
        {
            Ticket temp = head;
            while (temp.Next != head)
                temp = temp.Next;
            temp.Next = newTicket;
            newTicket.Next = head;
        }
    }

    public void RemoveTicket(int id)
    {
        if (head == null) return;
        
        Ticket temp = head, prev = null;
        
        if (head.TicketID == id && head.Next == head)
        {
            head = null;
            return;
        }
        
        do
        {
            if (temp.TicketID == id)
            {
                if (prev != null)
                    prev.Next = temp.Next;
                else
                {
                    Ticket last = head;
                    while (last.Next != head)
                        last = last.Next;
                    head = head.Next;
                    last.Next = head;
                }
                return;
            }
            prev = temp;
            temp = temp.Next;
        } while (temp != head);
    }

    public void DisplayTickets()
    {
        if (head == null) return;
        Ticket temp = head;
        do
        {
            Console.WriteLine($"ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
            temp = temp.Next;
        } while (temp != head);
    }

    public void SearchTicket(string keyword)
    {
        if (head == null) return;
        Ticket temp = head;
        bool found = false;
        do
        {
            if (temp.CustomerName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || temp.MovieName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);
        if (!found) Console.WriteLine("No ticket found");
    }

    public int TotalTickets()
    {
        if (head == null) return 0;
        int count = 0;
        Ticket temp = head;
        do
        {
            count++;
            temp = temp.Next;
        } while (temp != head);
        return count;
    }
}

class Program
{
    static void Main()
    {
        TicketReservationSystem system = new TicketReservationSystem();
        system.AddTicket(1, "Priya", "Inception", "A1");
        system.AddTicket(2, "Sumit", "Avatar", "B2");
        system.AddTicket(3, "Sonali", "Inception", "A2");
        
        Console.WriteLine("All Tickets:");
        system.DisplayTickets();
        
        Console.WriteLine("Search Result:");
        system.SearchTicket("Inception");
        
        Console.WriteLine("Total Tickets: " + system.TotalTickets());
        
        system.RemoveTicket(2);
        Console.WriteLine("After Removing Ticket 2:");
        system.DisplayTickets();
    }
}