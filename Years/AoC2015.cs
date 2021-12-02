using System;
using System.Collections.Generic;
using static System.Console;

namespace AdventOfCode
{
    static class AoC2015
    {
        #region ===== WeekOne =====

        #region DayOne
        public static void RunDayOne()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayOne("Data\\2015\\DayOneTest1.txt", true));
            WriteLine(DayOne("Data\\2015\\DayOneTest2.txt", true));

            //Result
            WriteLine("---Results---");
            WriteLine(DayOne("Data\\2015\\DayOne.txt", false));
        }

        private static int DayOne(string path, bool isTest)
        {
            bool found = false;
            int floor = 0;
            int position = 1;

            string data = FileIO.ReadFile(path);

            if (data == null)
            {
                WriteLine("Error occured...");
                return -1;
            }

            foreach (var instruction in data)
            {
                if (instruction.Equals('('))
                {
                    floor++;
                }
                else if (instruction.Equals(')'))
                {
                    floor--;
                }

                if (floor == -1 && !found)
                {
                    found = true;
                }
                else if (!found)
                {
                    position++;
                }
            }

            if (!isTest)
            {
                WriteLine(position);
            }

            return floor;
        }
        #endregion

        #region DayTwo
        public static void RunDayTwo()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayTwo("Data\\2015\\DayTwoTest1.txt", true));
            WriteLine(DayTwo("Data\\2015\\DayTwoTest2.txt", true));

            //Results
            WriteLine("---Results---");
            WriteLine(DayTwo("Data\\2015\\DayTwo.txt", false));
        }

        private static int DayTwo(string path, bool test)
        {
            int totalArea = 0;
            int totalLength = 0;

            List<string> data = FileIO.ReadFileByLines(path);

            foreach (string line in data)
            {
                string[] dimensions = line.Split('x');
                int[] integers = new int[3];

                integers[0] = Convert.ToInt32(dimensions[0]);
                integers[1] = Convert.ToInt32(dimensions[1]);
                integers[2] = Convert.ToInt32(dimensions[2]);

                totalArea +=
                    2 * integers[0] * integers[1] + 2 * integers[1] * integers[2] + 2 * integers[2] * integers[0];

                Array.Sort(integers);

                totalArea += Convert.ToInt32(integers[0]) * Convert.ToInt32(integers[1]);

                if (!test)
                {
                    totalLength += 2 * integers[0] + 2 * integers[1];

                    totalLength += integers[0] * integers[1] * integers[2];
                }
            }

            if (!test)
            {
                WriteLine(totalLength);
            }

            return totalArea;
        }
        #endregion

        #region DayThree
        public static void RunDayThree()
        {
            WriteLine("---Tests---");
            WriteLine(DayThree("Data\\2015\\DayThreeTest1.txt", true));
            WriteLine(DayThree("Data\\2015\\DayThreeTest2.txt", true));
            WriteLine(DayThree("Data\\2015\\DayThreeTest3.txt", true) + Environment.NewLine);

            //Results
            //WriteLine("---Results---");
            WriteLine(DayThree("Data\\2015\\DayThree.txt", false) + Environment.NewLine);
        }

        private static int DayThree(string path, bool isTest)
        {
            int x = 0;
            int y = 0;
            int roboX = 0;
            int roboY = 0;
            bool doRobo = false;
            List<TwoDimensionCoordinates> HousesVisited = new();

            HousesVisited.Add(new TwoDimensionCoordinates() { X = x, Y = y });

            string data = FileIO.ReadFile(path);

            foreach (var instruction in data)
            {
                if (!isTest && doRobo)
                {
                    switch (instruction)
                    {
                        case '^':
                            roboY++;
                            break;
                        case 'v':
                            roboY--;
                            break;
                        case '>':
                            roboX++;
                            break;
                        case '<':
                            roboX--;
                            break;
                    }

                    if (!HousesVisited.Exists(z => z.X == roboX && z.Y == roboY))
                    {
                        HousesVisited.Add(new TwoDimensionCoordinates() { X = roboX, Y = roboY });
                    }

                    doRobo = !doRobo;
                }
                else
                {
                    switch (instruction)
                    {
                        case '^':
                            y++;
                            break;
                        case 'v':
                            y--;
                            break;
                        case '>':
                            x++;
                            break;
                        case '<':
                            x--;
                            break;
                    }
                    
                    if (!HousesVisited.Exists(z => z.X == x && z.Y == y))
                    {
                        HousesVisited.Add(new TwoDimensionCoordinates() { X = x, Y = y });
                    }

                    doRobo = !doRobo;
                }
            }

            return HousesVisited.Count;
        }
        #endregion

        #region DayFour
        public static void RunDayFour()
        {
            WriteLine("---Tests---");
            WriteLine(DayThree("Data\\2015\\DayFourTest1.txt", true));
            WriteLine(DayThree("Data\\2015\\DayFourTest2.txt", true));
            WriteLine(DayThree("Data\\2015\\DayFourTest3.txt", true) + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayThree("Data\\2015\\DayFour.txt", false) + Environment.NewLine);
        }

        //private static void DayFour()
        //{

        //}
        #endregion

        #endregion
    }
}