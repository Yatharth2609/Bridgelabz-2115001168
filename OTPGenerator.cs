using System;

public class OTPGenerator {
    // a. Method to generate a 6-digit OTP
    private static int GenerateOTP() {
        Random random = new Random();
        return random.Next(100000, 1000000); // Generates a 6-digit number (100000 to 999999)
    }

    // b. Method to generate an array of 10 OTPs
    private static int[] GenerateOTPs(int count) {
        int[] otps = new int[count];
        for (int i = 0; i < count; i++) {
            otps[i] = GenerateOTP();
        }
        return otps;
    }

    // c. Method to check if all OTPs in the array are unique (without HashSet)
    private static bool AreOTPsUnique(int[] otps) {
        for (int i = 0; i < otps.Length; i++) {
            for (int j = i + 1; j < otps.Length; j++) {
                if (otps[i] == otps[j]) {
                    return false; // Duplicate found
                }
            }
        }
        return true; // No duplicates
    }

    public static void Main(string[] args) {
        const int otpCount = 10;

        // Generate 10 OTPs
        int[] otps = GenerateOTPs(otpCount);

        // Display the generated OTPs
        Console.WriteLine("Generated OTPs:");
        foreach (int otp in otps) {
            Console.WriteLine(otp);
        }

        // Validate uniqueness of OTPs
        bool areUnique = AreOTPsUnique(otps);
        Console.WriteLine($"\nAre all OTPs unique? {areUnique}");
    }
}
