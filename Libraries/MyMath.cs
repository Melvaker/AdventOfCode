namespace AdventOfCode
{
    public static class MyMath
    {
        public static int Max(int number1, int number2)
        {
            if (number1 < number2)
                return number2;

            return number1;
        }
    }
}
