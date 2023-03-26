using System;

class Program
{
    static void Main(string[] args)
    {
        ConsoleKeyInfo key;
        Console.WriteLine("1. Sub String");
        Console.WriteLine("2. Check digit");
        do
        {
            Console.WriteLine("Which test do you want?");
          

            string input = Console.ReadLine();
            int choice;

            while (!int.TryParse(input, out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid choice:");
                input = Console.ReadLine();
            }

            switch (choice)
            {
                case 1:
                    RunSubStringTest();
                    break;
                case 2:
                    RunCheckDigitTest();
                    break;
            }

            Console.WriteLine("Press ESC to exit or any other key to continue...");
            key = Console.ReadKey();
            Console.WriteLine();
        } while (key.Key != ConsoleKey.Escape);
    }

    public static void RunSubStringTest() {
        Console.WriteLine("Enter the input string: ");
        string inputString = Console.ReadLine();
        Console.WriteLine("Enter the first index: ");
        int startIndex = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the secdon index: ");
        int endIndex = int.Parse(Console.ReadLine());
        try
        {
            string subString = SubString(inputString, startIndex, endIndex);
            Console.WriteLine(subString);
        }
        catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void RunCheckDigitTest()
    {

        Console.WriteLine("Enter the number:");
        int inputNumber = int.Parse(Console.ReadLine());
        try
        {
            CheckDigitCalculator calculator = new CheckDigitCalculator();
            int checkDigit = calculator.CalculateCheckDigit(inputNumber);
            Console.WriteLine($"Your check digit is: {checkDigit}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static string SubString(string s, int i, int j)
    {
        if (!int.TryParse(i.ToString(), out int index1) || !int.TryParse(j.ToString(), out int index2))
        {
            throw new ArgumentException("Index values must be integers");
        }

        if (string.IsNullOrEmpty(s))
        {
            throw new ArgumentException("Input string cannot be null or empty");
        }

        int start = Math.Min(index1, index2);
        int end = Math.Max(index1, index2);

        if (start < 0 || end >= s.Length)
        {
            throw new ArgumentOutOfRangeException("Indices are out of range");
        }

        return s.Substring(start, end - start + 1);
    }

    public class CheckDigitCalculator
    {
        public int CalculateCheckDigit(int number)
        {
            // Convert the number to a string so we can access individual digits
            string numberString = number.ToString();

            // Create an array to store the digits after processing
            int[] processedDigits = new int[numberString.Length];

            // Loop through the digits of the number from right to left
            for (int i = numberString.Length - 1, j = 0; i >= 0; i--, j++)
            {
                int digit = int.Parse(numberString[i].ToString());

                // Double every alternate digit, starting with the first one
                if (j % 2 == 0)
                {
                    digit *= 2;

                    // If the resulting number has two digits, add them together
                    if (digit >= 10)
                    {
                        digit = digit % 10 + digit / 10;
                    }
                }

                // Store the processed digit in the array
                processedDigits[j] = digit;
            }

            // Add up all the processed digits
            int sum = processedDigits.Sum();

            // Calculate the check digit
            int checkDigit = 10 - (sum % 10);

            return checkDigit;
        }
    }




}