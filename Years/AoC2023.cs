using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using static System.Console;

namespace AdventOfCode
{
    internal class AoC2023
    {
        #region Week 1

        #region Day 2

        public static void RunDayTwo()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayTwo(@"Data\2023\Day2Test.txt"));
            WriteLine();

            //Puzzle
            WriteLine("---Results---");
            WriteLine(DayTwo(@"Data\2023\Day2.txt") + Environment.NewLine);
            WriteLine();
        }

        public static int DayTwo(string path)
        {
            // --- Part 2 ---
            List<string> games = FileIO.ReadFileByLines(path);
            int sum = 0;

            foreach (var game in games)
            {
                CubeGame.Game = game;
                CubeGame.ParseGame();
                sum += CubeGame.CubePower();
            }

            return sum;

            // --- Part 1 ---
            //List<string> games = FileIO.ReadFileByLines(path);
            //int sum = 0;

            //foreach (var game in games)
            //{
            //    CubeGame.Game = game;
            //    CubeGame.ParseGame();
            //    CubeGame.CubeSet = new Tuple<int, int, int>(12, 13, 14);
            //    if (CubeGame.IsPossible())
            //        sum += CubeGame.ID;
            //}

            //return sum;
        }

        #endregion

        #region Day 1
        public static void RunDayOne()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayOne(@"Data\2023\Day1Test2.txt") + Environment.NewLine);

            //Puzzle
            WriteLine("---Results---");
            WriteLine(DayOne(@"Data\2023\Day1.txt") + Environment.NewLine);
        }

        private static long DayOne(string path)
        {
            //Tried umpteen times and used another solution to be able to move on to next day.
            //This solution is borrowed from
            //  https://github.com/MartinZikmund/advent-of-code-2023/blob/main/Day01_2/Program.cs
            var allDigits = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            for (int i = 1; i < 10; i++)
            {
                allDigits.Add(i.ToString(), i);
            }

            List<string> calibrations = FileIO.ReadFileByLines(path);

            long total = 0;

            foreach (var line in calibrations)
            {
                var firstIndex = line.Length;
                var lastIndex = -1;
                var firstValue = 0;
                var lastValue = 0;

                foreach (var digit in allDigits)
                {
                    var index = line.IndexOf(digit.Key);
                    if (index == -1)
                    {
                        continue;
                    }

                    if (index < firstIndex)
                    {
                        firstIndex = index;
                        firstValue = digit.Value;
                    }

                    index = line.LastIndexOf(digit.Key);

                    if (index > lastIndex)
                    {
                        lastIndex = index;
                        lastValue = digit.Value;
                    }
                }

                var fullNumber = firstValue * 10 + lastValue;
                total += fullNumber;
            }

            return total;


            //// --- Part 2 --- 
            //int sum = 0;
            //int number;
            ////int firstIndex;
            //int secondIndex;
            //int firstNumber = 0;
            //int secondNumber = 0;

            //TODO figure out why my solution is not working
            //Correct solution: 55686

            //string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //string[] digits = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            ////List<string> calibrations = FileIO.ReadFileByLines(path);

            //int lineNumber = 0;

            //foreach (var cal in calibrations)
            //{
            //    string c = cal.ToLower();

            //    firstIndex = 100;
            //    secondIndex = 0;

            //    for (int i = 0; i < 9; i++)
            //    {
            //        if (c.Contains(numbers[i]))
            //        {
            //            int index = c.IndexOf(numbers[i]);

            //            if (index < firstIndex)
            //            {
            //                firstIndex = index;
            //                firstNumber = i + 1;
            //            }
            //            if (index > secondIndex)
            //            {
            //                secondIndex = index;
            //                secondNumber = i + 1;
            //            }

            //            if (index != c.LastIndexOf(numbers[i]))
            //            {
            //                if (c.LastIndexOf(numbers[i]) > secondIndex)
            //                {
            //                    secondIndex = c.LastIndexOf(numbers[i]);
            //                    secondNumber = i + 1;
            //                }
            //            }
            //        }
            //    }

            //    for (int i = 0; i < 9; i++)
            //    {
            //        if (c.Contains(digits[i]))
            //        {
            //            int index = c.IndexOf(digits[i]);

            //            if (index < firstIndex)
            //            {
            //                firstIndex = index;
            //                firstNumber = i + 1;
            //            }
            //            if (index > secondIndex)
            //            {
            //                secondIndex = index;
            //                secondNumber = i + 1;
            //            }

            //            if (index != c.LastIndexOf(digits[i]))
            //            {
            //                if (c.LastIndexOf(digits[i]) > secondIndex)
            //                {
            //                    secondIndex = c.LastIndexOf(digits[i]);
            //                    secondNumber = i + 1;
            //                }
            //            }
            //        }
            //    }

            //    number = firstNumber * 10 + secondNumber;

            //    sum += number;

            //    Console.WriteLine("{0}  {1}  {2}  {3}  {4}", lineNumber++, cal, firstNumber, secondNumber, number);
            //}


            // --- Part 1 --- 
            //int sum = 0;
            //int number = 0;

            //List<string> calibrations = FileIO.ReadFileByLines(path);

            //foreach (var cal in calibrations)
            //{
            //    char[] characters = cal.ToCharArray();

            //    for (int i = 0; i < characters.Length; i++)
            //    {
            //        if (Char.IsNumber(characters[i]))
            //        {
            //            number = (int)Char.GetNumericValue(characters[i]) * 10;
            //            break;
            //        }
            //    }

            //    for (int i = characters.Length - 1; i >= 0; i--)
            //    {
            //        if (Char.IsNumber(characters[i]))
            //        {
            //            number += (int)Char.GetNumericValue(characters[i]);
            //            break;
            //        }
            //    }

            //    sum += number;
            //}

            //return sum;
        }
        #endregion

        #endregion
    }
}