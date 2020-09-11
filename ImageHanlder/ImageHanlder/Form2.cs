using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHanlder
{
    public partial class Form2 : Form
    {
        Point _point = new Point(100, 100);
        Graphics g = null;
        public Form2()
        {
            InitializeComponent();
            g = this.CreateGraphics();

            DoubleBuffered = true;
        }

        protected double GetOffsetAngle(Point ptFrom, Point ptTo)
        {
            double offsetAngle = 0;

            // 竖上为0度
            Point p = new Point(ptTo.X - ptFrom.X, ptTo.Y - ptFrom.Y);

            // 变化角度(度)
            offsetAngle = Math.Atan2(Math.Abs(p.Y), Math.Abs(p.X)) * 180.0 / Math.PI;

            if (p.X >= 0)
            {
                if (p.Y >= 0) offsetAngle = 90 + offsetAngle;
                else offsetAngle = 90 - offsetAngle;
            }
            else
            {
                if (p.Y >= 0) offsetAngle = -90 - offsetAngle;
                else offsetAngle = -90 + offsetAngle;
            }

            return offsetAngle;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            //Point pBase = new Point(200, 200);
            //Point pBaseTo = new Point(400, 200);
            //this.Refresh();
            //g.DrawLine(new Pen(Color.Red), pBase, pBaseTo);
            //g.DrawEllipse(new Pen(Color.Red), 0, 0, 400, 400);
            //Point pFrom = new Point(200, 200);
            //Point pTo = e.Location;
            //double A = 0;
            //A = GetOffsetAngle(pFrom, pTo);
            //textBox1.Text = A.ToString();
            //g.DrawLine(new Pen(Color.Green), pFrom, e.Location);

            textBox3.Text = e.Location.X.ToString();
            textBox4.Text = e.Location.Y.ToString();

            float width = 200f;
            float height = 100f;

            DrawRuway(g,width, height);
        }

        private Point getRotatePoint(Point _point, int _maxRadius, float A) {
            Point point3 = new Point(
            (int)(_point.X + (_maxRadius - 4) * Math.Cos((90 - A) * Math.PI / 180)),
            (int)(_point.Y - (_maxRadius - 4) * Math.Sin((90 - A) * Math.PI / 180)));
            return point3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point pBase = new Point(200, 200);
            Point pEnd = getRotatePoint(pBase, 200, 45);
            g.DrawLine(new Pen(Color.Blue), pBase, pEnd);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int A = 0;
            int.TryParse(textBox2.Text, out A);
            Point pBase = new Point(200, 200);
            Point pEnd = getRotatePoint(pBase, 200, A);
            g.DrawLine(new Pen(Color.Blue), pBase, pEnd);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point pt1 = new Point(100, 100);
            Point pt2 = new Point(100, 200);
            Point pt3 = new Point(200, 200);
            Point pt4 = new Point(100, 100);
            g.DrawBezier(new Pen(Color.Red), pt1, pt2, pt3, pt4);
            g.DrawLine(new Pen(Color.Red), pt1, pt2);
            g.DrawLine(new Pen(Color.Red), pt2, pt3);
            g.DrawLine(new Pen(Color.Red), pt3, pt4);
            g.DrawLine(new Pen(Color.Red), pt4, pt1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float width = 200f;
            float height = 300f;

            DrawRuway(g,width, height);

            //MessageBox.Show(Math.Tan(45 * Math.PI / 180).ToString());
            MessageBox.Show((Math.Atan(height/width) * 180 / Math.PI).ToString());
        }

        private void DrawRuwayNew(double width, double height) {

            float Angle = (float)(Math.Atan(height / width) * 180 / Math.PI); 
            float SwapAnagle = Angle * 2;
            PointF _point = new PointF(100, 100);
            double radius = Math.Sqrt(Math.Pow(width / 2,2) + Math.Pow(height / 2,2));

            PointF pointBase = new PointF(_point.X - (float)(radius - width / 2), _point.Y - (float)(radius - height / 2));

            Rectangle rect = new Rectangle((int)pointBase.X, (int)pointBase.Y, (int)radius * 2, (int)radius * 2);
            //g.DrawArc(new Pen(Color.Red), rect, 0, 360);
            g.DrawArc(new Pen(Color.Red), rect, -Angle, SwapAnagle);
            g.DrawArc(new Pen(Color.Red), rect, 180 - Angle, SwapAnagle);
            g.DrawRectangle(new Pen(Color.Red), rect);

            PointF p1 = new PointF(
                pointBase.X + (float)(radius - (radius * Math.Cos(Angle * Math.PI / 180))),
                pointBase.Y + (float)(radius - (radius * Math.Sin(Angle * Math.PI / 180)))
                );

            PointF p2 = new PointF(
                pointBase.X + (float)(radius + width / 2),
                pointBase.Y + (float)(radius - height / 2)
                );

            PointF p3 = new PointF(
                pointBase.X + (float)(radius - (radius * Math.Cos(Angle * Math.PI / 180))),
                pointBase.Y + (float)(radius + (radius * Math.Sin(Angle * Math.PI / 180)))
                );

            PointF p4 = new PointF(
                pointBase.X + (float)(radius + (radius * Math.Cos(Angle * Math.PI / 180))),
                pointBase.Y + (float)(radius + (radius * Math.Sin(Angle * Math.PI / 180)))
                );

            g.DrawLine(new Pen(Color.Red), p1, p2);
            g.DrawLine(new Pen(Color.Red), p3, p4);

        }

        private void DrawRuway(Graphics g, double width, double height)
        {

            float Angle = (float)(Math.Atan(height / width) * 180 / Math.PI);
            float SwapAnagle = Angle * 2;
            double radius = Math.Sqrt(Math.Pow(width / 2, 2) + Math.Pow(height / 2, 2));

            PointF pointBase = new PointF(_point.X + (float)(radius - width / 2), _point.Y + (float)(radius - height / 2));

            Rectangle rect = new Rectangle((int)_point.X, (int)_point.Y, (int)radius * 2, (int)radius * 2);
            //g.DrawArc(new Pen(Color.Red), rect, 0, 360);
            g.DrawArc(new Pen(Color.Red), rect, -Angle, SwapAnagle);
            g.DrawArc(new Pen(Color.Red), rect, 180 - Angle, SwapAnagle);
            g.DrawRectangle(new Pen(Color.Red), rect);

            PointF p1 = pointBase;

            PointF p2 = new PointF(
                pointBase.X + (float)(width),
                pointBase.Y
                );

            PointF p3 = new PointF(
                pointBase.X,
                pointBase.Y + (float)(height)
                );

            PointF p4 = new PointF(
                pointBase.X + (float)width,
                pointBase.Y + (float)height
                );

            g.DrawLine(new Pen(Color.Red), p1, p2);
            g.DrawLine(new Pen(Color.Red), p3, p4);

        }

    }
}
