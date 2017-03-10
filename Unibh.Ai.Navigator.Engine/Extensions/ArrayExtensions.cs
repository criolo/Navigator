using System.Text;

namespace Unibh.Ai.Navigator
{
    public static class ArrayExtensions
    {
        public static T[,] FlipX<T>(this T[,] array)
        {
            var result = new T[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < result.GetLength(1); i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    result[j, i] = array[array.GetLength(0) - j - 1, i];
                }
            }

            return result;
        }

        public static T[,] FlipY<T>(this T[,] array)
        {
            var result = new T[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = array[i, result.GetLength(1) - j - 1];
                }
            }

            return result;
        }

        public static T[,] Transport<T>(this T[,] array)
        {
            var result = new T[array.GetLength(1), array.GetLength(0)];

            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    result[x, y] = array[y, x];
                }
            }

            return result;
        }
    }
}
