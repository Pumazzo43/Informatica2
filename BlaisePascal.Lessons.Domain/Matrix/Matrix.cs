using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Matrix
{
    public class Matrix
    {
        protected double[] vector;
        private int rows, columns;

        public Matrix(int numRows, int numColumns)
        {
            rows = Math.Abs(numRows);
            columns = Math.Abs(numColumns);

            // Controllo che la matrice non abbia dimensioni nulle
            if ((rows * columns) == 0)
                throw new Exception($"Impossible to create a {rows} * {columns} matrix.");

            vector = new double[rows * columns];
            for (int i = 0; i < vector.Length; i++)
                vector[i] = 0.0;
        }

        public int Rows => rows;
        public int Columns => columns;

        public double this[int row, int column]
        {
            set
            {
                CheckDimensions(row, column);
                vector[row * this.columns + column] = value;
            }
            get
            {
                CheckDimensions(row, column);
                return vector[row * this.columns + column];
            }
        }

        protected void CheckDimensions(int row, int column)
        {
            if (!((row >= 0) && (row < rows) && (column >= 0) && (column < columns)))
            {
                throw new OverflowException($"Impossible to access cell [{row}] [{column}].");
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder("", 1000);
            for (int i = 0; i < vector.Length; i++)
            {
                if ((i > 0) && ((i % columns) == 0))
                    result.Append('\n');
                result.AppendFormat("{0,11:f4}", vector[i]);
            }
            result.Append("\n");
            return result.ToString();
        }
    }
}
