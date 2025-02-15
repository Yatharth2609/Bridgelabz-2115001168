using System;
using System.Text;

class Reverse {
    public static string Rev(string input) {
        StringBuilder sb = new StringBuilder(input);
        int left = 0, right = sb.Length - 1;

        while (left < right) {
            char temp = sb[left];
            sb[left] = sb[right];
            sb[right] = temp;
            left++;
            right--;
        }

        return sb.ToString();
    }

    public static void Main() {
        string reversed = Rev("Hello");
        Console.WriteLine("Reversed String: " + reversed);
    }
}
