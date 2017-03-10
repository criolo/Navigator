using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibh.Ai.Navigator.Engine.Assets
{
    public class FieldVision
    {
        private List<Guide[,]> _guides;

        public FieldVision(int[,] coordinates)
        {
            var weightMatrix = BuildWeightMatrix(coordinates);
            _guides = weightMatrix.ToGuideArray().ToList();           
        }

        private List<int[,]> BuildWeightMatrix(int[,] coordinates)
        {
            var weightMatrix = new List<int[,]>();

            weightMatrix.Add(coordinates);
            weightMatrix.Add(coordinates.FlipX());
            weightMatrix.Add(coordinates.Transport());
            weightMatrix.Add(coordinates.Transport().FlipX());

            if (coordinates.GetLength(0) > 1)
            {
                weightMatrix.Add(coordinates.FlipY());
                weightMatrix.Add(coordinates.FlipY().FlipX());
                weightMatrix.Add(coordinates.Transport().FlipY());
                weightMatrix.Add(coordinates.Transport().FlipY().FlipX());
            }

            return weightMatrix;
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();

            foreach (var guide in _guides)
            {
                buffer.AppendLine(guide.Draw());
            }

            return buffer.ToString();
        }
    }
}
