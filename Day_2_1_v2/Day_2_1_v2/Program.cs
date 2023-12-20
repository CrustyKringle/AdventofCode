using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines(@"C:\Users\jenst\Desktop\JENS_AO_23_24\AdventOfCode\Day_2_1\Input_Day_2.txt");

        int totalValidGameIds = lines
            .Select(line => (
                Values: Regex.Matches(line, @"(\d+)\s*([a-zA-Z]+)")
                    .Select(match => (
                        Value: int.Parse(match.Groups[1].Value),
                        Color: match.Groups[2].Value.ToLower()
                    ))
                    .ToList(),
                IdMatch: Regex.Match(line, @"Game (\d+)")
            ))
            .Where(tuple =>
                tuple.Values.All(pair => pair.Color switch
                {
                    "red" => pair.Value <= 12,
                    "green" => pair.Value <= 13,
                    "blue" => pair.Value <= 14,
                    _ => true
                })
            )
            .Select(tuple => tuple.IdMatch)
            .Where(idMatch => idMatch.Success)
            .Sum(idMatch => int.Parse(idMatch.Groups[1].Value));

        Console.WriteLine($"Sum = {totalValidGameIds}");
    }
}
