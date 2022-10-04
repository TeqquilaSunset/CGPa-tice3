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
        public double[,] Rotation(double[,] A, double f)
        {
            double[,] rotation =
        {
            {(double)Math.Cos(f), (double)Math.Sin(f), 0},
            {(double)-Math.Sin(f), (double)Math.Cos(f), 0},
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
        public double[,] Dilatation(double[,] A, double x, double y)
        {
            double[,] dilatation =
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
        /// <param name="s">x или y по какой оси инвертировать</param>
        /// <returns></returns>
        public double[,] Irror_reflection(double[,] A, int x, int y)
        {
            double[,] irror_reflection =
        {
            {x, 0, 0},
            {0, y, 0},
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
        public double[,] Translation(double[,] A, int x, int y)
        {
            double[,] translation =
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
        private double[,] Multiplication(double[,] A, double[,] B)
        {
            double[,] r = new double[A.GetLength(0),  A.GetLength(1)];
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
