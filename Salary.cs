public class Salary {
	
	private static void ComputeSalary(int salary, int bonus) {
		int finalSalary = salary + bonus;
		
		Console.WriteLine($"The salary is INR{salary} and bonus is INR{bonus}. Hence Total Income is INR{finalSalary}");
	}
	
	public static void Main(string[] args) {
		Console.Write("Enter your salary: ");
		int salary = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the bonus amount:");
		int bonus = Convert.ToInt32(Console.ReadLine());
		
		ComputeSalary(salary, bonus);
	}
}