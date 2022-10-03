using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPaсtice3
{
    internal class Matrix
    {
        int[,] dilatation =
        {
            {0, 0, 0},
            {1, 1, 1},
            {2, 2, 2},
        };
        int[,] irror_reflection =
        {
            {0, 0, 0},
            {1, 1, 1},
            {2, 2, 2},
        };
        int[,] translation =
        {
            {0, 0, 0},
            {1, 1, 1},
            {2, 2, 2},
        };

        //public int[,] Rotation(int[,] A, int f)
        //{
        //    int[,] rotation =
        //{
        //    {Convert.ToInt32(Math.Cos(f)), Convert.ToInt32(Math.Sin(f)), 0},
        //    {-Convert.ToInt32(Math.Sin(f)), Convert.ToInt32(Math.Cos(f)), 0},
        //    {0, 0, 1},
        //};
        //    int[,] r = int[,]

        //}

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="A">Матрица А</param>
        /// <param name="B">Матрица В</param>
        /// <returns>Матрица с результатами перемножения</returns>
        private int[,] Multiplication(int[,] A, int[,] B)
        {
            int[,] r = new int[B.GetLength(0), B.Length];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        r[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return r;
        }
    }
}
