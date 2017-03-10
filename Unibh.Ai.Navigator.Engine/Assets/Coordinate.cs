namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate On(int x, int y)
        {
            return new Coordinate(x, y);
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
    }
}
