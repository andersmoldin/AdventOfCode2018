using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05
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
            bool changedInput = false;
            bool stillHeterozygots = true;

            while (stillHeterozygots)
            {
                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (Math.Abs(input[i] - input[i + 1]) == 32)
                    {
                        input = input.Substring(0, i) + input.Substring(i + 2);
                        changedInput = true;
                        break;
                    }
                }

                if (!changedInput)
                {
                    stillHeterozygots = false;
                }
                else
                {
                    changedInput = false;
                }
            }

            return input.Length;
        }

        private static int Part2(string input)
        {
            return -1;
        }
    }
}
