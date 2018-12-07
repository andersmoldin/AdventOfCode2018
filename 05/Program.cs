using System;
using System.IO;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            //var input = "dabAcCaCBAcCcaDA";

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
            string temp = "";
            var results = new Dictionary<char, int>();
            bool changedInput = false;
            bool stillHeterozygots = true;

            for (int i = 65; i <= 90; i++)
            {
                temp = input.Replace(((char)i).ToString(), "").Replace(((char)(i + 32)).ToString(), "");

                while (stillHeterozygots)
                {
                    for (int j = 0; j < temp.Length - 1; j++)
                    {
                        if (Math.Abs(temp[j] - temp[j + 1]) == 32)
                        {
                            temp = temp.Substring(0, j) + temp.Substring(j + 2);
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

                results.Add((char)i, temp.Length);
            }

            return -1;
        }

    }
}
