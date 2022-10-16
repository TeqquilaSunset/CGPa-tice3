using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
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
        static float z = 2.0f;
        static float[,] matrixPoints =
        {
            {7    , 10, z, 1 },
            {-4   , 3, z, 1  },
            {-5.5f, -3, z, 1  },
            {-5.5f, -9, z, 1  },
            {7, 10, -z, 1 },
            {-4, 3, -z, 1  },
            {-5.5f, -3, -z, 1  },
            {-5.5f, -9, -z, 1  },
        };

        Matrix matrix = new Matrix();
        void Up()
        {
            X = pictureBox1.Width;
            Y = pictureBox1.Height;
        }
        public Form1()
        {
            InitializeComponent();
            Up();
        }
        
        private void DrawXY(object sender, EventArgs e)
        {
            Refresh();
            Graphics g = pictureBox1.CreateGraphics();
            Axes3D axes3D = new Axes3D(g,pictureBox1);
            axes3D.Draw(matrixPoints,g,pictureBox1);
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
            matrixPoints = matrix.Dilatation(matrixPoints, float.Parse(textBox4.Text),
                float.Parse(textBox3.Text), z);
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
        //поворот по х
        private void button4_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.RotationX(matrixPoints, float.Parse(textBox5.Text) * (float)Math.PI / 180);
        }
        //поворот по y
        private void button6_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.RotationY(matrixPoints, float.Parse(textBox5.Text) * (float)Math.PI / 180);
        }
        //поворот по z
        private void button7_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.RotationZ(matrixPoints, float.Parse(textBox5.Text) * (float)Math.PI / 180);
        }
    }
}
