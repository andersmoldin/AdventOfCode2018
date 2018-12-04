using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04
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
            Dictionary<int, int[]> log = ProduceLog(input);

            var guardWithMostMinutesAsleep = log.Aggregate((l, r) => l.Value.Sum() > r.Value.Sum() ? l : r).Key;
            var minuteMostAsleep = Array.IndexOf(log[guardWithMostMinutesAsleep], log[guardWithMostMinutesAsleep].Max());

            return guardWithMostMinutesAsleep * minuteMostAsleep;
        }

        private static int Part2(List<string> input)
        {
            Dictionary<int, int[]> log = ProduceLog(input);

            var guardWithAMinutesMostFrequentlyAsleep = log.Aggregate((l, r) => l.Value.Max() > r.Value.Max() ? l : r).Key;
            var minuteMostFrequentlyAsleep = Array.IndexOf(log[guardWithAMinutesMostFrequentlyAsleep], log[guardWithAMinutesMostFrequentlyAsleep].Max());

            return guardWithAMinutesMostFrequentlyAsleep * minuteMostFrequentlyAsleep;
        }


        private static Dictionary<int, int[]> ProduceLog(List<string> input)
        {
            var records = input.Select(r => r.Split(']')).Select(r => new
            {
                TimeStamp = (Convert.ToDateTime(r[0].Replace("[", ""))),
                Note = r[1].Trim()
            }).OrderBy(o => o.TimeStamp).ToList();

            var log = new Dictionary<int, int[]>();

            foreach (var record in records.Where(r => r.Note.StartsWith("Guard", StringComparison.CurrentCulture)))
            {
                log.TryAdd(Convert.ToInt32(record.Note.Split(" ")[1].Replace("#", "")), new int[60]);
            }

            int currentGuard = 0;

            for (int i = 0; i < records.Count; i++)
            {
                switch (records[i].Note.Split(" ")[0])
                {
                    case "Guard":
                        for (int j = i + 1; j < records.Count; j++)
                        {
                            currentGuard = Convert.ToInt32(records[i].Note.Split(" ")[1].Replace("#", ""));

                            if (records[j].Note.Split(" ")[0] == "Guard")
                            {
                                break;
                            }
                            else if (records[j].Note.Split(" ")[0] == "falls")
                            {
                                for (int k = records[j].TimeStamp.Minute; k < records[j + 1].TimeStamp.Minute; k++)
                                {
                                    log[currentGuard][k] = log[currentGuard][k] + 1;
                                }
                            }
                        }
                        break;
                }
            }

            return log;
        }
    }
}
