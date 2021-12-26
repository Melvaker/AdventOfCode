namespace AdventOfCode
{
    class Line
    {
        public TwoDimensionCoordinates StartPoint { get; private set; }
        public TwoDimensionCoordinates EndPoint { get; private set; }

        public Line(TwoDimensionCoordinates start, TwoDimensionCoordinates end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}