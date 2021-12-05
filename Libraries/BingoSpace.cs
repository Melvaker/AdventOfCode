namespace AdventOfCode
{
    class BingoSpace
    {
        public string Value { get; }
        public bool Drawn { get; private set; } = false;

        public void SpaceDrawn()
        {
            Drawn = true;
        }

        public BingoSpace(string value)
        {
            Value = value;
        }
    }
}