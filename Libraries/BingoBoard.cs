using System;

namespace AdventOfCode
{
    class BingoBoard
    {
        public BingoSpace[,] Spaces { get; } = new BingoSpace[5, 5];

        public void CheckCall(string call)
        {
            bool isFound = false;
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if (Spaces[i, ii].Value.Equals(call))
                    {
                        Spaces[i, ii].SpaceDrawn();

                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }
        }

        public bool CheckForBingo()
        {
            bool isWinner = false;

            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    isWinner = true;

                    if (!Spaces[i, ii].Drawn)
                    {
                        isWinner = false;
                        break;
                    }
                }

                if (isWinner)
                {
                    break;
                }
            }

            if (!isWinner)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int ii = 0; ii < 5; ii++)
                    {
                        isWinner = true;

                        if (!Spaces[ii, i].Drawn)
                        {
                            isWinner = false;
                            break;
                        }
                    }

                    if (isWinner)
                    {
                        break;
                    }
                }
            }

            return isWinner;
        }

        public int ScoreMultiplier()
        {
            int multiplier = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    if (!Spaces[i, ii].Drawn)
                    {
                        multiplier += Convert.ToInt32(Spaces[i, ii].Value);
                    }
                }
            }
            
            return multiplier;
        }

        public BingoBoard(string spaces)
        {
            string[] temp = spaces.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int j = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    Spaces[i, ii] = new BingoSpace(temp[j]);

                    j++;
                }
            }
        }
    }
}