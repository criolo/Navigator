namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class Spot
    {
        public int Value { get; set; }
        public bool Visited { get; set; }

        public Spot(int value)
        {
            Value = value;
        }
    }
}
