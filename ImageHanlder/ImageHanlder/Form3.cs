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

namespace ImageHanlder
{
    public partial class Form3 : Form
    {
        private int i = 1;
        Graphics g = null;
        Pen p = new Pen(Color.Red);
        public Form3()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
            g.DrawRectangle(new Pen(Color.Red), 200, 200, 150, 100);

            int A = Convert.ToInt16(textBox1.Text);

            double rlen = Math.Sqrt(Math.Pow(150, 2) + Math.Pow(100, 2));

            Point _point = new Point(200, 300);
            Point[] points = new Point[4];

            // 轴心
            points[0] = _point;
            // Y轴顶点
            points[1] = new Point(
                (int)(_point.X + (100) * Math.Cos((90 - A) * Math.PI / 180)),
                (int)(_point.Y - (100) * Math.Sin((90 - A) * Math.PI / 180)));

            // X轴顶点
            points[3] = new Point(
                 (int)(_point.X + (150) * Math.Cos(A * Math.PI / 180)),
                 (int)(_point.Y + (150) * Math.Sin(A * Math.PI / 180)));

            // 对边顶点
            double xa = Math.Atan(150f / 100f) * 180 / Math.PI;

            points[2] = new Point(
                (int)(_point.X + (rlen) * Math.Cos((90 - (A + xa)) * Math.PI / 180)),
                (int)(_point.Y - (rlen) * Math.Sin((90 - (A + xa)) * Math.PI / 180)));
            
            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(points);

            g.DrawPath(new Pen(Color.Blue), gp);


            //Rectangle ra = new Rectangle(points[0], new Size(4, 4));
            //ra.Offset(-2, -2);
            //g.DrawEllipse(new Pen(Color.Green), ra);

            //ra = new Rectangle(points[1], new Size(4, 4));
            //ra.Offset(-2, -2);
            //g.DrawEllipse(new Pen(Color.Green), ra);

            //ra = new Rectangle(points[2], new Size(4, 4));
            //ra.Offset(-2, -2);
            //g.DrawEllipse(new Pen(Color.Green), ra);

            //ra = new Rectangle(points[3], new Size(4, 4));
            //ra.Offset(-2, -2);
            //g.DrawEllipse(new Pen(Color.Green), ra);

            //g.DrawLine(new Pen(Color.Green), points[0], points[1]);
            //g.DrawLine(new Pen(Color.Green), points[1], points[3]);
            //g.DrawLine(new Pen(Color.Green), points[3], points[2]);
            //g.DrawLine(new Pen(Color.Green), points[2], points[0]);


        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int x = (int)((trackBar1.Value / 100f) * 255);
            System.Drawing.Color Mycolor = System.Drawing.Color.FromArgb(x, Color.Yellow);//说明：1-（128/255）=1-0.5=0.5 透明度为0.5，即bai50%
            System.Drawing.SolidBrush sb1 = new System.Drawing.SolidBrush(Mycolor);
            g.FillRectangle(Brushes.Tomato, 0, 50, 250, 50); //给窗体填上颜色以增强比较效果
            g.FillEllipse(sb1, 20, 20, 100, 100); //半透明效果
            g.FillEllipse(Brushes.Yellow, 120, 20, 100, 100); //实色效果
            sb1.Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            //g.DrawRectangle(new Pen(Color.Red), 200, 200, 150, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float x = 0;
            float.TryParse(textBox2.Text, out x);
            MessageBox.Show(x.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point p = new Point(200, 200);
            Pen pen = new Pen(Color.Red);
            Size s = new Size(150, 100);
            Rectangle rect = new Rectangle(p, s);

            g.DrawRectangle(pen, rect);
            g.TranslateTransform(p.X, p.Y);
            g.RotateTransform(45);
            
            g.DrawLine(pen, 0, 0, 0, -80);

            g.RotateTransform(-45);
            g.TranslateTransform(-p.X, -p.Y);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point p = new Point(200, 200);
            Rectangle rect = new Rectangle(p,new Size(100,100));
            GraphicsPath gp = new GraphicsPath();
            gp.AddPie(rect,-90, 180);
            //g.DrawRectangle(new Pen(Color.Red), rect);
            g.DrawPath(new Pen(Color.Blue), gp);
            float x = gp.PathPoints.Min((PointF pf) => pf.X);
            float y = gp.PathPoints.Min((PointF pf) => pf.Y);

            float xMax = gp.PathPoints.Max((PointF pf) => pf.X);
            float yMax = gp.PathPoints.Max((PointF pf) => pf.Y);

            Rectangle newRect = new Rectangle(new Point((int)x, (int)y), new Size((int)(xMax - x), (int)(yMax - y)));
            newRect.Inflate(3, 3);
            g.DrawRectangle(new Pen(Color.Green), newRect);
        }
    }
}
