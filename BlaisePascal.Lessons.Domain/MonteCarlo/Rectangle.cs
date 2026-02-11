using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain
{
    /// <summary>
    /// Nuova classe di supporto per definire un'area rettangolare.
    /// </summary>
    public class Rectangle
    {
        public Point BottomLeftVertex { get; }
        public double Width { get; }
        public double Height { get; }
        public double Area { get; }

        public Rectangle(Point bottomLeft, double width, double height)
        {
            BottomLeftVertex = bottomLeft;
            Width = width;
            Height = height;
            Area = width * height;
        }
    }
}
