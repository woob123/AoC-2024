using System;
using System.Xml;

public class Program {
    public static void Main(String[] args) {
        var input = File.ReadAllText("input.txt");
        
        int[] frec = new int[100000];
        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        
        var line = input.Split("\n");
        foreach(var curr in line) {
            var currents = curr.Split("   ");
            l1.Add(int.Parse(currents[0]));
            l2.Add(int.Parse(currents[1]));
            frec[int.Parse(currents[1])]++;
        }
        
        l1.Sort();
        l2.Sort();
        
        int part1 = 0;
        int part2 = 0;
        for(int i = 0; i < l1.Count; i++) {
            part1 = part1 + (Math.Abs(l1[i] - l2[i]));
            part2 = part2 + (l1[i] * frec[l1[i]]);
        }
        
        Console.WriteLine("Answer to part one of the problem is: " + part1);
        Console.WriteLine("Answer to the second part of the problem is: " + part2);
    }   
}
