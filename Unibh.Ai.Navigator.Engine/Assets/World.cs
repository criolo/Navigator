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

        public World(int m, int n)
        {
            var value = m * n;

            Quadrants = new Spot[m, n];

            for (int x = (m - 1); x >= 0; --x)
            {
                for (int y = (n - 1); y >= 0; y--)
                {
                    Quadrants[x, y] = new Spot(value--);
                }
            }
        }

        public override string ToString()
        {
            return this.Draw();
        }
    }
}
