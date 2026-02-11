using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    public class Square
    {
        internal Point _bottomLeftVertex;
        internal double _side;

        public Square(Point point, double side)
        {
            _bottomLeftVertex = point;
            _side = side;
        }

        public Square(double xVertex, double yVertex, double side)
        {
            _bottomLeftVertex = new Point(xVertex, yVertex);
            _side = side;
        }
        public bool IsInside(Point p)
        {
            return p.GetX() >= _bottomLeftVertex.GetX() &&
                    p.GetX() <= (_bottomLeftVertex.GetX() + _side) &&
                    p.GetY() >= _bottomLeftVertex.GetY() &&
                    p.GetY() <= (_bottomLeftVertex.GetY() + _side);
        }
    }
}
