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

        #region DayTwo
        public static void RunDayTwo()
        {
            WriteLine("---Tests---");
            WriteLine(DayTwo("Data\\2021\\DayTwoTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayTwo("Data\\2021\\DayTwo.txt") + Environment.NewLine);
        }

        private static int DayTwo(string path)
        {
            //----Part Two----
            int aim = 0;
            int depth = 0;
            int distance = 0;
            int displacement;

            List<string> instructions = FileIO.ReadFileByLines(path);

            foreach (var instruction in instructions)
            {
                string[] details = instruction.Split(" ");

                switch (details[0].ToLower())
                {
                    case "forward":
                        distance += Convert.ToInt32(details[1]);
                        depth += Convert.ToInt32(details[1]) * aim;
                        break;
                    case "up":
                        aim -= Convert.ToInt32(details[1]);
                        break;
                    case "down":
                        aim += Convert.ToInt32(details[1]);
                        break;
                    default:
                        Console.WriteLine("Error: unknown instruction");
                        break;
                }
            }

            displacement = depth * distance;



            //----Part One----
            //int depth = 0;
            //int distance = 0;
            //int displacement;

            //List<string> instructions = FileIO.ReadFileByLines(path);

            //foreach (var instruction in instructions)
            //{
            //    string[] details = instruction.Split(" "); 

            //    switch (details[0].ToLower())
            //    {
            //        case "forward":
            //            distance += Convert.ToInt32(details[1]);
            //            break;
            //        case "up":
            //            depth -= Convert.ToInt32(details[1]);
            //            break;
            //        case "down":
            //            depth += Convert.ToInt32(details[1]);
            //            break;
            //        default:
            //            Console.WriteLine("Error: unknown instruction");
            //            break;
            //    }
            //}

            //displacement = depth * distance;

            return displacement;
        }
        #endregion

        #endregion
    }
}