using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static Dictionary<string, string> writtenNumbers = new Dictionary<string, string>
    {
        {"zero", "z0o"},
        {"one", "o1e"},
        {"two", "t2o"},
        {"three", "th3ee"},
        {"four", "fo4r"},
        {"five", "f5e"},
        {"six", "s6x"},
        {"seven", "s7en"},
        {"eight", "e8ht"},
        {"nine", "n9ne"}
    };

    static void Main()
    {
        string filePath = @"C:\Users\jenst\Desktop\JENS_AO_23_24\AdventOfCode\Day_1_1\Input_Day_1.txt";

        int totalSum = ProcessFile(filePath);
        Console.WriteLine("Total Sum of Combined Integers: " + totalSum);
        
    }

    static int ProcessFile(string filePath)
    {
        int totalSum = 0;

        foreach (var line in File.ReadLines(filePath))
        {
            int combinedInteger = ConvertToDigits(line);
            totalSum += combinedInteger;
            Console.WriteLine("Combined Integer for Line: " + combinedInteger);
        }

        return totalSum;
    }

    static int ConvertToDigits(string inputString)
    {
        // Check if the line is just an integer
        if (int.TryParse(inputString, out int result))
        {
            return int.Parse(inputString[0].ToString() + inputString[^1].ToString());
        }

        // Replace written numbers with their corresponding digits
        foreach (var entry in writtenNumbers.OrderByDescending(e => e.Key.Length))
        {
            inputString = inputString.Replace(entry.Key, entry.Value);
        }

        // Filter out non-numeric characters
        string numericString = new string(inputString.Where(char.IsDigit).ToArray());

        // Check if the numeric string is not empty before parsing
        if (!string.IsNullOrEmpty(numericString))
        {
            int firstDigit = int.Parse(numericString[0].ToString());
            int lastDigit = int.Parse(numericString[^1].ToString());
            return int.Parse(firstDigit.ToString() + lastDigit.ToString());
        }

        return 0;
    }
}
