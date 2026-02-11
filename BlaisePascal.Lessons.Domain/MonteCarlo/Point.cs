namespace BlaisePascal.LessonExamples.Domain
{
    public class Point
    {
        //attributes
        private double _x;
        private double _y;

        public Point()
        {
            _x = 0;
            _y = 0;
        }
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double GetX()
        {
            return _x;
        }
        public double GetY()
        {
            return _y;
        }
        public void Traslation(double deltaX, double deltaY)
        {
            _x += deltaX;
            // _X = _X + deltaX
            _y += deltaY;
        }
        public double Distance(double xOther, double yOther)
        {
            return Math.Sqrt((_x - xOther) * (_x - xOther) + (_y - yOther) * (_y - yOther));
        }
        public double Distance(Point otherPoint)
        {
            //return Math.Sqrt((_x - otherPoint._x) * (_x - otherPoint._x) + (_y - otherPoint._y) * (_y - otherPoint._y));
            //return this.Distance(otherPoint._x, otherPoint._y);
            return otherPoint.Distance(_x, _y);
        }
    }
}
