using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.MagicSquare
{
    public class Matrix
    {
        public int[,] MagicSquare { get; private set; }
        public int Iterations { get; set; }
        private Random Random { get; set; }

        public Matrix(Random random)
        {
            MagicSquare = new int[3, 3];
            Random = random;
        }
        public void CreateMatrix()
        {
            for (int r = 0; r < MagicSquare.GetLength(0); r++)
            {
                for (int c = 0; c < MagicSquare.GetLength(1); c++)
                {
                    MagicSquare[r, c] = Random.Next(1, 10);//1-9 value
                }
            }
        }
        public void CreateMagicSquare()
        {
            do
            {
                CreateMatrix();
                Iterations++;
            } while (!CheckMagicSquare());

            string result = GetMagicSquare();
        }
        public bool CheckMagicSquare()
        {
            bool ok = true;
            int sumR = 0, sumC = 0;
            int i = 0;
            while (i < MagicSquare.GetLength(0) && ok)
            {
                sumR = 0;
                sumC = 0;
                for (int j = 0; j < MagicSquare.GetLength(1); j++)
                {
                    sumR += MagicSquare[i, j];
                    sumC += MagicSquare[j, i];
                }
                if (sumR != 15 || sumC != 15)
                {
                    ok = false;
                }
                i++;
            }
            if (ok)
            {
                if (MagicSquare[0, 0] + MagicSquare[1, 1] + MagicSquare[2, 2] != 15 ||
                   MagicSquare[0, 2] + MagicSquare[1, 1] + MagicSquare[2, 0] != 15)
                {
                    ok = false;
                }
            }
            return ok;
        }
        public string GetMagicSquare()
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < MagicSquare.GetLength(0); r++)
            {
                for (int c = 0; c < MagicSquare.GetLength(1); c++)
                {
                    sb.Append(MagicSquare[r, c]);
                    sb.Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
