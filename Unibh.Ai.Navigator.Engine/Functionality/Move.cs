using System.Collections.Generic;
using Unibh.Ai.Navigator.Engine.Assets;

namespace Unibh.Ai.Navigator.Engine.Functionality
{
    public class Move
    {
        private LinkedList<Coordinate> _path;

        public static Move To(int x, int y)
        {
            return new Move(Coordinate.On(x, y));
        }

        private Move()
        {
            _path = new LinkedList<Coordinate>();
        }

        public Move(params Coordinate[] coordinates)
            : this()
        {
            foreach (var coordnate in coordinates)
            {
                _path.AddLast(coordnate);
            }
        }

        public Move ThenTo(int x, int y)
        {
            _path.AddLast(Coordinate.On(x, y));

            return this;
        }

        public FieldVision AndFinallyTo(int x, int y)
        {
            _path.AddLast(Coordinate.On(x, y));

            return new FieldVision(_path.ToWeightArray());
        }

        public FieldVision End()
        {
            return new FieldVision(_path.ToWeightArray());
        }

        public override string ToString()
        {
            return _path.Draw();
        }
    }
}
