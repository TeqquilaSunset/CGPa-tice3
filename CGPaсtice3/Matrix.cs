using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPaсtice3
{
    internal class Matrix
    {
        /// <summary>
        /// Поворт
        /// </summary>
        /// <param name="A">Матрица с координатами фигуры</param>
        /// <param name="f">угол наклона в градусах</param>
        /// <returns>Матрица с преобразованными координатами фигуры</returns>
        public int[,] Rotation(int[,] A, int f)
        {
            int[,] rotation =
        {
            {Convert.ToInt32(Math.Cos(f)), Convert.ToInt32(Math.Sin(f)), 0},
            {-Convert.ToInt32(Math.Sin(f)), Convert.ToInt32(Math.Cos(f)), 0},
            {0, 0, 1},
        };
            return Multiplication(A, rotation);
        }

        /// <summary>
        /// Растяжение сжатие
        /// </summary>
        /// <param name="A"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[,] Dilatation(int[,] A, int x, int y)
        {
            int[,] dilatation =
        {
            {x, 0, 0},
            {0, y, 0},
            {0, 0, 1},
        };
            return Multiplication(A, dilatation);
        }

        /// <summary>
        /// Отражение
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[,] Irror_reflection(int[,] A)
        {
            int[,] irror_reflection =
        {
            {1, 0, 0},
            {0, -1, 0},
            {0, 0, 1},
        };
            return Multiplication(A, irror_reflection);
        }

        /// <summary>
        /// Перенос
        /// </summary>
        /// <param name="A"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[,] Translation(int[,] A, int x, int y)
        {
            int[,] translation =
        {
            {1, 0, 0},
            {0, 1, 0},
            {x, y, 1},
        };
            return Multiplication(A, translation);
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="A">Матрица А</param>
        /// <param name="B">Матрица В</param>
        /// <returns>Матрица с результатами перемножения</returns>
        private int[,] Multiplication(int[,] A, int[,] B)
        {
            int[,] r = new int[A.GetLength(0),  A.GetLength(1)];
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
