using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGPaсtice3
{
    public partial class Form1 : Form
    {
        static int X;
        static int Y;
        static double[,] matrixPoints = new double[4, 3];
        Matrix matrix = new Matrix();
        public Form1()
        {
            InitializeComponent();
            UpdateMatrix();
        }
        private void UpdateMatrix()
        {
            var x = (pictureBox1.Width - 40 - pictureBox1.Width / 2) / 10;
            var y = (pictureBox1.Height - 40 - pictureBox1.Height / 2) / 10;
            var p1 = new Point(7 * x, y * 10);
            var p2 = new Point(-4 * x, y * 3);
            var p3 = new Point(Convert.ToInt32(-x * 5.5), -y * 3);
            var p4 = new Point(Convert.ToInt32(-x * 5.5), -y * 9);
            Point[] points = new Point[] { p1, p2, p3, p4 };

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
            X = pictureBox1.Width;
            Y = pictureBox1.Height;
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

            //matrixPoints = matrix.Irror_reflection(matrixPoints, -1, 1);
            //matrixPoints = matrix.Translation(matrixPoints, 4 * x, 1);
            //matrixPoints = matrix.Dilatation(matrixPoints, 0.8, 0.8);
            //matrixPoints = matrix.Rotation(matrixPoints, 15 * Math.PI / 180);
            var p1 = new Point(Convert.ToInt32(matrixPoints[0, 0] + xcentre), Convert.ToInt32(matrixPoints[0, 1] + ycentre));
            var p2 = new Point(Convert.ToInt32(matrixPoints[1, 0] + xcentre), Convert.ToInt32(matrixPoints[1, 1] + ycentre));
            var p3 = new Point(Convert.ToInt32(matrixPoints[2, 0] + xcentre), Convert.ToInt32(matrixPoints[2, 1] + ycentre));
            var p4 = new Point(Convert.ToInt32(matrixPoints[3, 0] + xcentre), Convert.ToInt32(matrixPoints[3, 1] + ycentre));
            Point[] points2 = new Point[] { p1, p2, p3, p4 };

            Pen penGreen = new Pen(Color.Green, 1);
            g.DrawPolygon(penGreen, points2);
            //g.DrawPolygon(penRed, points);
        }
        //сдвиг
        private void button1_Click(object sender, EventArgs e)
        {

            matrixPoints = matrix.Translation(matrixPoints, Convert.ToInt32(textBox1.Text) * (pictureBox1.Width - 40 - pictureBox1.Width / 2) / 10,
                -Convert.ToInt32(textBox2.Text) * (pictureBox1.Height - 40 - pictureBox1.Height / 2) / 10);
            //matrixPoints = matrix.Translation(matrixPoints, 0, Convert.ToInt32(textBox2.Text));
        }
        // масштабирование
        private void button2_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Dilatation(matrixPoints, Convert.ToDouble(textBox4.Text),
                Convert.ToDouble(textBox3.Text));
        }
        //отражение
        private void button3_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Irror_reflection(matrixPoints, -1, 1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Irror_reflection(matrixPoints, 1, -1);
        }
        //поворот
        private void button4_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Rotation(matrixPoints, Convert.ToDouble(textBox5.Text) * Math.PI / 180);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            matrixPoints = matrix.Dilatation(matrixPoints, Convert.ToDouble(pictureBox1.Width / (double)X),
                Convert.ToDouble(pictureBox1.Height / (double)Y)); 
        }
    }
}
