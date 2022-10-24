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
        static float z = 4.0f;

        //static float[,] matrixPointsP =
        //{
        //    {7    , 10, 2, 1 },
        //    {-4   , 3, 2, 1  },
        //    {-5.5f, -3, 2, 1  },
        //    {-5.5f, -9, 2, 1  },

        //    {7, 10, -2, 1 },
        //    {-4, 3, -2, 1  },
        //    {-5.5f, -3, -2, 1  },
        //    {-5.5f, -9, -2, 1  },
        //};

        static float[,] matrixPointsP =
        {
            {0 , -4, 2, 1 },
            {0, 0, 2, 1  },
            {4, 0, 2, 1  },
            {4, -4, 2, 1  },

            {0, -4, -2, 1 },
            {0, 0, -2, 1  },
            {4, 0, -2, 1  },
            {4, -4, -2, 1  },
        };

        //laba
        static float[,] matrixPointsL =
        {
            {0, -8, 0, 1 },
            {-4, 0, z, 1  },
            {4, 0, z, 1  },
            {0, 8, 0, 1  },

            {0, -8, 0, 1 },
            {-4, 0, -z, 1  },
            {4, 0, -z, 1  },
            {0, 8, 0, 1  },
        };



        static float[,] matrixPoints = new float[8, 4];

        void UpdateRadioButton()
        {
            if (radioButton1.Checked)
                matrixPoints = matrixPointsP;
            else
                matrixPoints = matrixPointsL;
        }
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
            Axes3D axes3D = new Axes3D(g, pictureBox1);
            axes3D.Draw(matrixPoints, g, pictureBox1, radioButton1.Checked);
        }


        //сдвиг
        private void button1_Click(object sender, EventArgs e)
        {

            matrixPoints = matrix.Translation(matrixPoints, int.Parse(textBox1.Text), -int.Parse(textBox2.Text),
                int.Parse(textBox6.Text));
        }

        // масштабирование
        private void button2_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Dilatation(matrixPoints, float.Parse(textBox4.Text),
                float.Parse(textBox3.Text), float.Parse(textBox7.Text));
        }
        //отражение
        private void button3_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Irror_reflection(matrixPoints, -1, 1, 1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Irror_reflection(matrixPoints, 1, -1, 1);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Irror_reflection(matrixPoints, 1, 1, -1);
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
        //Проекция
        private void button9_Click(object sender, EventArgs e)
        {
            matrixPoints = matrix.Isometric(matrixPoints, 0.707f, 0.408f, 1f);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButton();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioButton();
        }
    }
}
