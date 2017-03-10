using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unibh.Ai.Navigator.Engine.Assets;

namespace Unibh.Ai.Navigator
{
    public static class AssetExtensions
    {
        private static string DrawLine<T>(this T[,] array, int? padWidth = null)
        {
            var buffer = new StringBuilder();
            padWidth = padWidth ?? (array.GetLength(0) * array.GetLength(1)).ToString().Length;

            buffer.Append("+");

            for (int i = 0; i < array.GetLength(1); i++)
            {
                buffer.Append(string.Format("-{0}-+", new string('-', padWidth.Value)));
            }

            return buffer.ToString();
        }

        public static Coordinate[,] ToArray(this LinkedList<Coordinate> path)
        {
            var result = new Coordinate[(path.Max(c => c.X) + 1), (path.Max(c => c.Y) + 1)];

            for (int x = 0; x < result.GetLongLength(0); x++)
            {
                for (int y = 0; y < result.GetLongLength(1); y++)
                {
                    var coordinate = path.FirstOrDefault(c => c.X.Equals(x) && c.Y.Equals(y));

                    result[x, y] = (coordinate != null) ? coordinate : null;
                }
            }

            return result;
        }

        public static int[,] ToWeightArray(this LinkedList<Coordinate> path)
        {
            var result = new int[(path.Max(c => c.X) + 1), (path.Max(c => c.Y) + 1)];
            var coordinate = path.First;
            var weight = 0;

            while(coordinate != null)
            {
                result[coordinate.Value.X, coordinate.Value.Y] = ++weight;
                coordinate = coordinate.Next;
            }

            return result;
        }

        public static IEnumerable<Guide[,]> ToGuideArray(this List<int[,]> weightMatrix)
        {
            foreach (var weight in weightMatrix)
            {
                var guideArray = new Guide[weight.GetLength(0), weight.GetLength(1)];

                for (int x = 0; x < weight.GetLength(0); x++)
                {
                    for (int y = 0; y < weight.GetLength(1); y++)
                    {
                        guideArray[x, y] = new Guide(weight[x, y], new Coordinate(x, y));
                    }
                }

                yield return guideArray;
            }
        }

        public static string Draw(this LinkedList<Coordinate> path)
        {
            var array = new string[(path.Max(c => c.X) + 1), (path.Max(c => c.Y) + 1)];
            var coordinate = path.First;
            var counter = 0;
            var buffer = new StringBuilder();

            while (coordinate != null)
            {
                array[coordinate.Value.X, coordinate.Value.Y] = counter.ToString();
                counter++;
                coordinate = coordinate.Next;
            }

            var padWidth = counter.ToString().Length;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                buffer.AppendLine(array.DrawLine(padWidth));

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    buffer.Append(string.Format("| {0} ", (array[i, j] ?? string.Empty).PadLeft(padWidth, '\0')));
                }

                buffer.AppendLine("|");
            }

            buffer.AppendLine(array.DrawLine(padWidth));

            return buffer.ToString();
        }

        public static string Draw(this Guide[,] guide)
        {
            var buffer = new StringBuilder();

            var padWidth = guide.OfType<Guide>().Max(g => g.Weight).ToString().Length;

            for (int i = 0; i < guide.GetLength(0); i++)
            {
                buffer.AppendLine(guide.DrawLine(padWidth));

                for (int j = 0; j < guide.GetLength(1); j++)
                {
                    buffer.Append(string.Format("| {0} ", guide[i, j].Weight.ToString().PadLeft(padWidth, '\0')));
                }

                buffer.AppendLine("|");
            }

            buffer.AppendLine(guide.DrawLine(padWidth));

            return buffer.ToString();
        }

        public static string Draw(this World world)
        {
            var buffer = new StringBuilder();

            var padWidth = world.Quadrants.OfType<Spot>().Max(g => g.Value).ToString().Length;

            for (int i = 0; i < world.Quadrants.GetLength(0); i++)
            {
                buffer.AppendLine(world.Quadrants.DrawLine(padWidth));

                for (int j = 0; j < world.Quadrants.GetLength(1); j++)
                {
                    buffer.Append(string.Format("| {0} ", world.Quadrants[i, j].Value.ToString().PadLeft(padWidth, '\0')));
                }

                buffer.AppendLine("|");
            }

            buffer.AppendLine(world.Quadrants.DrawLine(padWidth));

            return buffer.ToString();
        }
    }
}
