using System;
using System.IO;
using System.Text.RegularExpressions;

class Program {
    static void Main(string[] args) {
        var input = File.ReadAllText("input.txt");

        int part1Result = Part1(input);
        Console.WriteLine("Part 1: " + part1Result);
        int part2Result = Part2(input);
        Console.WriteLine("Part 2: " + part2Result);
    }

    static int Part1(string memory) {
        string pattern = @"mul\((\d+),(\d+)\)";
        var regex = new Regex(pattern);

        var matches = regex.Matches(memory);
        int sum = 0;

        foreach (Match match in matches) {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }
        return sum;
    }

    static int Part2(string memory) {
        string mulPattern = @"mul\((\d+),(\d+)\)";
        string controlPattern = @"do\(\)|don't\(\)";
        var mulRegex = new Regex(mulPattern);
        var controlRegex = new Regex(controlPattern);
        var mulMatches = mulRegex.Matches(memory);
        var controlMatches = controlRegex.Matches(memory);

        bool isEnabled = true;
        int sum = 0;
        int mulIndex = 0;

        foreach (Match control in controlMatches) {
            int controlPosition = control.Index;

            while (mulIndex < mulMatches.Count && mulMatches[mulIndex].Index < controlPosition) {
                if (isEnabled) {
                    int x = int.Parse(mulMatches[mulIndex].Groups[1].Value);
                    int y = int.Parse(mulMatches[mulIndex].Groups[2].Value);
                    sum += x * y;
                }
                mulIndex++;
            }

            if (control.Value == "do()") {
                isEnabled = true;
            } else if (control.Value == "don't()") {
                isEnabled = false;
            }
        }

        while (mulIndex < mulMatches.Count) {
            if (isEnabled) {
                int x = int.Parse(mulMatches[mulIndex].Groups[1].Value);
                int y = int.Parse(mulMatches[mulIndex].Groups[2].Value);
                sum += x * y;
            }
            mulIndex++;
        }
        return sum;
    }
}
