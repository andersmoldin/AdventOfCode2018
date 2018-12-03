using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }
        
        private static int Part1(IEnumerable <string> changes)
        {
            return changes.Select(f => int.Parse(f)).Sum();
        }

        private static int Part2(IEnumerable<string> changes)
        {
            var frequencyLog = new HashSet<int>();
            int frequency = 0;

            while (true)
            {
                foreach (var change in changes)
                {
                    frequency += Convert.ToInt32(change);

                    if (frequencyLog.Contains(frequency))
                    {
                        return frequency;
                    }

                    frequencyLog.Add(frequency);
                }
            }
        }
    }
}
