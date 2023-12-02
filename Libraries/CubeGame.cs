using System;

namespace AdventOfCode
{
    public static class CubeGame
    {
        public static int ID{ get; set; }

        public static int Red { get; set; }

        public static int Green { get; set; }
        
        public static int Blue { get; set; }

        public static string Game {  get; set; }

        /// <summary>
        /// Red, Green, Blue
        /// </summary>
        public static Tuple<int, int, int> CubeSet { get; set; }

        public static void ParseGame()
        {
            //Example format
            //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green

            //Reset colors and ID.
            ID = 0;
            Red = 0;
            Green = 0;
            Blue = 0;

            //Strip Game ID
            ParseID();

            //Parse colors
            ParseColors();
        }

        private static void ParseID()
        {
            string[] seperators = { "Game ", ":" };

            ID = Int32.Parse(Game.Split(seperators, StringSplitOptions.None)[1]);
        }

        private static void ParseColors()
        {
            char[] headerSeperators = { ':' };
            char[] setSeperators = { ';' };
            char[] colorSeperators = { ',' };

            //strip game ID from 
            //string setList = ;

            string[] sets = Game.Split(headerSeperators)[1]
                .Trim().Split(setSeperators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var set in sets)
            {
                string[] colors = set.Split(colorSeperators);

                foreach (var color in colors)
                {
                    string check = color.Trim().ToLower();

                    if (check.Contains("red"))
                    {
                        int number = Int32.Parse(check.Split(' ')[0]);
                        Red = MyMath.Max(Red, number);
                    }
                    else if (check.Contains("green"))
                    {
                        int number = Int32.Parse(check.Split(' ')[0]);
                        Green = MyMath.Max(Green, number);
                    }
                    else if (check.Contains("blue"))
                    {
                        int number = Int32.Parse(check.Split(' ')[0]);
                        Blue = MyMath.Max(Blue, number);
                    }
                }
            }
        }

        public static int CubePower()
        {
            return Red * Green * Blue; ;
        }

        public static bool IsPossible()
        {
            if (CubeSet.Item1 < Red || CubeSet.Item2 < Green || CubeSet.Item3 < Blue)
                return false;

            return true;
        }
    }
}