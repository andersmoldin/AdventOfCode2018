using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        private static int Part1(string input)
        {
            Regex regex = new Regex("Step (?<first>[A-Z]) must be finished before step (?<second>[A-Z]) can begin.");
            MatchCollection matchCollection = regex.Matches(input);

            var instructions = new HashSet<int>();

            foreach (Match match in matchCollection)
            {
                int first = (int)Convert.ToChar(match.Groups["first"].Value);
                int second = (int)Convert.ToChar(match.Groups["second"].Value);

                if (!instructions.ContainsKey(second))
                {
                    instructions.Add(second, new List<int> { first });
                }
                else
                {
                    instructions[second].Add(first);
                }

                foreach (var instruction in instructions)
                {
                    Console.WriteLine($"{instruction.Key} ({(char)instruction.Key})");

                    //foreach (var number in instruction.Value)
                    //{
                    //    Console.WriteLine($" {number} ({(char)number})");
                    //}
                }

                //Console.WriteLine($"{first} ({(char)first}) before {second} ({(char)second})");
                //Console.WriteLine($"{match.Groups["first"].Value} before {match.Groups["second"].Value}");
            }

            return -1;
        }

        private static int Part2(string input)
        {
            return -1;
        }
    }
}
