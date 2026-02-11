using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.BookingLab
{
    public class Hole
    {
        public int Offset { get; set; }
        public int Lenght { get; set; }
        public Hole()
        {

        }
        public Hole(int offset, int lenght)
        {
            Offset = offset;
            Lenght = lenght;
        }
    }
}
