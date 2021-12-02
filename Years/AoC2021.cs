using System;
using System.Collections.Generic;
using static System.Console;

namespace AdventOfCode
{
    static class AoC2021
    {
        #region ===== Week One =====

        #region DayOne
        public static void RunDayOne()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayOne("Data\\2021\\DayOneTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayOne("Data\\2021\\DayOne.txt") + Environment.NewLine);
        }

        private static int DayOne(string path)
        {
            List<string> readings = FileIO.ReadFileByLines(path);

            //----Part Two----
            int increase = 0;
            int lastGroup;

            List<int> groups = new();

            for (int i = 1; i < readings.Count - 1; i++)
            {
                int sum = Convert.ToInt32(readings[i - 1]) + Convert.ToInt32(readings[i]) + Convert.ToInt32(readings[i + 1]);

                groups.Add(sum);
            }

            lastGroup = groups[0];

            foreach (var group in groups)
            {
                if (Convert.ToInt32(group) > lastGroup)
                {
                    increase++;
                }

                lastGroup = Convert.ToInt32(group);
            }



            //----Part One----
            //int increase = 0;
            //int lastReading;

            //lastReading = Convert.ToInt32(readings[0]);

            //foreach (var reading in readings)
            //{
            //    if (Convert.ToInt32(reading) > lastReading)
            //    {
            //        increase++;
            //    }

            //    lastReading = Convert.ToInt32(reading);
            //}

            return increase;
        }
        #endregion

        #endregion
    }
}