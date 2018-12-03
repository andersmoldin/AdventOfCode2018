using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt").ToList();

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        private static int Part1(List<string> input)
        {
            List<Claim> claims = input.Select(c => c.Split(' ')).Select(c => new Claim(
                Convert.ToInt32(c[0].Substring(1)),
                Convert.ToInt32(c[2].Split(',')[0]),
                Convert.ToInt32(c[2].Split(',')[1].Replace(":", "")),
                Convert.ToInt32(c[3].Split('x')[0]),
                Convert.ToInt32(c[3].Split('x')[1])
            )).ToList();

            var fabric = new int[claims.Max(c => c.InchesFromLeftEdge + c.Width), claims.Max(c => c.InchesFromTopEdge + c.Height)];

            for (int i = 0; i < claims.Count; i++)
            {
                for (int j = claims[i].InchesFromLeftEdge; j < claims[i].InchesFromLeftEdge + claims[i].Width; j++)
                {
                    for (int k = claims[i].InchesFromTopEdge; k < claims[i].InchesFromTopEdge + claims[i].Height; k++)
                    {
                        fabric[j, k] = fabric[j, k] + 1;
                    }
                }
            }

            return fabric.Cast<int>().ToArray().Count(c => c >= 2);
        }
        
        private static int Part2(List<string> input)
        {
            List<Claim> claims = input.Select(c => c.Split(' ')).Select(c => new Claim(
                Convert.ToInt32(c[0].Substring(1)),
                Convert.ToInt32(c[2].Split(',')[0]),
                Convert.ToInt32(c[2].Split(',')[1].Replace(":", "")),
                Convert.ToInt32(c[3].Split('x')[0]),
                Convert.ToInt32(c[3].Split('x')[1])
            )).ToList();

            var fabric = new (int Id, int Changes)[claims.Max(c => c.InchesFromLeftEdge + c.Width), claims.Max(c => c.InchesFromTopEdge + c.Height)];

            for (int i = 0; i < claims.Count; i++)
            {
                for (int j = claims[i].InchesFromLeftEdge; j < claims[i].InchesFromLeftEdge + claims[i].Width; j++)
                {
                    for (int k = claims[i].InchesFromTopEdge; k < claims[i].InchesFromTopEdge + claims[i].Height; k++)
                    {
                        fabric[j, k].Changes = fabric[j, k].Changes + 1;
                        fabric[j, k].Id = claims[i].Id;
                    }
                }
            }

            bool isEveryIdMyIdAndOnlyChangedOnce = true;

            for (int i = 0; i < claims.Count; i++)
            {
                for (int j = claims[i].InchesFromLeftEdge; j < claims[i].InchesFromLeftEdge + claims[i].Width; j++)
                {
                    for (int k = claims[i].InchesFromTopEdge; k < claims[i].InchesFromTopEdge + claims[i].Height; k++)
                    {
                        if (fabric[j, k].Id != claims[i].Id || fabric[j, k].Changes != 1)
                        {
                            isEveryIdMyIdAndOnlyChangedOnce = false;
                        }
                    }
                }

                if (isEveryIdMyIdAndOnlyChangedOnce)
                {
                    return claims[i].Id;
                }
                else
                {
                    isEveryIdMyIdAndOnlyChangedOnce = true;
                }
            }

            return -1;
       }
    }
}
