// public class HotelBooking {
//     private string guestName { get; set; }
//     private string roomType { get; set; }
//     private int nights { get; set; } 

//     public HotelBooking() {
//         guestName = "";
//         roomType = "";
//         nights = 0;
//     }
//     public HotelBooking(string guestName, string roomType, int nights) {
//         this.guestName = guestName;
//         this.roomType = roomType;
//         this.nights = nights;
//     }

//     public HotelBooking(HotelBooking prevBooking) {
//         this.guestName = prevBooking.guestName;
//         this.roomType = prevBooking.roomType;
//         this.nights = prevBooking.nights;
//     }

//     public void DisplayBookingDetails() {
//         Console.WriteLine("Guest Name: " + guestName);
//         Console.WriteLine("Room Type: " + roomType);
//         Console.WriteLine("Nights: " + nights);
//     }

//     public static void Main(string[] args) {
//         HotelBooking booking1 = new HotelBooking("John Doe", "Single", 3);
//         booking1.DisplayBookingDetails();

//         HotelBooking booking2 = new HotelBooking(booking1);
//         booking2.DisplayBookingDetails();

//         HotelBooking booking3 = new HotelBooking();
//         booking3.DisplayBookingDetails();

//     }
// }