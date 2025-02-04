// public class Person {
//     private string name;
//     private int age;
//     private char gender;

//     public Person(string name, int age, char gender) {
//         this.name = name;
//         this.age = age;
//         this.gender = gender;
//     }

//     public Person(Person prevPerson) {
//         this.name = prevPerson.name;
//         this.age = prevPerson.age;
//         this.gender = prevPerson.gender;
//     }

//     public void DisplayPersonDetails() {
//         Console.WriteLine("Name: " + name);
//         Console.WriteLine("Age: " + age);
//         Console.WriteLine("Gender: " + gender);
//     }

//     public static void Main(string[] args) {
//         Person person1 = new Person("John Doe", 30, 'M');
//         person1.DisplayPersonDetails();

//         Person person2 = new Person(person1);
//         person2.DisplayPersonDetails();
//     }
// }