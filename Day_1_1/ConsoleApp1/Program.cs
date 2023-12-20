using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Replace the path with the actual path to your text file
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_23_24\AdventOfCode\Day_1_1\Input_Day_1.txt";

        int sumOfCombinedIntegers = 0;

        // Read each line from the text file
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // Process the line and get the combined integer
                int combinedInteger = ProcessTextLine(line);

                // Add the combined integer to the sum
                sumOfCombinedIntegers += combinedInteger;
            }
        }

        // Print the total sum of combined integers
        Console.WriteLine("Total Sum of Combined Integers: " + sumOfCombinedIntegers);
    }

    static int ProcessTextLine(string line)
    {
        // Filter out non-numeric characters
        string numericString = new string(line.Where(char.IsDigit).ToArray());

        // Check if the numeric string is not empty before parsing
        if (!string.IsNullOrEmpty(numericString))
        {
            // Try parsing the first integer from the numeric string
            if (int.TryParse(numericString[0].ToString(), out int firstDigit))
            {
                // Try parsing the last integer from the numeric string
                if (int.TryParse(numericString[^1].ToString(), out int lastDigit))
                {
                    // Create an array of integers
                    int[] integers = { firstDigit, lastDigit };

                    // Create a new integer combining the first and last integers
                    int combinedInteger = int.Parse(integers.First().ToString() + integers.Last().ToString());

                    // Print the combined integer for the current line
                    Console.WriteLine("Combined Integer for Text line: " + combinedInteger);

                    return combinedInteger;
                }
            }
        }

        Console.WriteLine("No valid integers found in the Text line.");
        return 0; // Return 0 if no valid integers are found in the line
    }
}