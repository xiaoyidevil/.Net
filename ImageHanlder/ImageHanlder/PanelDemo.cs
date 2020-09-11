using System;
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
    public partial class PanelDemo : Form
    {
        public Graphics graphics = null;
        public Point pCenter = new Point();
        public PanelDemo()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
        }

        private void DrawPoint(List<Point> listP) {

            if (listP.Count > 1) {
                Rectangle rect = new Rectangle(listP[0], new Size(8, 8));
                rect.Offset(-4, -4);
                graphics.FillEllipse(new SolidBrush(Color.Red), rect);

                for (int i = 1; i < listP.Count; i++)
                {
                    graphics.DrawLine(new Pen(Color.Green), listP[i - 1], listP[i]);
                }
            }
        }

        private void btnDrawBow_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
            //drawExtend(graphics);
            //DrawBowPoint_RightBottom(graphics);
            //DrawBowPoint_RightTop(graphics);
            //DrawBowPoint_LeftBottom(graphics);
            //DrawBowPoint_LeftTop(graphics);
            int intTemp = 0;
            int intAngle = 0;
            int.TryParse(txtNum.Text, out intTemp);


            //List<Point> listP = GetBowPoint_RightTop(intTemp, pCenter, 50, 50);
            //List<Point> listP = GetBowPoint_RightBottom(intTemp, pCenter, 50, 50);


            List<Point> listP = GetBowPoint_RightBottom(intTemp, pCenter, 50, 50,0);
            DrawPoint(listP);
            
            int.TryParse(txtAngle.Text, out intAngle);

            listP = GetBowPoint_RightBottom(intTemp, pCenter, 50, 50, intAngle);
            DrawPoint(listP);
        }




        /// <summary>
        /// 右上角方向弓形
        /// </summary>
        /// <param name="e"></param>
        public List<Point> GetBowPoint_RightTop(int PointCount,Point pCenter,int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            {
                listP.Add(pCenter);
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i < PointCount; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * 2 * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 2:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }

            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_RightTop(listP[0], listP[i], Angle);
                }
            }

            return listP;
        }

        /// <summary>
        /// 右下角方向弓形
        /// </summary>
        /// <param name="e"></param>
        public List<Point> GetBowPoint_RightBottom(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            {
                listP.Add(pCenter);
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i < PointCount; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * 2 * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 2:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_RightBottom(listP[0], listP[i], Angle);
                }
            }
            return listP;
        }

        /// <summary>
        /// 左下角方向弓形
        /// </summary>
        /// <param name="e"></param>
        public List<Point> GetBowPoint_LeftBottom(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            {
                listP.Add(pCenter);
                Point pTemp = new Point();
                Point pStart = pCenter;
                
                for (int i = 1; i < PointCount; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * 2 * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 2:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_LeftBottom(listP[0], listP[i], Angle);
                }
            }
            return listP;
        }

        /// <summary>
        /// 左上角方向弓形
        /// </summary>
        /// <param name="e"></param>
        public List<Point> GetBowPoint_LeftTop(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            {
                listP.Add(pCenter);
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i < PointCount; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * 2 * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 2:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }
                }
            }

            if (Angle != 0) {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_LeftTop(listP[i], listP[0], Angle);
                }
            }
            return listP;
        }

        public Point CalcCurrentAngle_LeftTop(Point beginPoint, Point endPoint, double RotateAngle) {
            Point points = new Point();

            double lenX = Math.Abs(beginPoint.X - endPoint.X);
            double lenY = Math.Abs(beginPoint.Y - endPoint.Y);
            double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
            double angle = Math.Atan(lenY / lenX) * 180 / Math.PI;

            Quadrant quadrant = GetQuadrant(beginPoint, endPoint);

            switch (quadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:
                    points = new Point(
                    (int)(endPoint.X + (distance) * Math.Cos((180 - (angle + RotateAngle)) * Math.PI / 180)),
                    (int)(endPoint.Y - (distance) * Math.Sin((180 - (angle + RotateAngle)) * Math.PI / 180)));
                    break;
                case Quadrant.Second:
                    points = new Point(
                    (int)(endPoint.X + (distance) * Math.Cos((180 - (angle + RotateAngle)) * Math.PI / 180)),
                    (int)(endPoint.Y - (distance) * Math.Sin((180 - (angle + RotateAngle)) * Math.PI / 180)));
                    break;
                case Quadrant.Third:
                    points = new Point(
                    (int)(endPoint.X + (distance) * Math.Cos((180 - (angle + RotateAngle)) * Math.PI / 180)),
                    (int)(endPoint.Y - (distance) * Math.Sin((180 - (angle + RotateAngle)) * Math.PI / 180)));
                    break;
                case Quadrant.Forth:
                    points = new Point(
                   (int)(endPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle)) * Math.PI / 180)),
                   (int)(endPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle)) * Math.PI / 180)));
                    break;
                default:
                    break;
            }
            return points;
        }
        public Point CalcCurrentAngle_RightTop(Point beginPoint, Point endPoint, double RotateAngle)
        {
            Point points = new Point();

            double lenX = Math.Abs(beginPoint.X - endPoint.X);
            double lenY = Math.Abs(beginPoint.Y - endPoint.Y);
            double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
            double angle = Math.Atan(lenX / lenY) * 180 / Math.PI;

            Quadrant quadrant = GetQuadrant(beginPoint, endPoint);

            switch (quadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:
                    if (angle == 0)
                    {
                        points = new Point(
                        (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle + 90)) * Math.PI / 180)),
                        (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle + 90)) * Math.PI / 180)));
                    }
                    else {
                        points = new Point(
                       (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle)) * Math.PI / 180)),
                       (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle)) * Math.PI / 180)));
                    }
                    break;
                case Quadrant.Second:
                    break;
                case Quadrant.Third:
                    break;
                case Quadrant.Forth:
                    points = new Point(
                    (int)(beginPoint.X + (distance) * Math.Cos((90 - (RotateAngle)) * Math.PI / 180)),
                    (int)(beginPoint.Y - (distance) * Math.Sin((90 - (RotateAngle)) * Math.PI / 180)));
                    break;
                default:
                    break;
            }
            return points;
        }

        public Point CalcCurrentAngle_RightBottom(Point beginPoint, Point endPoint, double RotateAngle)
        {
            Point points = new Point();

            double lenX = Math.Abs(beginPoint.X - endPoint.X);
            double lenY = Math.Abs(beginPoint.Y - endPoint.Y);
            double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
            double angle = Math.Atan(lenY / lenX) * 180 / Math.PI;

            Quadrant quadrant = GetQuadrant(beginPoint, endPoint);

            switch (quadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:
                    if (angle == 0)
                    {
                        points = new Point(
                        (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle + 90)) * Math.PI / 180)),
                        (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle + 90)) * Math.PI / 180)));
                    }
                    else
                    {
                        points = new Point(
                       (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle)) * Math.PI / 180)),
                       (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle)) * Math.PI / 180)));
                    }
                    break;
                case Quadrant.Second:
                    points = new Point(
                    (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle + 90)) * Math.PI / 180)),
                    (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle + 90)) * Math.PI / 180)));
                    break;
                case Quadrant.Third:
                    break;
                case Quadrant.Forth:
                    break;
                default:
                    break;
            }
            return points;
        }

        public Point CalcCurrentAngle_LeftBottom(Point beginPoint, Point endPoint, double RotateAngle)
        {
            Point points = new Point();

            double lenX = Math.Abs(beginPoint.X - endPoint.X);
            double lenY = Math.Abs(beginPoint.Y - endPoint.Y);
            double distance = Math.Sqrt(Math.Pow(lenX, 2) + Math.Pow(lenY, 2));
            double angle = Math.Atan(lenX / lenY) * 180 / Math.PI;

            Quadrant quadrant = GetQuadrant(beginPoint, endPoint);

            switch (quadrant)
            {
                case Quadrant.None:
                    break;
                case Quadrant.First:
                    break;
                case Quadrant.Second:
                    points = new Point(
                    (int)(beginPoint.X + (distance) * Math.Cos((90 - (RotateAngle + 180)) * Math.PI / 180)),
                    (int)(beginPoint.Y - (distance) * Math.Sin((90 - (RotateAngle + 180)) * Math.PI / 180)));
                    break;
                case Quadrant.Third:

                    if (angle == 0)
                    {
                        points = new Point(
                        (int)(beginPoint.X + (distance) * Math.Cos((90 - (RotateAngle + 270)) * Math.PI / 180)),
                        (int)(beginPoint.Y - (distance) * Math.Sin((90 - (RotateAngle + 270)) * Math.PI / 180)));
                    }
                    else
                    {
                        points = new Point(
                        (int)(beginPoint.X + (distance) * Math.Cos((90 - (angle + RotateAngle + 180)) * Math.PI / 180)),
                        (int)(beginPoint.Y - (distance) * Math.Sin((90 - (angle + RotateAngle + 180)) * Math.PI / 180)));
                    }
                    break;
                case Quadrant.Forth:
                    break;
                default:
                    break;
            }
            return points;
        }

        #region 象限计算
        private Quadrant GetQuadrant(Point beginPoint, Point endPoint)
        {
            Quadrant quadrant = Quadrant.None;

            if (beginPoint.X < endPoint.X && beginPoint.Y >= endPoint.Y)
            {
                quadrant = Quadrant.First;
            }
            if (beginPoint.X <= endPoint.X && beginPoint.Y < endPoint.Y)
            {
                quadrant = Quadrant.Second;
            }
            if (beginPoint.X > endPoint.X && beginPoint.Y <= endPoint.Y)
            {
                quadrant = Quadrant.Third;
            }
            if (beginPoint.X >= endPoint.X && beginPoint.Y > endPoint.Y)
            {
                quadrant = Quadrant.Forth;
            }
            return quadrant;
        }

        #endregion

        private void PanelDemo_MouseUp(object sender, MouseEventArgs e)
        {
            pCenter = e.Location;
        }


        /// <summary>
        /// 右下角方向弓形
        /// </summary>
        /// <param name="e"></param>
        private void DrawBowPoint_RightBottom(Graphics e)
        {

            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 100);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * 2 * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 2:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        /// <summary>
        /// 左下角方向弓形
        /// </summary>
        /// <param name="e"></param>
        private void DrawBowPoint_LeftBottom(Graphics e)
        {

            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 100);
                Size s = new Size(8, 8);
                Rectangle rect = new Rectangle(pCenter, s);
                rect.Offset(-4, -4);
                graphics.FillEllipse(new SolidBrush(Color.Green), rect);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * 2 * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 2:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1) * 2) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        /// <summary>
        /// 右上角方向弓形
        /// </summary>
        /// <param name="e"></param>
        private void DrawBowPoint_RightTop(Graphics e)
        {

            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 300);
                Size s = new Size(8, 8);
                Rectangle rect = new Rectangle(pCenter, s);
                rect.Offset(-4, -4);
                graphics.FillEllipse(new SolidBrush(Color.Green), rect);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * 2 * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 2:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }


        /// <summary>
        /// 左上角方向弓形
        /// </summary>
        /// <param name="e"></param>
        private void DrawBowPoint_LeftTop(Graphics e)
        {

            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 300);
                Size s = new Size(8, 8);
                Rectangle rect = new Rectangle(pCenter, s);
                rect.Offset(-4, -4);
                graphics.FillEllipse(new SolidBrush(Color.Green), rect);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 4 + 1;
                    switch (i % 4)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * 2 * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 2:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 3:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2 + 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1) * 2) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void btnZType_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

            int intTemp = 0;
            int intAngle = 0;
            int.TryParse(txtNum.Text, out intTemp);
            int.TryParse(txtAngle.Text, out intAngle);

            List<Point> listP = GetZTypePoint_RightBottom(intTemp, pCenter, 50, 50, 0);
            DrawPoint(listP);

            listP = GetZTypePoint_RightBottom(intTemp, pCenter, 50, 50, intAngle);
            DrawPoint(listP);

        }

        private void DrawZTypePoint_RightBottom(Graphics e)
        {
            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 200);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;
                g.Clear(this.BackColor);
                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1)) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void DrawZTypePoint_RightTop(Graphics e)
        {
            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 200);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;
                g.Clear(this.BackColor);
                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1)) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void DrawZTypePoint_LeftTop(Graphics e)
        {
            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 200);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;
                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1)) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void DrawZTypePoint_LeftBottom(Graphics e)
        {
            {
                int intTemp = 0;
                int.TryParse(txtNum.Text, out intTemp);
                int PointCount = intTemp;
                Point pCenter = new Point(200, 200);
                Point pTemp = new Point();
                int Wdistance = 50;
                int Hdistance = 50;
                Point pStart = pCenter;

                Pen p = new Pen(Color.Blue, 1);
                Graphics g = e;
                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1)) * Hdistance;
                            g.DrawLine(p, pStart, pTemp);
                            pStart = pTemp;
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        private void DrawZType_RT_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

            int intTemp = 0;
            int intAngle = 0;
            int.TryParse(txtNum.Text, out intTemp);
            int.TryParse(txtAngle.Text, out intAngle);

            List<Point> listP = GetZTypePoint_RightTop(intTemp, pCenter, 50, 50, 0);
            DrawPoint(listP);

            listP = GetZTypePoint_RightTop(intTemp, pCenter, 50, 50, intAngle);
            DrawPoint(listP);
        }

        private void btnDrawZType_LT_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

            int intTemp = 0;
            int intAngle = 0;
            int.TryParse(txtNum.Text, out intTemp);
            int.TryParse(txtAngle.Text, out intAngle);

            List<Point> listP = GetZTypePoint_LeftTop(intTemp, pCenter, 50, 50, 0);
            DrawPoint(listP);
            listP = GetZTypePoint_LeftTop(intTemp, pCenter, 50, 50, intAngle);
            DrawPoint(listP);
        }

        private void btnDrawZType_LB_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);

            int intTemp = 0;
            int intAngle = 0;
            int.TryParse(txtNum.Text, out intTemp);
            int.TryParse(txtAngle.Text, out intAngle);

            List<Point> listP = GetZTypePoint_LeftBottom(intTemp, pCenter, 50, 50, 0);
            DrawPoint(listP);
            listP = GetZTypePoint_LeftBottom(intTemp, pCenter, 50, 50, intAngle);
            DrawPoint(listP);
        }

        private List<Point> GetZTypePoint_RightBottom(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            listP.Add(pCenter);
            {
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i <= PointCount-1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1)) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_RightBottom(listP[0], listP[i], Angle);
                }
            }
            return listP;
        }

        private List<Point> GetZTypePoint_RightTop(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            listP.Add(pCenter);
            {
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X + Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1)) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_RightTop(listP[0], listP[i], Angle);
                }
            }
            return listP;
        }

        private List<Point> GetZTypePoint_LeftTop(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            listP.Add(pCenter);
            {
                Point pTemp = new Point();
                Point pStart = pCenter;
                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y - (factor - 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y - ((factor - 1)) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_LeftTop(listP[i], listP[0], Angle);
                }
            }
            return listP;
        }

        private List<Point> GetZTypePoint_LeftBottom(int PointCount, Point pCenter, int Wdistance, int Hdistance, int Angle)
        {
            List<Point> listP = new List<Point>();
            listP.Add(pCenter);
            {
                Point pTemp = new Point();
                Point pStart = pCenter;

                for (int i = 1; i <= PointCount - 1; i++)
                {
                    int factor = (i) / 2 + 1;
                    switch (i % 2)
                    {
                        case 1:
                            pTemp.X = pCenter.X - Wdistance;
                            pTemp.Y = pCenter.Y + (factor - 1) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        case 0:
                            pTemp.X = pCenter.X;
                            pTemp.Y = pCenter.Y + ((factor - 1)) * Hdistance;
                            listP.Add(pTemp);
                            break;
                        default:
                            break;
                    }

                }
            }
            if (Angle != 0)
            {
                for (int i = 1; i < listP.Count; i++)
                {
                    listP[i] = CalcCurrentAngle_LeftBottom(listP[0], listP[i], Angle);
                }
            }
            return listP;
        }
    }
}
