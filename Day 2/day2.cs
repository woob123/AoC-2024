using System;
using System.Collections.Generic;
using System.IO;

public class Program {
    public static void Main(string[] args) {
        var input = File.ReadAllText("input.txt");
        var lines = input.Split("\n");
        int part1Count = 0;
        int part2Count = 0;

        foreach (var curr in lines) {
            var currents = curr.Split(" ");
            List<int> l1 = new List<int>();
            foreach (var currr in currents) {
                if (int.TryParse(currr, out int value)) {
                    l1.Add(value);
                }
            }

            if (l1.Count < 2) continue;

            bool isPart1Safe = CheckSafety(l1);
            if (isPart1Safe) 
                part1Count++;

            bool isPart2Safe = isPart1Safe;
            if (!isPart1Safe) {
                for (int i = 0; i < l1.Count; i++) {
                    List<int> modified = new List<int>(l1);
                    modified.RemoveAt(i);
                    if (CheckSafety(modified)) {
                        isPart2Safe = true;
                        break;
                    }
                }
            }
            if (isPart2Safe) 
                part2Count++;
        }

        Console.WriteLine("Part 1: " + part1Count);
        Console.WriteLine("Part 2: " + part2Count);
    }

    private static bool CheckSafety(List<int> l1) {
        bool dir = l1[0] > l1[1];
        for (int i = 1; i < l1.Count; i++) {
            if ((l1[i] < l1[i - 1]) != dir) {
                return false;
            }
            if (Math.Abs(l1[i] - l1[i - 1]) < 1 || Math.Abs(l1[i] - l1[i - 1]) > 3) {
                return false;
            }
        }
        return true;
    }
}
