using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SierpinskiTriangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gr = panel1.CreateGraphics();
            gr.Clear(Color.White);
            var level = Convert.ToInt32(numericUpDown1.Value);
            // 747 x 557
            var topPoint = new PointF(350, 0);
            var leftPoint = new PointF(0, 500);
            var rightPoint = new PointF(700, 500);
            DrawTriangle(gr, level, topPoint, leftPoint, rightPoint);

        }

        // Draw a triangle between the points.
        private void DrawTriangle(Graphics gr, int level,
            PointF top_point, PointF left_point, PointF right_point)
        {
            // See if we should stop.
            if (level == 0)
            {
                // Fill the triangle.
                PointF[] points =
                {
            top_point, right_point, left_point
        };
                gr.FillPolygon(Brushes.Red, points);
            }
            else
            {
                // Find the edge midpoints.
                PointF left_mid = new PointF(
                    (top_point.X + left_point.X) / 2f,
                    (top_point.Y + left_point.Y) / 2f);
                PointF right_mid = new PointF(
                    (top_point.X + right_point.X) / 2f,
                    (top_point.Y + right_point.Y) / 2f);
                PointF bottom_mid = new PointF(
                    (left_point.X + right_point.X) / 2f,
                    (left_point.Y + right_point.Y) / 2f);

                // Recursively draw smaller triangles.
                DrawTriangle(gr, level - 1,
                    top_point, left_mid, right_mid);
                DrawTriangle(gr, level - 1,
                    left_mid, left_point, bottom_mid);
                DrawTriangle(gr, level - 1,
                    right_mid, bottom_mid, right_point);
            }
        }
    }
}
