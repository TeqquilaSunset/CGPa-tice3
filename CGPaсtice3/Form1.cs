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
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            Pen penRed = new Pen(Color.Red, 2);
            Font font = new Font("Arial", 10);

            g.DrawLine(pen, 40, ClientSize.Height / 2, ClientSize.Width - 40,
                ClientSize.Height / 2);
            g.DrawLine(pen, ClientSize.Width / 2, 40, ClientSize.Width / 2,
                ClientSize.Height - 60);
            //Стрелки x
            g.DrawLine(pen, ClientSize.Width - 40, ClientSize.Height / 2, ClientSize.Width - 40 - 10,
                ClientSize.Height / 2 - 10);
            g.DrawLine(pen, ClientSize.Width - 40, ClientSize.Height / 2, ClientSize.Width - 40 - 10,
                ClientSize.Height / 2 + 10);
            //Стрелки y
            g.DrawLine(pen, ClientSize.Width / 2, 40, ClientSize.Width / 2 - 10,
                40 + 10);
            g.DrawLine(pen, ClientSize.Width / 2, 40, ClientSize.Width / 2 + 10,
                40 + 10);

            g.DrawString("X", font, Brushes.Black, ClientSize.Width - 50,
                ClientSize.Height / 2 + 10);
            g.DrawString("Y", font, Brushes.Black, ClientSize.Width / 2 + 10, 40);
            g.DrawString("0", font, Brushes.Black, ClientSize.Width / 2 - 12,
                ClientSize.Height / 2 + 4);

            var x = (ClientSize.Width - 40 - ClientSize.Width / 2) / 10;
            var y = (ClientSize.Height - 40 - ClientSize.Height / 2) / 10;
            var xcentre = ClientSize.Width / 2;
            var ycentre = ClientSize.Height / 2;
            for (int i = 1; i < 10; i++)
            {
                //Шаг на оx
                g.DrawLine(pen, ClientSize.Width / 2 + x * i, ClientSize.Height / 2 + 5,
                ClientSize.Width / 2 + x * i, ClientSize.Height / 2 - 5);
                g.DrawLine(pen, ClientSize.Width / 2 - x * i, ClientSize.Height / 2 + 5,
                ClientSize.Width / 2 - x * i, ClientSize.Height / 2 - 5);

                //Шаг на oy
                g.DrawLine(pen, ClientSize.Width / 2 - 5, ClientSize.Height / 2 - y * i,
                ClientSize.Width / 2 + 5, ClientSize.Height / 2 - y * i);
                g.DrawLine(pen, ClientSize.Width / 2 - 5, ClientSize.Height / 2 + y * i,
                ClientSize.Width / 2 + 5, ClientSize.Height / 2 + y * i);
            }

            var p1 = new Point(x * 7 + xcentre, y * 10 + ycentre);
            var p2 = new Point(x - 4 * x + xcentre, y * 3 + ycentre);
            var p3 = new Point(Convert.ToInt32(x - 5.5 * x + xcentre), y - y * 3 + ycentre);
            var p4 = new Point(Convert.ToInt32(x - 5.5 * x + xcentre), y - y * 9 + ycentre);
            Point[] points = new Point[] { p1, p2, p3, p4 };

            int[,] matrixPoints = new int[points.Length, 3];
            for (int i = 0; i < matrixPoints.GetLength(0); i++)
            {
                for (int j = 0; j < matrixPoints.GetLength(1); j++)
                {
                    if ( j == 0 )
                        matrixPoints[i, j] = points[i].X;
                    else if (j == 1)
                        matrixPoints[i, j] = points[i].Y;
                    else matrixPoints[i, j] = 1;
                }
            }
            Matrix matrix = new Matrix();

            //matrixPoints = matrix.Irror_reflection(matrixPoints);
            matrixPoints = matrix.Translation(matrixPoints, x, y);
            //matrixPoints = matrix.Dilatation(matrixPoints, 2, 2);

            p1 = new Point(matrixPoints[0, 0], matrixPoints[0, 1]);
            p2 = new Point(matrixPoints[1, 0], matrixPoints[1, 1]);
            p3 = new Point(matrixPoints[2, 0], matrixPoints[2, 1]);
            p4 = new Point(matrixPoints[3, 0], matrixPoints[3, 1]);
            Point[] points2 = new Point[] { p1, p2, p3, p4 };

            Pen penGreen = new Pen(Color.Green, 1);
            g.DrawPolygon(penGreen, points2);
            g.DrawPolygon(penRed, points);
        }
    }
}
