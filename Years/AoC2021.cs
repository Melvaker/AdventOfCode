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
                        WriteLine("Error: unknown instruction");
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
            //            WriteLine("Error: unknown instruction");
            //            break;
            //    }
            //}

            //displacement = depth * distance;

            return displacement;
        }
        #endregion

        #region DayThree
        public static void RunDayThree()
        {
            WriteLine("---Tests---");
            WriteLine(DayThree("Data\\2021\\DayThreeTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayThree("Data\\2021\\DayThree.txt") + Environment.NewLine);
        }

        private static int DayThree(string path)
        {
            //----Part Two----
            int lifeSupportRating;

            List<string> reportData = FileIO.ReadFileByLines(path);
            int length = reportData[0].Length - 1;

            for (int i = length; i >= 0; i--)
            {
                int one = 0;
                int zero = 0;
                int oxygenResult = 0;

                foreach (var data in reportData)
                {
                    int temp = Convert.ToInt32(data, 2);

                    if (((1 << i) & temp) > 0)
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                if (one == zero || one > zero)
                {
                    oxygenResult = (1 << i);
                }

                for (int ii = reportData.Count - 1; ii >= 0; ii--)
                {
                    int temp = Convert.ToInt32(reportData[ii], 2);
                    int checkValue;

                    if (oxygenResult == 0)
                    {
                        temp = ~temp;
                        checkValue = 1 << i;
                    }
                    else
                    {
                        checkValue = oxygenResult;
                    }

                    if (0 == (temp & checkValue))
                    {
                        reportData.RemoveAt(ii);
                    }
                }
                
                if (reportData.Count <= 1)
                {
                    break;
                }
            }

            lifeSupportRating = Convert.ToInt32(reportData[0], 2);

            reportData = FileIO.ReadFileByLines(path);

            for (int i = length; i >= 0; i--)
            {
                int one = 0;
                int zero = 0;
                int carbonResult = 0;

                foreach (var data in reportData)
                {
                    int temp = Convert.ToInt32(data, 2);

                    if (((1 << i) & temp) > 0)
                    {
                        one++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                if (one < zero)
                {
                    carbonResult = (1 << i);
                }

                for (int ii = reportData.Count - 1; ii >= 0; ii--)
                {
                    int temp = Convert.ToInt32(reportData[ii], 2);
                    int checkValue;

                    if (carbonResult == 0)
                    {
                        temp = ~temp;
                        checkValue = 1 << i;
                    }
                    else
                    {
                        checkValue = carbonResult;
                    }
                    
                    if (0 == (temp & checkValue))
                    {
                        reportData.RemoveAt(ii);
                    }
                }

                if (reportData.Count <= 1)
                {
                    break;
                }
            }

            lifeSupportRating *= Convert.ToInt32(reportData[0], 2);
            
            return lifeSupportRating;



            //----Part One----
            //int gammaRate = 0;
            //int epsilonRate = 0;
            //int powerConsumption;

            //List<string> reportData = FileIO.ReadFileByLines(path);
            //int length = reportData[0].Length;

            //for (int i = 0; i < length; i++)
            //{
            //    int one = 0;
            //    int zero = 0;

            //    foreach (var data in reportData)
            //    {
            //        int temp = Convert.ToInt32(data, 2); 

            //        if (((1 << i) & temp) > 0)
            //        {
            //            one++;
            //        }
            //        else
            //        {
            //            zero++;
            //        }
            //    }

            //    if (one > zero)
            //    {
            //        gammaRate = gammaRate | (1 << i);
            //    }
            //    else
            //    {
            //        epsilonRate = epsilonRate | (1 << i);
            //    }
            //}

            //powerConsumption = gammaRate * epsilonRate;

            //return powerConsumption;
        }
        #endregion

        #region DayFour
        public static void RunDayFour()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayFour("Data\\2021\\DayFourTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayFour("Data\\2021\\DayFour.txt") + Environment.NewLine);
        }

        private static int DayFour(string path)
        {
            //----Part Two----
            List<string> data = FileIO.ReadFileByLines(path);
            List<BingoBoard> boards = new();
            string[] calls = data[0].Split(",");
            bool lastBoard = false;
            int lastCall = 0;
            int winningBoard = -1;
            int numberBoards;

            data.RemoveAt(0);

            int length = data.Count / 6;

            for (int i = 0; i < length; i++)
            {
                string temp = "";

                data.RemoveAt(0);

                for (int ii = 0; ii < 5; ii++)
                {
                    temp += data[0];
                    temp += " ";

                    data.RemoveAt(0);
                }

                boards.Add(new BingoBoard(temp));
            }

            foreach (var call in calls)
            {
                foreach (var board in boards)
                {
                    board.CheckCall(call);
                }

                numberBoards = boards.Count;

                for (int i = 0; i < numberBoards; i++)
                {

                    if (boards[i].CheckForBingo() && boards.Count > 1)
                    {
                        boards.RemoveAt(i);
                        i--;
                        numberBoards--;
                    }
                    else if (boards[i].CheckForBingo())
                    {
                        lastBoard = true;
                        lastCall = Convert.ToInt32(call);
                        break;
                    }
                }

                if (lastBoard)
                {
                    winningBoard = 0;
                    break;
                }
            }



            //----Part One----
            //List<string> data = FileIO.ReadFileByLines(path);
            //List<BingoBoard> boards = new();
            //string[] calls = data[0].Split(",");
            //bool hasWinner = false;
            //int lastCall = 0;
            //int winningBoard = -1;

            //data.RemoveAt(0);

            //int length = data.Count / 6;

            //for (int i = 0; i < length; i++)
            //{
            //    string temp = ""; 

            //    data.RemoveAt(0);

            //    for (int ii = 0; ii < 5; ii++)
            //    {
            //        temp += data[0];
            //        temp += " ";

            //        data.RemoveAt(0);
            //    }

            //    boards.Add(new BingoBoard(temp));
            //}

            //foreach (var call in calls)
            //{
            //    foreach (var board in boards)
            //    {
            //        board.CheckCall(call);
            //    }

            //    foreach (var board in boards)
            //    {
            //        hasWinner = board.CheckForBingo();

            //        if (hasWinner)
            //        {
            //            winningBoard = boards.IndexOf(board);
            //            lastCall = Convert.ToInt32(call);
            //            break;
            //        }
            //    }

            //    if (hasWinner)
            //    {
            //        break;
            //    }
            //}

            if (!lastBoard)
            {
                return 0;
            }

            return boards[winningBoard].ScoreMultiplier() * lastCall;
        }
        #endregion

        #endregion
    }
}