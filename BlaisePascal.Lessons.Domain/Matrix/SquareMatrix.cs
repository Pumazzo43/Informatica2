using BlaisePascal.Lessons.Domain.MagicSquare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public class SquareMatrix : Matrix
    {
        public SquareMatrix(int dimension) : base(dimension, dimension) { }

        public SquareMatrix(double[] original) : base((int)Math.Sqrt(original.Length), (int)Math.Sqrt(original.Length))
        {
            int end = vector.Length;
            for (int i = 0; i < end; i++)
                vector[i] = original[i];
        }

        public SquareMatrix() : this(3) { }

        public int Dimension => Rows;

        public double Determinant() => Determinant(this);

        public double Determinant(SquareMatrix matrix)
        {
            int dim = matrix.Dimension;
            double result = 0;

            if (dim == 1) return matrix[0, 0]; // Caso base 1x1
            if (dim == 2)
            {
                result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int r = 0;
                for (int c = 0; c < dim; c++)
                {
                    int k = ((r + c) % 2 == 0) ? 1 : -1;
                    result += k * matrix[r, c] * Determinant(SubMatrix(matrix, r, c));
                }
            }
            return result;
        }

        public SquareMatrix SubMatrix(SquareMatrix matrix, int row, int col)
        {
            SquareMatrix subMatrix = new SquareMatrix(Rows - 1);
            int subRow = 0; int subCol = 0;
            for (int i = 0; i < matrix.Rows; i++)
            {

                if (i == row)
                    continue;

                for (int j = 0; j < matrix.Rows; j++)
                {
                    if (j == col)
                        continue;

                    subMatrix[subRow, subCol] = matrix[i, j];
                    subCol++;
                }
                subRow++;
            }
            return subMatrix;
        }

        public SquareMatrix DeepCopy()
        {
            SquareMatrix CopyMatrix = new SquareMatrix(Dimension);
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    CopyMatrix[i, j] = this[i, j];
                }
            }
            return CopyMatrix;
        }
    }
}
