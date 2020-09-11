using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHanlder
{
    public partial class Form1 : Form
    {

        Point[] points = new Point[4];
        protected Pen RedPen_CustomEndCap = new Pen(Color.Red);
        
        PointF pStart = new Point(100,100);
        PointF pEnd = new Point(200,100);
        Graphics g = null;
        Pen p = new Pen(Color.Red);
        Brush b = new SolidBrush(Color.Green);
        Rectangle rectC = new Rectangle(200, 200, 8, 8);
        Rectangle rect = new Rectangle(200, 200, 200, 200);
        public Form1()
        {
            InitializeComponent();
            RedPen_CustomEndCap.CustomEndCap = new AdjustableArrowCap(4, 5, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point point = new Point(400, 100);
            rectC.Location = point;
            //this.Refresh();
            rectC.Offset(-4, -4);
            rect.Location = point;

            g.FillEllipse(b, rectC);
            g.DrawRectangle(p, rect);
            g.TranslateTransform(400, 100);
            g.RotateTransform(45);
            //g.DrawRectangle(p, rect);
            g.TranslateTransform(-400, -100);
            g.DrawRectangle(p, rect);
            g.ResetTransform();
            g.DrawRectangle(p, 400, 500,100,100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            //装入图片
            Bitmap image = new Bitmap("nemo.bmp");
            //获取当前窗口的中心点
            Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            PointF center = new PointF(rect.Width / 2, rect.Height / 2);
            float offsetX = 0;
            float offsetY = 0;
            offsetX = center.X - image.Width / 2;
            offsetY = center.Y - image.Height / 2;
            //构造图片显示区域:让图片的中心点与窗口的中心点一致
            RectangleF picRect = new RectangleF(offsetX, offsetY, image.Width, image.Height);
            PointF Pcenter = new PointF(picRect.X + picRect.Width / 2,
             picRect.Y + picRect.Height / 2);

            //让图片绕中心旋转一周
            for (int i = 0; i < 361; i += 10)
            {
                // 绘图平面以图片的中心点旋转
                g.TranslateTransform(Pcenter.X, Pcenter.Y);
                g.RotateTransform(i);
                //恢复绘图平面在水平和垂直方向的平移
                g.TranslateTransform(-Pcenter.X, -Pcenter.Y);
                //绘制图片并延时
                g.DrawImage(image, picRect);
                Thread.Sleep(100);
                //重置绘图平面的所有变换
                g.ResetTransform();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            g.DrawLine(RedPen_CustomEndCap, pStart, pEnd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PointF tempP = new Point();
            tempP = pEnd;
            double angle = 0;
            double length = Math.Pow(Math.Abs(pStart.X - pEnd.X), 2);
            length += Math.Pow(Math.Abs(pStart.Y - pEnd.Y), 2);
            length = Math.Sqrt(length);
            double x = 0;
            double y = 0;

            for (int i = 0; i < 45; i++)
            {
                //double.TryParse(i.ToString(), out angle);
                double.TryParse(textBox1.Text, out angle);
                angle += 90;
                x = length * Math.Sin(Math.PI * angle / 180);
                y = length * Math.Cos(Math.PI * angle / 180);
                
                tempP.X = pStart.X + (float)x;
                tempP.Y = pStart.Y - (float)y;
                g.DrawLine(RedPen_CustomEndCap, pStart, tempP);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Point _point = new Point(100, 100);
            double A = 90;

            Point point3 = new Point(
                           (int)(_point.X + (100) * Math.Cos((90 - A) * Math.PI / 180)),
                           (int)(_point.Y - (100) * Math.Sin((90 - A) * Math.PI / 180)));
            Rectangle rectY = new Rectangle(
                point3,
                new Size());
            rectY.Inflate(6, 6);
            g.DrawRectangle(p, rectY);

            Rectangle r = new Rectangle(_point, new Size());
            r.Inflate(4, 4);
            Brush b = new SolidBrush(Color.Green);
            g.FillEllipse(b, r);
            g.DrawLine(p, _point, point3);
            g.DrawLine(p, 100,100,100, 0);
            g.DrawEllipse(p, new Rectangle(0, 0, 200, 200));



            A = 45;
            // X轴
            point3 = new Point(
                 (int)(_point.X + (100) * Math.Cos(A * Math.PI / 180)),
                 (int)(_point.Y + (100) * Math.Sin(A * Math.PI / 180)));
            Rectangle rectX = new Rectangle(
                point3,
                new Size());
            rectX.Inflate(6, 6);
            g.DrawRectangle(p, rectX);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pen _penSelected = new Pen(Color.Red);
            Point _point = new Point(200, 200);

            Point _pointX1 = new Point(100, 200);
            Point _pointX2 = new Point(300, 200);

            Point _pointY1 = new Point(200, 100);
            Point _pointY2 = new Point(200, 300);

            g.DrawLine(_penSelected, _pointX1, _pointX2);
            g.DrawLine(_penSelected, _pointY1, _pointY2);

            int _lenX = 100;
            int _lenY = 100;
            int A = 45;
                      

            // 轴心
            points[0] = _point;

            // Y轴顶点
            points[1] = new Point(
                (int)(_point.X + (_lenX - 4) * Math.Cos((90 - A) * Math.PI / 180)),
                (int)(_point.Y - (_lenY - 4) * Math.Sin((90 - A) * Math.PI / 180)));

            // X轴顶点
            points[2] = new Point(
                 (int)(_point.X + (_lenX - 4) * Math.Cos(A * Math.PI / 180)),
                 (int)(_point.Y + (_lenY - 4) * Math.Sin(A * Math.PI / 180)));

            // N轴顶点
            points[3] = new Point(
                 (int)(_point.X + _lenX),
                 (int)(_point.Y - _lenY));

            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);

            g.DrawPath(_penSelected, path);

            RectangleF rect = path.GetBounds();
            rect.Inflate(6, 6);

            

            g.DrawRectangle(_penSelected, rect.Left, rect.Top, rect.Width, rect.Height);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox2.Text = e.X.ToString();
            textBox3.Text = e.Y.ToString();
        }
    }
}
