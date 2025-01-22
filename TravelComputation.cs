using System;

public class TravelComputation {
	
   private static void ComputeDistance(string name, string fromCity, string viaCity, string toCity, double fromToVia, int viaToFinalCity, int timeTaken) {
	  
	  
	    double totalDistance = fromToVia + viaToFinalCity;
		
		Console.WriteLine($"The Total Distance travelled by {name} from {fromCity} to {toCity} via {viaCity} is {totalDistance} km and the Total Time taken is {timeTaken} minutes");

   }
	
   public static void Main(string[] args) {

	  Console.Write("Enter Your Name: ");
      string name = Console.ReadLine();
	  
	  Console.Write("Enter the from City: ");
      string fromCity = Console.ReadLine(); 
	  
	  Console.Write("Enter the via City: ");
	  string viaCity = Console.ReadLine();
	  
	  Console.Write("Enter the to City: ");
	  string toCity = Console.ReadLine();;

	  Console.Write("Enter the distance of from-to-via: ");
      double fromToVia = Convert.ToDouble(Console.ReadLine());
	  
	  Console.Write("Enter the distance of via-to-final city: ");
	  int viaToFinalCity = Convert.ToInt32(Console.ReadLine());;
	  
	  Console.Write("Enter the total time taken: ");
	  int timeTaken = Convert.ToInt32(Console.ReadLine());;
	  
	  ComputeDistance(name, fromCity, viaCity, toCity, fromToVia, viaToFinalCity, timeTaken);
	  
  
   }
}
