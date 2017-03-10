using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unibh.Ai.Navigator.Engine.Assets;
using Unibh.Ai.Navigator.Engine.Functionality;

namespace Unibh.Ai.Navigator
{
    class Program
    {
        static void Main(string[] args)
        {
            var fieldVision = Move.To(0, 0).ThenTo(0, 1).ThenTo(0, 2).AndFinallyTo(1, 2);

            var world = new World(5, 8);



            Console.Write(world.ToString());

            Console.ReadKey();
        }
    }
}
