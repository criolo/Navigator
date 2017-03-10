namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class Guide
    {
        public int Weight { get; set; }
        public Coordinate Coordinate { get; set; }

        public Guide(int weigth, Coordinate coordinate)
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
