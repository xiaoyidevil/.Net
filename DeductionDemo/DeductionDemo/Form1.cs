using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeductionDemo
{
    public partial class Form1 : Form
    {
        public class DeductionPointDTO {
            public Point point;
            public double LenStart = 0;
            public double LenEnd = 0;
        }
        public enum Quadrant
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 3,
            Forth =4
        }

        Graphics g = null;
        Point beginP;
        Point endP;
        Point currentP;
        List<DeductionPointDTO> listP = new List<DeductionPointDTO>();
        double TotalLen = 0;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint
            | ControlStyles.ResizeRedraw
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.OptimizedDoubleBuffer
            | ControlStyles.UserMouse,
            true);
            this.UpdateStyles();
            g = this.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            #region 测试两个点坐标系变换
            //if (beginP == new Point())
            //{
            //    beginP = e.Location;
            //    txtBegin.Text = "X:" + beginP.X + ",Y:" + beginP.Y;
            //    Rectangle rectBegin = new Rectangle(beginP, new Size(8, 8));
            //    rectBegin.Offset(-4, -4);
            //    g.FillEllipse(new SolidBrush(Color.Yellow), rectBegin);
            //}
            //else if (endP == new Point())
            //{
            //    endP = e.Location;
            //    txtEnd.Text = "X:" + endP.X + ",Y:" + endP.Y;
            //    Rectangle rectEnd = new Rectangle(endP, new Size(8, 8));
            //    rectEnd.Offset(-4, -4);
            //    g.FillEllipse(new SolidBrush(Color.Green), rectEnd);
            //    g.DrawLine(new Pen(Color.Red), beginP, endP);
            //    txtQuadrant.Text = GetQuadrant(beginP, endP).ToString();
            //}
            #endregion

            if (listP.Count == 0)
            {
                DeductionPointDTO pt = new DeductionPointDTO();
                pt.point = e.Location;
                pt.LenStart = 0;
                pt.LenEnd = 0;
                listP.Add(pt);
            }
            else
            {
                DeductionPointDTO pt = new DeductionPointDTO();
                pt.point = e.Location;
                pt.LenStart = listP[listP.Count - 1].LenEnd;
                double lenX = Math.Abs(listP[listP.Count - 1].point.X - e.Location.X);
                double lenY = Math.Abs(listP[listP.Count - 1].point.Y - e.Location.Y);
                double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
                TotalLen = TotalLen + distance;
                pt.LenEnd = TotalLen;
                listP.Add(pt);
            }

            for (int i = 0; i < listP.Count; i++)
            {
                Rectangle rect = new Rectangle(listP[i].point, new Size(8, 8));
                rect.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rect);

                rect = new Rectangle(listP[i - 1 == -1 ? 0 : i - 1].point, new Size(8, 8));
                rect.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rect);

                g.DrawLine(new Pen(Color.Red), listP[i - 1 == -1 ? 0 : i - 1].point, listP[i].point);
            }
        }

        private Quadrant GetQuadrant(Point beginPoint, Point endPoint) {
            Quadrant quadrant = Quadrant.None;

            if (beginPoint.X < endPoint.X && beginPoint.Y >= endPoint.Y) {
                quadrant = Quadrant.First;
            }
            if (beginPoint.X <= endPoint.X && beginPoint.Y < endPoint.Y) {
                quadrant = Quadrant.Second;
            }
            if (beginPoint.X > endPoint.X && beginPoint.Y <= endPoint.Y) {
                quadrant = Quadrant.Third;
            }
            if (beginPoint.X >= endPoint.X && beginPoint.Y > endPoint.Y) {
                quadrant = Quadrant.Forth;
            }
            return quadrant;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(this.BackColor);
            listP.Clear();
            beginP = new Point();
            endP = new Point();
            txtBegin.Text = "";
            txtEnd.Text = "";
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            txtLocation.Text = "X:" + e.Location.X + ",Y:" + e.Location.Y;
        }

        private Point GetCurrentPoint(Point beginPoint, Point endPoint,int value)
        {
            Point point = new Point();

            Quadrant quadrant = GetQuadrant(beginPoint, endPoint);

            double lenX = Math.Abs(beginPoint.X - endPoint.X);
            double lenY = Math.Abs(beginPoint.Y - endPoint.Y);
            double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
            double currentDistance = distance / 100 * value;
            double angle = 0;
            int x = beginPoint.X;
            int y = beginPoint.Y;

            switch (quadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:
                    angle = Math.Atan(lenY / lenX);;
                    x = beginPoint.X + (int)(Math.Cos(angle) * currentDistance);
                    y = beginPoint.Y - (int)(Math.Sin(angle) * currentDistance);
                    point = new Point(x, y);
                    break;
                case Quadrant.Second:
                    angle = Math.Atan(lenY / lenX); ;
                    x = beginPoint.X + (int)(Math.Cos(angle) * currentDistance);
                    y = beginPoint.Y + (int)(Math.Sin(angle) * currentDistance);
                    point = new Point(x, y);
                    break;
                case Quadrant.Third:
                    angle = Math.Atan(lenY / lenX); ;
                    x = beginPoint.X - (int)(Math.Cos(angle) * currentDistance);
                    y = beginPoint.Y + (int)(Math.Sin(angle) * currentDistance);
                    point = new Point(x, y);
                    break;
                case Quadrant.Forth:
                    angle = Math.Atan(lenY / lenX); ;
                    x = beginPoint.X - (int)(Math.Cos(angle) * currentDistance);
                    y = beginPoint.Y - (int)(Math.Sin(angle) * currentDistance);
                    point = new Point(x, y);
                    break;
                default:
                    break;
            }

            return point;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            //g.Clear(this.BackColor);

            #region 测试两个点坐标系变换
            //Rectangle rectBegin = new Rectangle(beginP, new Size(8, 8));
            //rectBegin.Offset(-4, -4);
            //g.FillEllipse(new SolidBrush(Color.Green), rectBegin);

            //Rectangle rectEnd = new Rectangle(endP, new Size(8, 8));
            //rectEnd.Offset(-4, -4);
            //g.FillEllipse(new SolidBrush(Color.Green), rectEnd);
            //g.DrawLine(new Pen(Color.Red), beginP, endP);


            //currentP = GetCurrentPoint(beginP, endP, trackBar1.Value);
            //Rectangle rect = new Rectangle(currentP, new Size(8, 8));
            //rect.Offset(-4, -4);
            //g.FillEllipse(new SolidBrush(Color.Green), rect);
            #endregion

            for (int i = 0; i < listP.Count; i++)
            {
                Rectangle rect = new Rectangle(listP[i].point, new Size(8, 8));
                rect.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rect);

                rect = new Rectangle(listP[i - 1 == -1 ? 0 : i - 1].point, new Size(8, 8));
                rect.Offset(-4, -4);
                g.FillEllipse(new SolidBrush(Color.Green), rect);

                g.DrawLine(new Pen(Color.Red), listP[i - 1 == -1 ? 0 : i - 1].point, listP[i].point);
            }

            currentP = GetPointDTO(trackBar1.Value, trackBar1.Maximum);
            Rectangle rectCurrent = new Rectangle(currentP, new Size(8, 8));
            rectCurrent.Offset(-4, -4);
            g.FillEllipse(new SolidBrush(Color.Green), rectCurrent);
        }

        private Point GetPointDTO(int value,int MaxValue) {

            Point point = new Point();
            DeductionPointDTO beginPT = new DeductionPointDTO();
            DeductionPointDTO endPT = new DeductionPointDTO();
            int beginInt = 0;
            int CurrentPosition = 0;

            double currentDistance = TotalLen / MaxValue * value;
            endPT = listP.Find((DeductionPointDTO tempPt) => tempPt.LenStart <= currentDistance && tempPt.LenEnd >= currentDistance);
            if (endPT == null) {
                endPT = listP[listP.Count - 1];
            }
            beginInt = listP.FindIndex((DeductionPointDTO tempPt) => tempPt.LenStart <= currentDistance && tempPt.LenEnd >= currentDistance) - 1;
            
            if (beginInt <= 0)
            {
                beginPT = listP[0];
            }
            else {
                beginPT = listP[beginInt];
            }
            
            CurrentPosition = (int)((currentDistance - endPT.LenStart) / (endPT.LenEnd - endPT.LenStart) * 100);

            point = GetCurrentPoint(beginPT.point, endPT.point, CurrentPosition);

            return point;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(@"C:\Users\Administrator\Desktop\aa.gif");
            Guid[] guid = b.FrameDimensionsList;
            FrameDimension fd = new FrameDimension(guid[0]);

            int count = b.GetFrameCount(fd);

            for (int i = 0; i < count-1; i++)
            {
                b.SelectActiveFrame(fd, i);
                g.DrawImage(b, new Point(0, 0));
            }
        }
    }
}
