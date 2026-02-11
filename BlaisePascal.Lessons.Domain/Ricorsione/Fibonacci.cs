using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.LessonExamples.Domain.Ricorsione
{
    internal class Fibonacci
    {
        public int F(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return F(n - 1) + F(n - 2);
        }
    }
}
