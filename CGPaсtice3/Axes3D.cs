using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGPaсtice3
{
    internal class Axes3D
    {
        int stepX;
        int stepY;
        int stepZ;
        int centreX;
        int centreY;
        int centreZ;

        public Axes3D(Graphics g, PictureBox pictureBox1)
        {

            Pen pen = new Pen(Color.Black, 1);
            Font font = new Font("Arial", 10);

            //x
            g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Width - 40,
            pictureBox1.Height / 2);
            //y
            g.DrawLine(pen, pictureBox1.Width / 2, 40, pictureBox1.Width / 2,
                pictureBox1.Height / 2);
            //z
            g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Width / 4,
                pictureBox1.Height - pictureBox1.Height / 4);

            //Стрелки x
            g.DrawLine(pen, pictureBox1.Width - 40, pictureBox1.Height / 2, pictureBox1.Width - 40 - 10,
            pictureBox1.Height / 2 - 10);
            g.DrawLine(pen, pictureBox1.Width - 40, pictureBox1.Height / 2, pictureBox1.Width - 40 - 10,
            pictureBox1.Height / 2 + 10);

            //Стрелки y
            g.DrawLine(pen, pictureBox1.Width / 2, 40, pictureBox1.Width / 2 - 10,
            40 + 10);
            g.DrawLine(pen, pictureBox1.Width / 2, 40, pictureBox1.Width / 2 + 10,
            40 + 10);

            //Стрелки z
            g.DrawLine(pen, pictureBox1.Width / 4, pictureBox1.Height - pictureBox1.Height / 4,
                pictureBox1.Width / 4, pictureBox1.Height - pictureBox1.Height / 4 - 12);
            g.DrawLine(pen, pictureBox1.Width / 4, pictureBox1.Height - pictureBox1.Height / 4,
                pictureBox1.Width / 4 + 12, pictureBox1.Height - pictureBox1.Height / 4);

            g.DrawString("x", font, Brushes.Black, pictureBox1.Width - 50,
                pictureBox1.Height / 2 + 10);
            g.DrawString("y", font, Brushes.Black, pictureBox1.Width / 2 + 10, 40);
            g.DrawString("0", font, Brushes.Black, pictureBox1.Width / 2 + 2,
                pictureBox1.Height / 2 - 20);
            g.DrawString("z", font, Brushes.Black, pictureBox1.Width / 4 + 5,
                pictureBox1.Height - pictureBox1.Height / 4 - 25);

            stepX = (pictureBox1.Width - 40 - pictureBox1.Width / 2) / 15;
            stepY = (pictureBox1.Height - 40 - pictureBox1.Height / 2) / 15;
            //stepZ = (Int32)Math.Sqrt(Math.Pow(Math.Abs(pictureBox1.Width / 2 - pictureBox1.Width / 4), 2) +
             //   Math.Pow(Math.Abs(pictureBox1.Height / 2 - pictureBox1.Height / 4), 2)) / 15;
            centreX = pictureBox1.Width / 2;
            centreY = pictureBox1.Height / 2;
            //centreZ = (Int32)Math.Sqrt(Math.Pow(Math.Abs(pictureBox1.Width / 2), 2) +
            //    Math.Pow(Math.Abs(pictureBox1.Height / 2), 2));
        }
        private PointF[] GetPoints(float[,] A)
        {
            PointF[] points = new PointF[A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1) / 2; j++)
                {
                    if (j == 0)
                        points[i].X = A[i, j] * stepX + centreX;
                    else if (j == 1)
                        points[i].Y = A[i, j] * stepY + centreY;
                }
            }
            return points;
        }
        public void Draw(float[,] A, Graphics g, PictureBox pictureBox, bool flag)
        {
            Pen pen = new Pen(Color.Red, 2);
            Pen pen2 = new Pen(Color.Green, 1);


            //laba4
            if (flag)
            {
                //Практика
                g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY);
                g.DrawLine(pen, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY);
                g.DrawLine(pen, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY, centreX + A[3, 0] * stepX, centreY + A[3, 1] * stepY);
                g.DrawLine(pen, centreX + A[3, 0] * stepX, centreY + A[3, 1] * stepY, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY);

                g.DrawLine(pen, centreX + A[4, 0] * stepX, centreY + A[4, 1] * stepY, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY);
                g.DrawLine(pen, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);
                g.DrawLine(pen, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY);
                g.DrawLine(pen, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY, centreX + A[4, 0] * stepX, centreY + A[4, 1] * stepY);

                g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[4, 0] * stepX, centreY + A[4, 1] * stepY);
                g.DrawLine(pen, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY);
                g.DrawLine(pen, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);
                g.DrawLine(pen, centreX + A[3, 0] * stepX, centreY + A[3, 1] * stepY, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY);
                return;
            }
            g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY);
            g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY);
            g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY);
            g.DrawLine(pen, centreX + A[0, 0] * stepX, centreY + A[0, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);

            g.DrawLine(pen, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY);
            g.DrawLine(pen, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);
            g.DrawLine(pen, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY);
            g.DrawLine(pen, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);

            g.DrawLine(pen, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY, centreX + A[1, 0] * stepX, centreY + A[1, 1] * stepY);
            g.DrawLine(pen, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY, centreX + A[2, 0] * stepX, centreY + A[2, 1] * stepY);
            g.DrawLine(pen, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY, centreX + A[5, 0] * stepX, centreY + A[5, 1] * stepY);
            g.DrawLine(pen, centreX + A[7, 0] * stepX, centreY + A[7, 1] * stepY, centreX + A[6, 0] * stepX, centreY + A[6, 1] * stepY);
            


        }
    }
}
