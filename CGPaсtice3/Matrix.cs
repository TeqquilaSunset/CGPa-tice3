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
        /// Поворт относительно X
        /// </summary>
        /// <param name="A">Матрица с координатами фигуры</param>
        /// <param name="f">угол наклона в градусах</param>
        /// <returns>Матрица с преобразованными координатами фигуры</returns>
        public float[,] RotationX(float[,] A, float f)
        {
            float[,] rotation =
        {
            { 1, 0, 0 ,0},
            { 0, (float)Math.Cos(f), (float)Math.Sin(f), 0 },
            { 0, -(float)Math.Sin(f), (float)Math.Cos(f), 0},
            { 0, 0, 0, 1 }
        };

            return Multiplication(A, rotation);
        }

        /// <summary>
        /// Поворот отностительно Y
        /// </summary>
        /// <param name="A"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public float[,] RotationY(float[,] A, float f)
        {
            float[,] rotation =
        {
            { (float)Math.Cos(f), 0, -(float)Math.Sin(f), 0 },
            { 0, 1, 0, 0 },
            { (float)Math.Sin(f), 0, (float)Math.Cos(f), 0 },
            { 0, 0, 0, 1 }
        };

            return Multiplication(A, rotation);
        }

        /// <summary>
        /// Поворот относительно Z
        /// </summary>
        /// <param name="A"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public float[,] RotationZ(float[,] A, float f)
        {
            float[,] rotation =
                {
                { (float)Math.Cos(f), (float)Math.Sin(f), 0, 0},
                {-(float)Math.Sin(f), (float)Math.Cos(f), 0, 0 },
                { 0 ,0, 1, 0 },
                {0, 0, 0, 1 }
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
        public float[,] Dilatation(float[,] A, float x, float y, float z)
        {
            float[,] dilatation =
        {
            {x, 0, 0, 0},
            {0, y, 0, 0},
            {0, 0, z, 0},
            {0, 0, 0, 1},
        };
            return Multiplication(A, dilatation);
        }

        /// <summary>
        /// Отражение
        /// </summary>
        /// <param name="A"></param>
        /// <param name="s">x или y по какой оси инвертировать</param>
        /// <returns></returns>
        public float[,] Irror_reflection(float[,] A, int x, int y, int z)
        {
            float[,] irror_reflection =
        {
            {x, 0, 0, 0},
            {0, y, 0, 0},
            {0, 0, z, 0},
            {0, 0, 0, 1},
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
        public float[,] Translation(float[,] A, int x, int y, int z)
        {
            float[,] translation =
        {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {x, y, z, 1},
        };
            return Multiplication(A, translation);
        }

        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="A">Матрица А</param>
        /// <param name="B">Матрица В</param>
        /// <returns>Матрица с результатами перемножения</returns>
        private float[,] Multiplication(float[,] A, float[,] B)
        {
            float[,] r = new float[A.GetLength(0), A.GetLength(1)];
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

        public float[,] Isometric(float[,] A, float f1, float f2, float f3)
        {
            float[,] temp =
            {
            {1, 0, 0, 1},
            {0, 1, 0, 1},
            {0, 0, 1, 1},
        };
            //float[,] isometric =
            //{
            //    {(float)Math.Cos(f1), (float)Math.Sin(f2)*(float)Math.Cos(f1), 0, 0 },
            //    {0, (float )Math.Cos(f2), 0, 0 },
            //    {(float)Math.Sin(f1), -(float)Math.Sin(f2)*(float)Math.Cos(f1), 0, 0 },
            //    {0, 0, 0, 1 }
            //};
            float[,] isometric =
            {
                {(float)Math.Cos(f1), (float)Math.Sin(f2)*(float)Math.Cos(f1), 0, 0 },
                {0, (float )Math.Cos(f2), 0, 0 },
                {(float)Math.Sin(f1), -(float)Math.Sin(f2)*(float)Math.Cos(f1), 0, 0 },
                {0, 0, 0, 1 }
            };
            //return Multiplication(A, isometric);
            return Multiplication(Multiplication(A, isometric), temp);
        }
    }
}
