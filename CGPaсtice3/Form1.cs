using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGPaсtice3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawXY(object sender, EventArgs e)
        {
            Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            Pen penRed = new Pen(Color.Red, 2);
            Font font = new Font("Arial", 10);

            g.DrawLine(pen, 40, pictureBox1.Height / 2, pictureBox1.Width - 40,
                pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 40, pictureBox1.Width / 2,
                pictureBox1.Height - 60);
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

            g.DrawString("X", font, Brushes.Black, pictureBox1.Width - 50,
                pictureBox1.Height / 2 + 10);
            g.DrawString("Y", font, Brushes.Black, pictureBox1.Width / 2 + 10, 40);
            g.DrawString("0", font, Brushes.Black, pictureBox1.Width / 2 - 12,
                pictureBox1.Height / 2 + 4);

            var x = (pictureBox1.Width - 40 - pictureBox1.Width / 2) / 10;
            var y = (pictureBox1.Height - 40 - pictureBox1.Height / 2) / 10;
            var xcentre = pictureBox1.Width / 2;
            var ycentre = pictureBox1.Height / 2;
            for (int i = 1; i < 10; i++)
            {
                //Шаг на оx
                g.DrawLine(pen, pictureBox1.Width / 2 + x * i, pictureBox1.Height / 2 + 5,
                pictureBox1.Width / 2 + x * i, pictureBox1.Height / 2 - 5);
                g.DrawLine(pen, pictureBox1.Width / 2 - x * i, pictureBox1.Height / 2 + 5,
                pictureBox1.Width / 2 - x * i, pictureBox1.Height / 2 - 5);

                //Шаг на oy
                g.DrawLine(pen, pictureBox1.Width / 2 - 5, pictureBox1.Height / 2 - y * i,
                pictureBox1.Width / 2 + 5, pictureBox1.Height / 2 - y * i);
                g.DrawLine(pen, pictureBox1.Width / 2 - 5, pictureBox1.Height / 2 + y * i,
                pictureBox1.Width / 2 + 5, pictureBox1.Height / 2 + y * i);
            }

            //var p1 = new Point(x * 7 + xcentre, y * 10 + ycentre);
            //var p2 = new Point(x - 4 * x + xcentre, y * 3 + ycentre);
            //var p3 = new Point(Convert.ToInt32(x - 5.5 * x + xcentre), y - y * 3 + ycentre);
            //var p4 = new Point(Convert.ToInt32(x - 5.5 * x + xcentre), y - y * 9 + ycentre);

            var p1 = new Point(7 * x, y * 10);
            var p2 = new Point(-4 * x, y * 3);
            var p3 = new Point(Convert.ToInt32(-x * 5.5), -y * 3);
            var p4 = new Point(Convert.ToInt32(-x * 5.5), -y * 9);
            Point[] points = new Point[] { p1, p2, p3, p4 };

            double[,] matrixPoints = new double[points.Length, 3];
            for (int i = 0; i < matrixPoints.GetLength(0); i++)
            {
                for (int j = 0; j < matrixPoints.GetLength(1); j++)
                {
                    if (j == 0)
                        matrixPoints[i, j] = points[i].X;
                    else if (j == 1)
                        matrixPoints[i, j] = points[i].Y;
                    else matrixPoints[i, j] = 1;
                }
            }
            Matrix matrix = new Matrix();

            //matrixPoints = matrix.Irror_reflection(matrixPoints, -1, 1);
            //matrixPoints = matrix.Translation(matrixPoints, 4 * x, 1);
            //matrixPoints = matrix.Dilatation(matrixPoints, 0.8, 0.8);
            //matrixPoints = matrix.Rotation(matrixPoints, 15 * Math.PI / 180);
            p1 = new Point(Convert.ToInt32(matrixPoints[0, 0] + xcentre), Convert.ToInt32(matrixPoints[0, 1] + ycentre));
            p2 = new Point(Convert.ToInt32(matrixPoints[1, 0] + xcentre), Convert.ToInt32(matrixPoints[1, 1] + ycentre));
            p3 = new Point(Convert.ToInt32(matrixPoints[2, 0] + xcentre), Convert.ToInt32(matrixPoints[2, 1] + ycentre));
            p4 = new Point(Convert.ToInt32(matrixPoints[3, 0] + xcentre), Convert.ToInt32(matrixPoints[3, 1] + ycentre));
            Point[] points2 = new Point[] { p1, p2, p3, p4 };

            Pen penGreen = new Pen(Color.Green, 1);
            g.DrawPolygon(penGreen, points2);
            //g.DrawPolygon(penRed, points);
        }

    }
}
