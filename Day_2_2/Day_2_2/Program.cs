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
        var productSum = 0;

        foreach (var line in lines)
        {
            var colorValues = Regex.Matches(line, @"(\d+)\s*([a-zA-Z]+)")
                .Select(match => (
                    Value: int.Parse(match.Groups[1].Value),
                    Color: match.Groups[2].Value.ToLower()
                ));

            var maxValues = colorValues
                .GroupBy(pair => pair.Color)
                .Select(group => group.Max(pair => pair.Value));

            var product = maxValues.Aggregate(1, (acc, value) => acc * value);
            productSum += product;

            Console.WriteLine($"Game {GetGameId(line)}: {product}");
        }
        Console.WriteLine($"Sum: " + productSum);
    }

    
    static int GetGameId(string line)
    {
        var idMatch = Regex.Match(line, @"Game (\d+)");
        return idMatch.Success ? int.Parse(idMatch.Groups[1].Value) : -1;
    }
}
