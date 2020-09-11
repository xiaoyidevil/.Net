using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHanlder
{
    enum Quadrant {
        None = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Forth = 4
    }
    public partial class imageAntimate : Form
    {
        Graphics g = null;
        Point beginP;
        Point endP;
        List<Point> listP = new List<Point>();       

        Quadrant currentQuadrant = Quadrant.None;
        public imageAntimate()
        {
            //beginP = new Point(100, 100);
            //endP = new Point(500, 100);
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
            beginP = new Point();
            endP = new Point();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
            Rectangle rectB = new Rectangle(beginP, new Size(8, 8));
            rectB.Offset(-4, -4);
            g.FillEllipse(new SolidBrush(Color.Green), rectB);

            Rectangle rectE = new Rectangle(endP, new Size(8, 8));
            rectE.Offset(-4, -4);
            g.FillEllipse(new SolidBrush(Color.Green), rectE);

            g.DrawLine(new Pen(Color.Red), beginP, endP);

            Point currentPoint = getCurrentPoint(beginP, endP, trackBar1.Value);

            Rectangle rectP = new Rectangle(currentPoint, new Size(8, 8));
            rectP.Offset(-4, -4);
            g.FillEllipse(new SolidBrush(Color.Green), rectP);

        }


        private Point getCurrentPoint(Point beginPoint, Point endPoint, int CurrentValue) {

            Point currentP = new Point();

            currentQuadrant = getLineQuadrant(beginPoint, endPoint);

            Rectangle rectP;

            int factX = 0;
            int factY = 0;
            int longX = Math.Abs(endPoint.X - beginPoint.X);
            int longY = Math.Abs(endPoint.Y - beginPoint.Y);

            double lineDistance = Math.Sqrt(Math.Pow(longX, 2) + Math.Pow(longY, 2));
            double Angel = Math.Atan((float)longY / (float)longX) * 180 / Math.PI;
            double currentDistance = lineDistance / 100 * CurrentValue;

            switch (currentQuadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:

                    factX = (int)(currentDistance * Math.Cos(Angel * Math.PI / 180));
                    factY = (int)(currentDistance * Math.Sin(Angel * Math.PI / 180));

                    currentP = new Point(beginPoint.X + factX, beginPoint.Y - factY);
                    textBox6.Text = currentP.X + "," + currentP.Y;
                    rectP = new Rectangle(currentP, new Size(8, 8));
                    rectP.Offset(-4, -4);
                    g.FillEllipse(new SolidBrush(Color.Green), rectP);

                    break;
                case Quadrant.Second:
                    factX = (int)(currentDistance * Math.Cos(Angel * Math.PI / 180));
                    factY = (int)(currentDistance * Math.Sin(Angel * Math.PI / 180));

                    currentP = new Point(beginPoint.X + factX, beginPoint.Y + factY);
                    textBox6.Text = currentP.X + "," + currentP.Y;
                    rectP = new Rectangle(currentP, new Size(8, 8));
                    rectP.Offset(-4, -4);
                    g.FillEllipse(new SolidBrush(Color.Green), rectP);

                    break;
                case Quadrant.Third:
                    factX = (int)(currentDistance * Math.Cos(Angel * Math.PI / 180));
                    factY = (int)(currentDistance * Math.Sin(Angel * Math.PI / 180));

                    currentP = new Point(beginPoint.X - factX, beginPoint.Y + factY);
                    textBox6.Text = currentP.X + "," + currentP.Y;
                    rectP = new Rectangle(currentP, new Size(8, 8));
                    rectP.Offset(-4, -4);
                    g.FillEllipse(new SolidBrush(Color.Green), rectP);

                    break;
                case Quadrant.Forth:
                    factX = (int)(currentDistance * Math.Cos(Angel * Math.PI / 180));
                    factY = (int)(currentDistance * Math.Sin(Angel * Math.PI / 180));

                    currentP = new Point(beginPoint.X - factX, beginPoint.Y - factY);
                    textBox6.Text = currentP.X + "," + currentP.Y;
                    rectP = new Rectangle(currentP, new Size(8, 8));
                    rectP.Offset(-4, -4);
                    g.FillEllipse(new SolidBrush(Color.Green), rectP);
                    break;
                default:
                    break;
            }

            return currentP;
        }

        private void imageAntimate_MouseUp(object sender, MouseEventArgs e)
        {

            if (beginP == new Point())
            {
                beginP = e.Location;
                Rectangle rectB = new Rectangle(beginP, new Size(8, 8));
                rectB.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rectB);
                textBox1.Text = beginP.X + "," + beginP.Y;
            }
            else if (endP == new Point())
            {
                endP = e.Location;
                Rectangle rectE = new Rectangle(endP, new Size(8, 8));
                rectE.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rectE);

                textBox2.Text = endP.X + "," + endP.Y;

                g.DrawLine(new Pen(Color.Red), beginP, endP);

                currentQuadrant = getLineQuadrant(beginP, endP);

                textBox5.Text = currentQuadrant.ToString();
            }

            //for (int i = 0; i < listP.Count; i++)
            //{
            //    Rectangle rect = new Rectangle(listP[i], new Size(8, 8));
            //    rect.Offset(-4, -4);
            //    g.FillEllipse(new SolidBrush(Color.Green), rect);
            //    if (i > 0) {
            //        g.DrawLine(new Pen(Color.Red), listP[i - 1], listP[i]);
            //    }
            //}

            ArrayList attachment = new ArrayList();
            attachment.Add(beginP);
            Point[] al = (Point[])attachment.ToArray(typeof(Point));
            List<Point> ls = new List<Point>(al);
        }


        private Quadrant getLineQuadrant(Point beginp, Point endp) {

            Quadrant tempQuadrant = Quadrant.None;
            if (beginp.X < endp.X && beginp.Y >= endp.Y)
            {
                tempQuadrant = Quadrant.First;
                
            }

            if (beginp.X <= endp.X && beginp.Y < endp.Y)
            {
                tempQuadrant = Quadrant.Second;
            }

            if (beginp.X > endp.X && beginp.Y <= endp.Y)
            {
                tempQuadrant = Quadrant.Third;
            }

            if (beginp.X >= endp.X && beginp.Y > endp.Y)
            {
                tempQuadrant = Quadrant.Forth;
            }

            return tempQuadrant;
        }
        private void imageAntimate_MouseMove(object sender, MouseEventArgs e)
        {
            textBox3.Text = e.Location.X.ToString();
            textBox4.Text = e.Location.Y.ToString();
        }
    }
}
