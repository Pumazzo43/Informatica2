using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    public class Circle
    {
        private Point _center;
        private double _radius;

        public Circle(double xCenter, double yCenter, double r)
        {
            _center = new Point(xCenter, yCenter);
            _radius = r;
        }
        public Circle(double r)
        {
            _center = new Point();
            _radius = r;
        }
        public float Perimeter()
        {
            return (float)(2 * Math.PI * _radius);
        }
        public float Area()
        {
            return (float)(Math.PI * Math.Pow(_radius, 2));
        }
        public bool IsInside(Point p)
        {
            return p.Distance(_center) <= _radius;
        }
        public bool IsInside(double xPoint, double yPoint)
        {
            return _center.Distance(xPoint, yPoint) <= _radius;
        }
    }
}
