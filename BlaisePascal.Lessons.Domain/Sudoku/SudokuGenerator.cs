using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.Sudoku
{
    public class SudokuGenerator
    {
        public int[,] Matrix { get; set; }
        public Random Random { get; set; }

        public SudokuGenerator(Random random)
        {
            Matrix = new int[9, 9];
            Random = random;
        }

        public void generateMatrix()
        {
            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    Matrix[r, c] = Random.Next(1, 10);
                }
            }
        }
        public void findSudoku()
        {
            bool found = false;
            do
            {
                //generateMatrix();
                Matrix = new int[,] {
                            {4,7,2,1,8,9,5,3,6},
                            {1,9,5,3,2,6,4,7,8 },
                            {3,6,8,5,7,4,1,9,2},
                            {7,1,9,4,3,8,2,6,5},
                            {8,5,3,2,6,1,9,4,7},
                            {6,2,4,9,5,7,3,8,1},
                            {9,8,1,7,4,2,6,5,3},
                            {5,4,6,8,1,3,7,2,9},
                            {2,3,7,6,9,5,8,1,4}
                };
                found = checkSudoku();
            } while (!found);

        }
        public bool checkSudoku()
        {
            int err_count = checkRows();
            if (err_count != 0) return false;
            err_count = checkColumns();
            if (err_count != 0) return false;
            err_count = checkSubMatrix();
            if (err_count != 0) return false;
            return true;
        }
        public int checkRows()
        {
            int[] check = check_init();
            int err_count = 0;

            for (int r = 0; r < Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < Matrix.GetLength(1); c++)
                {
                    if (check[Matrix[r, c] - 1] != 0)
                        err_count++;
                    check[Matrix[r, c] - 1]++;
                }
                check = check_init();
            }
            return err_count;

        }
        public int checkColumns()
        {
            int[] check = check_init();
            int err_count = 0;

            for (int c = 0; c < Matrix.GetLength(0); c++)
            {
                for (int r = 0; r < Matrix.GetLength(1); r++)
                {
                    if (check[Matrix[r, c] - 1] != 0)
                        err_count++;
                    check[Matrix[r, c] - 1]++;
                }
                check = check_init();
            }
            return err_count;
        }
        public int checkSubMatrix()
        {
            int[] check = check_init();
            int r_ini, c_ini, err_count = 0;

            for (int sub = 0; sub < 9; sub++)
            {
                r_ini = (sub % 3) * 3;
                c_ini = (sub / 3) * 3;

                for (int i = 0; i < 9; i++)
                {
                    if (check[Matrix[r_ini + i % 3, c_ini + i / 3] - 1] != 0)
                        err_count++;
                    check[Matrix[r_ini + i % 3, c_ini + i / 3] - 1]++;
                }
                check = check_init();
            }
            return err_count;
        }
        private int[] check_init()
        {
            int[] check = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return check;
        }

    }
}
