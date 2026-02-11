using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public class LinearSystemContext
    {
        private ILinearSystemSolver _solver;

        public LinearSystemContext(ILinearSystemSolver solver) => _solver = solver;

        public void SetSolver(ILinearSystemSolver solver) => _solver = solver;

        public double[] Execute(SquareMatrix A, double[] b) => _solver.Solve(A, b);
    }
}
