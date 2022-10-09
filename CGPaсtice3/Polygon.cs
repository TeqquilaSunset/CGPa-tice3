using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGPaсtice3
{
    internal class Polygon
    {
        Point[] points = new Point[4];
        public  Polygon(int x, int y)
        {
            points[0] = new Point(7 * x, y * 10);
            points[0] = new Point(-4 * x, y * 3);
            points[0] = new Point(Convert.ToInt32(-x * 5.5), -y * 3);
            points[0] = new Point(Convert.ToInt32(-x * 5.5), -y * 9);
        }
    }
}
