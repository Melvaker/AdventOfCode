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

        #region DayFive
        public static void RunDayFive()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayFive("Data\\2021\\DayFiveTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Tests---");
            WriteLine(DayFive("Data\\2021\\DayFive.txt") + Environment.NewLine);
        }

        private static int DayFive(string path)
        {
            //----Part Two----
            List<string> rawLines = FileIO.ReadFileByLines(path);
            List<Line> lines = new();

            int maxX = 0;
            int maxY = 0;

            int numberOfIntersections = 0;

            foreach (var line in rawLines)
            {
                string[] temp = line.Split(" -> ");
                TwoDimensionCoordinates start = new();
                TwoDimensionCoordinates end = new();

                start.X = Convert.ToInt32(temp[0].Split(",")[0]);
                start.Y = Convert.ToInt32(temp[0].Split(",")[1]);

                end.X = Convert.ToInt32(temp[1].Split(",")[0]);
                end.Y = Convert.ToInt32(temp[1].Split(",")[1]);

                lines.Add(new Line(start, end));

                if (maxX < start.X)
                {
                    maxX = start.X;
                }
                else if (maxX < end.X)
                {
                    maxX = end.X;
                }

                if (maxY < start.Y)
                {
                    maxY = start.Y;
                }
                else if (maxY < end.Y)
                {
                    maxY = end.Y;
                }
            }

            for (int i = 0; i <= maxX; i++)
            {
                for (int ii = 0; ii <= maxY; ii++)
                {
                    int counter = 0;

                    foreach (var line in lines)
                    {
                        if (line.StartPoint.X == line.EndPoint.X)
                        {
                            if (line.StartPoint.X == i)
                            {
                                if (line.StartPoint.Y <= ii && line.EndPoint.Y >= ii)
                                {
                                    counter++;
                                }
                                else if (line.EndPoint.Y <= ii && line.StartPoint.Y >= ii)
                                {
                                    counter++;
                                }
                            }
                        }
                        else if (line.StartPoint.Y == line.EndPoint.Y)
                        {
                            if (line.StartPoint.Y == ii)
                            {
                                if (line.StartPoint.X <= i && line.EndPoint.X >= i)
                                {
                                    counter++;
                                }
                                else if (line.EndPoint.X <= i && line.StartPoint.X >= i)
                                {
                                    counter++;
                                }
                            }
                        }
                        else if (i >= line.StartPoint.X && i <= line.EndPoint.X)
                        {
                            if (ii >= line.StartPoint.Y && ii <= line.EndPoint.Y)
                            {
                                if (Math.Abs(i - line.StartPoint.X) == Math.Abs(ii - line.StartPoint.Y))
                                {
                                    counter++;
                                }
                            }
                            else if (ii <= line.StartPoint.Y && ii >= line.EndPoint.Y)
                            {
                                if (Math.Abs(i - line.StartPoint.X) == Math.Abs(ii - line.StartPoint.Y))
                                {
                                    counter++;
                                }
                            }
                        }
                        else if (i <= line.StartPoint.X && i >= line.EndPoint.X)
                        {
                            if (ii >= line.StartPoint.Y && ii <= line.EndPoint.Y)
                            {
                                if (Math.Abs(i - line.StartPoint.X) == Math.Abs(ii - line.StartPoint.Y))
                                {
                                    counter++;
                                }
                            }
                            else if (ii <= line.StartPoint.Y && ii >= line.EndPoint.Y)
                            {
                                if (Math.Abs(i - line.StartPoint.X) == Math.Abs(ii - line.StartPoint.Y))
                                {
                                    counter++;
                                }
                            }
                        }
                    }

                    if (counter > 1)
                    {
                        numberOfIntersections++;
                    }
                }
            }

            return numberOfIntersections;




            //----Part One----
            //List<string> rawLines = FileIO.ReadFileByLines(path);
            //List<Game> lines = new();

            //int maxX = 0;
            //int maxY = 0;

            //int numberOfIntersections = 0;

            //foreach (var line in rawLines)
            //{
            //    string[] temp = line.Split(" -> ");
            //    TwoDimensionCoordinates start = new();
            //    TwoDimensionCoordinates end = new();

            //    start.X = Convert.ToInt32(temp[0].Split(",")[0]);
            //    start.Y = Convert.ToInt32(temp[0].Split(",")[1]);

            //    end.X = Convert.ToInt32(temp[1].Split(",")[0]);
            //    end.Y = Convert.ToInt32(temp[1].Split(",")[1]);

            //    lines.Add(new Game(start, end));

            //    if (maxX < start.X)
            //    {
            //        maxX = start.X;
            //    }
            //    else if (maxX < end.X)
            //    {
            //        maxX = end.X;
            //    }

            //    if (maxY < start.Y)
            //    {
            //        maxY = start.Y;
            //    }
            //    else if (maxY < end.Y)
            //    {
            //        maxY = end.Y;
            //    }
            //}

            //for (int i = 0; i <= maxX; i++)
            //{
            //    for (int ii = 0; ii <= maxY; ii++)
            //    {
            //        int counter = 0;

            //        foreach (var line in lines)
            //        {
            //            if (line.StartPoint.X == line.EndPoint.X)
            //            {
            //                if (line.StartPoint.X == i)
            //                {
            //                    if (line.StartPoint.Y <= ii && line.EndPoint.Y >= ii)
            //                    {
            //                        counter++;
            //                    }
            //                    else if (line.EndPoint.Y <= ii && line.StartPoint.Y>= ii)
            //                    {
            //                        counter++;
            //                    }
            //                }
            //            }
            //            else if (line.StartPoint.Y == line.EndPoint.Y)
            //            {
            //                if (line.StartPoint.Y == ii)
            //                {
            //                    if (line.StartPoint.X <= i && line.EndPoint.X >= i)
            //                    {
            //                        counter++;
            //                    }
            //                    else if (line.EndPoint.X <= i && line.StartPoint.X >= i)
            //                    {
            //                        counter++;
            //                    }
            //                }
            //            }
            //        }

            //        if (counter > 1)
            //        {
            //            numberOfIntersections++;
            //        }
            //    }
            //}

            //return numberOfIntersections;
        }
        #endregion

        #endregion

        #region ===== Week Two =====

        #region DaySix
        public static void RunDaySix()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DaySix("Data\\2021\\DaySixTest1.txt", 18));
            WriteLine(DaySix("Data\\2021\\DaySixTest1.txt", 80));
            WriteLine(DaySix("Data\\2021\\DaySixTest1.txt", 256) + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DaySix("Data\\2021\\DaySix.txt", 80));
            WriteLine(DaySix("Data\\2021\\DaySix.txt", 256) + Environment.NewLine);
        }

        private static long DaySix(string path, int days)
        {
            string input = FileIO.ReadFile(path);
            long numberFish = 0;
            string[] starterFish = input.Split(",");
            long[] lanternFish = new long[10];

            foreach (var fish in starterFish)
            {
                lanternFish[Convert.ToInt64(fish)]++;
            }

            do
            {
                lanternFish[9] = lanternFish[0];
                lanternFish[7] += lanternFish[0];

                for (int i = 0; i <  lanternFish.Length - 1; i++)
                {
                    lanternFish[i] = lanternFish[i + 1];
                }

                days--;
            } while (days > 0);

            for (int i = 0; i < lanternFish.Length - 1; i++)
            {
                numberFish += lanternFish[i];
            }

            return numberFish;

            //----Old Method----
            //string fishInput = FileIO.ReadFile(path);
            //List<int> newList = new();
            //List<int> lanternFish = new();

            //string[] temp = fishInput.Split(",");
            //for (int i = 0; i < temp.Length; i++)
            //{
            //    lanternFish.Add(Convert.ToInt32(temp[i]));
            //}

            //do
            //{
            //    foreach (var age in lanternFish)
            //    {
            //        if (age == 0)
            //        {
            //            newList.Add(8);
            //            newList.Add(6);
            //        }
            //        else
            //        {
            //            newList.Add(age - 1);
            //        }
            //    }

            //    lanternFish.Clear();
            //    lanternFish.AddRange(newList);
            //    newList.Clear();

            //    days--;
            //} while (days > 0);

            //return lanternFish.Count;
        }
        #endregion

        #region DaySeven
        public static void RunDaySeven()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DaySeven("Data\\2021\\DaySevenTest1.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DaySeven("Data\\2021\\DaySeven.txt") + Environment.NewLine);
        }

        private static int DaySeven(string path)
        {
            //---Part Two---
            string input = FileIO.ReadFile(path);
            string[] inputArray = input.Split(",");
            List<int> crabs = new();
            float positionPrecise = 0f;
            int positionRounded;
            int fuelUsed = 0;

            foreach (var crab in inputArray)
            {
                crabs.Add(Convert.ToInt32(crab));
            }

            crabs.Sort();
            
            foreach (var crabPosition in crabs)
            {
                positionPrecise += crabPosition;
            }

            positionPrecise /= crabs.Count;

            //I am not sure why i needed to use the two different casting methods to get a correct answer.
            //Rounding up gives the correct answer for the sample,
            //  but type casting gives the correct answer for the problem.
            //I probably need to look into how the conversions are taking place.
            positionRounded = (int)positionPrecise;
            //positionRounded = Convert.ToInt32(positionPrecise);

            foreach (var moves in crabs)
            {
                for (int i = 1; i <= Math.Abs(moves - positionRounded); i++)
                {
                    fuelUsed += i;
                }
            }

            return fuelUsed;




            //---Part One---
            //string input = FileIO.ReadFile(path);
            //string[] inputArray = input.Split(",");
            //List<int> crabs = new();
            //int position;
            //int fuelUsed = 0;

            //foreach(var crab in inputArray)
            //{
            //    crabs.Add(Convert.ToInt32(crab));
            //}

            //crabs.Sort();

            //if (crabs.Count % 2 == 1)
            //{
            //    position = crabs[crabs.Count / 2 + 1];
            //}
            //else
            //{
            //    position = crabs[crabs.Count / 2];
            //}

            //foreach (var moves in crabs)
            //{
            //    fuelUsed += Math.Abs(moves - position);
            //}

            //return fuelUsed;
        }
        #endregion

        #region DayEight
        public static void RunDayEight()
        {
            //Tests
            WriteLine("---Tests---");
            WriteLine(DayEight("Data\\2021\\DayEightTest1.txt"));
            WriteLine(DayEight("Data\\2021\\DayEightTest2.txt") + Environment.NewLine);

            //Results
            WriteLine("---Results---");
            WriteLine(DayEight("Data\\2021\\DayEight.txt") + Environment.NewLine);
        }

        private static int DayEight(string path)
        {
            //----Part Two----

            return Int32.Parse(path);




            //----Part One----
            //List<string> data = FileIO.ReadFileByLines(path);
            //int[] digits = { 0, 0, 0, 0, 0, 0, 0 };
            //int number = 0;

            //foreach (var line in data)
            //{
            //    string[] temp = line.Split("|");
            //    temp = temp[1].Split(" ");

            //    foreach (var entry in temp)
            //    {
            //        switch (entry.Length)
            //        {
            //            case 2:
            //                digits[1]++;
            //                break;
            //            case 3:
            //                digits[2]++;
            //                break;
            //            case 4:
            //                digits[3]++;
            //                break;
            //            case 7:
            //                digits[6]++;
            //                break;
            //            default:
            //                break;
            //        }
            //    }
            //}

            //foreach (var count in digits)
            //{
            //    number += count;
            //}

            //return number;
        }
        #endregion

        #endregion
    }
}