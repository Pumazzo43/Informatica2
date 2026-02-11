using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public interface ILinearSystemSolver
    {
        double[] Solve(SquareMatrix A, double[] b);
    }
}
