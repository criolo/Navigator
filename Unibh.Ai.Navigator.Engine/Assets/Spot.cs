namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class Spot
    {
        public int Weight { get; set; }
        public bool Visited { get; set; }
        public Coordinate Coordinate { get; set; }

        public Spot(int weigth, int x, int y)
        {
            Weight = weigth;
            Coordinate = new Coordinate(x, y);
        }

        public Spot(int weigth, Coordinate coordinate)
        {
            Weight = weigth;
            Coordinate = coordinate;
        }

        public override string ToString()
        {
            return string.Format("({0}) {1}", Weight, Coordinate);
        }
    }
}
