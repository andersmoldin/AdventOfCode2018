﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadLines("input.txt");

            Console.WriteLine($"Part 1: {Part1(input)}");
            Console.WriteLine($"Part 2: {Part2(input)}");
        }

        private static int Part1(IEnumerable<string> boxIds)
        {
            #region First solution
            //int doubles = 0;
            //int triples = 0;

            //foreach (var boxId in boxIds)
            //{
            //    var occurences = boxId.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());

            //    if (occurences.Any(l => l.Value == 2))
            //    {
            //        doubles += 1;
            //    }

            //    if (occurences.Any(l => l.Value == 3))
            //    {
            //        triples += 1;
            //    }
            //}

            //return doubles * triples;
            #endregion

            #region Second solution
            return boxIds.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 2)) * boxIds.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 3));
            #endregion
        }

        private static string Part2(IEnumerable<string> boxIds)
        {
            var ids = boxIds.Distinct().ToList();

            for (int i = 0; i < ids[0].Length; i++)
            {
                var pair = ids.Select(id => id.Remove(i, 1)).GroupBy(id => id).FirstOrDefault(g => g.Count() > 1);
                if (pair != null)
                {
                    var common = pair.First();
                    return common;
                }
            }

            return null;
        }
    }
}
