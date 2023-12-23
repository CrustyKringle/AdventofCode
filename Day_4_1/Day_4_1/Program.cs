using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var fileLines = File.ReadAllLines(@"C:\Users\jenst\Desktop\JENS_AO_23_24\AdventOfCode\Day_4_1\Input_Day_four.txt");

        int totalPoints = 0;

        foreach (var line in fileLines)
        {
            var match = Regex.Match(line, @"Card\s+(?<gameId>\d+):(?<draw>[^|]*)\|(?<winner>.*)");

            var gameId = int.Parse(match.Groups["gameId"].Value);
            var drawNumbers = match.Groups["draw"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var winningNumbers = match.Groups["winner"].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int value = 0;
            int total = 0;

            foreach (var number in drawNumbers)
            {
                if (!winningNumbers.Contains(number))
                    continue;

                total = (int)Math.Pow(2, value);
                value += 1;
            }

            Console.WriteLine($"Card {gameId}: Total = {total}");

            totalPoints += total;
        }

        Console.WriteLine("Total Points: " + totalPoints);
    }
}
