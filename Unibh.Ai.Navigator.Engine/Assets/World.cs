using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class World
    {
        public Spot[,] Quadrants { get; private set; }

        public FieldVision FieldVision { get; set; }

        public World(int m, int n)
        {
            var weight = m * n;

            Quadrants = new Spot[m, n];

            for (int x = (m - 1); x >= 0; --x)
            {
                for (int y = (n - 1); y >= 0; y--)
                {
                    Quadrants[x, y] = new Spot(weight--, x, y);
                }
            }
        }

        public int CalculateRoute(int value)
        {
            //var route = FieldVision[0].OfType<Route>().OrderByDescending(x => x.Weight).FirstOrDefault();

            //var value1 = Quadrants.CalculateFinalDestination(value, route);


            for (int i = 0; i < FieldVision.Count; i++)
            {
                var route = FieldVision[i].OfType<Spot>().OrderByDescending(x => x.Weight).FirstOrDefault();

                var value1 = Quadrants.CalculateFinalDestination(value, route);
            }


            return -1;
        }

        public override string ToString()
        {
            return this.Draw();
        }
    }
}
