using System;
using Unibh.Ai.Navigator.Engine.Assets;
using Unibh.Ai.Navigator.Engine.Functionality;

namespace Unibh.Ai.Navigator
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(5, 8);

            world.FieldVision = Move.To(0, 0).ThenTo(0, 1).ThenTo(0, 2).AndFinallyTo(1, 2);

            world.CalculateRoute(20);

            Console.Write(world.ToString());

            Console.Write(world.FieldVision.ToString());

            Console.ReadKey();
        }
    }
}
