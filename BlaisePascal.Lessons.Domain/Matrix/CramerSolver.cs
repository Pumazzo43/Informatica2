using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public class CramerSolver : ILinearSystemSolver
    {
        public double[] Solve(SquareMatrix A, double[] b)
        {
            double detA = A.Determinant();
            double[] x = new double[A.Dimension];
            SquareMatrix copy;
            if (Math.Abs(detA) < 1e-15)
            {
                throw new Exception("System is not determined");
            }
            else
            {
                for (int i = 0; i < A.Dimension; i++)
                {
                    copy = A.DeepCopy();
                    for (int l = 0; l < A.Dimension; l++)
                    {
                        copy[l, i] = b[l];
                    }

                    x[i] = copy.Determinant() / detA;
                }
            }
            return x;
        }
    }
}
