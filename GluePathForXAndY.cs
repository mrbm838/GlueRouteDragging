using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace GlueReadWrite
{
    public static class GluePathForXAndY
    {

        public static bool IsNumberic(object obj)
        {
            bool isNum;
            if (obj != null)
            {
                isNum = double.TryParse(obj.ToString(), System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo, out _);
            }
            else
            {
                isNum = false;
            }
            return isNum;
        }

        /// <summary>
        /// 根据三点画圆弧
        /// </summary>
        /// <param name="dX1">第一个点的X坐标</param>
        /// <param name="dY1">第一个点的Y坐标</param>
        /// <param name="dX2">第二个点的X坐标</param>
        /// <param name="dY2">第二个点的Y坐标</param>
        /// <param name="dX3">第三个点的X坐标</param>
        /// <param name="dY3">第三个点的Y坐标</param>
        public static float[] DrawArc(double dX1, double dY1, double dX2, double dY2, double dX3, double dY3)
        {
            float[] fTemp = GetCircle(dX1, dY1, dX2, dY2, dX3, dY3);
            double dK1 = ReturnCircleK((float)dX1, (float)dY1, fTemp[0], fTemp[1]);
            double dK2 = ReturnCircleK((float)dX2, (float)dY2, fTemp[0], fTemp[1]);
            double dK3 = ReturnCircleK((float)dX3, (float)dY3, fTemp[0], fTemp[1]);

            float startAngle, sweepAngle;
            if ((dK1 < dK2 && dK3 > dK2) || (dK1 > dK2 && dK3 < dK2))//未横跨X轴正方向
            {
                startAngle = (int)(dK1 < dK3 ? dK1 : dK3); //数值较小的为起始点
                sweepAngle = (int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3);
            }
            else
            {
                startAngle = (int)(dK1 < dK3 ? dK3 : dK1);//数值较大的为起始点
                sweepAngle = 360 - ((int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3));
            }

            //graph = this.pictureBox.CreateGraphics();
            return new float[] { fTemp[0] - fTemp[2], fTemp[1] - fTemp[2], Math.Abs(fTemp[2] * 2), Math.Abs(fTemp[2] * 2), startAngle, sweepAngle };
        }

        /// <summary>
        /// 根据三点计算并获取圆
        /// </summary>
        /// <param name="x1">第一点的X坐标</param>
        /// <param name="y1">第一点的Y坐标</param>
        /// <param name="x2">第二点的X坐标</param>
        /// <param name="y2">第二点的Y坐标</param>
        /// <param name="x3">第三点的X坐标</param>
        /// <param name="y3">第三点的Y坐标</param>
        /// <returns>圆参数float数组：圆心X坐标、圆心Y坐标、圆半径</returns>
        public static float[] GetCircle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double k1 = (y2 - y1) / (x2 - x1);
            double k2 = (y3 - y1) / (x3 - x1);

            double xm1 = x1 - ((x1 - x2) / 2);
            double ym1 = y1 - ((y1 - y2) / 2);
            double km1 = -(1 / k1);
            double bm1 = ym1 - (km1 * xm1);

            double xm2 = x1 - ((x1 - x3) / 2);
            double ym2 = y1 - ((y1 - y3) / 2);
            double km2 = -(1 / k2);
            double bm2 = ym2 - (km2 * xm2);

            double xc = (bm2 - bm1) / (km1 - km2);
            double yc = km1 * xc + bm1;
            double rc = Math.Sqrt(Math.Pow((x1 - xc), 2) + Math.Pow((y1 - yc), 2));
            return new float[] { (float)xc, (float)yc, (float)rc };
        }

        /// <summary>
        /// 根据三点画圆弧
        /// </summary>
        /// <param name="dX1">第一个点的X坐标</param>
        /// <param name="dY1">第一个点的Y坐标</param>
        /// <param name="dX2">第二个点的X坐标</param>
        /// <param name="dY2">第二个点的Y坐标</param>
        /// <param name="dX3">第三个点的X坐标</param>
        /// <param name="dY3">第三个点的Y坐标</param>
        public static float[] DrawArcNew(float dX1, float dY1, float dX2, float dY2, float dX3, float dY3)
        {
            float[] fTemp = GetCircleNew(dX1, dY1, dX2, dY2, dX3, dY3);
            double dK1 = ReturnCircleK((float)dX1, (float)dY1, fTemp[0], fTemp[1]);
            double dK2 = ReturnCircleK((float)dX2, (float)dY2, fTemp[0], fTemp[1]);
            double dK3 = ReturnCircleK((float)dX3, (float)dY3, fTemp[0], fTemp[1]);

            float startAngle, sweepAngle;
            if ((dK1 < dK2 && dK3 > dK2) || (dK1 > dK2 && dK3 < dK2))//未横跨X轴正方向
            {
                startAngle = (int)(dK1 < dK3 ? dK1 : dK3); //数值较小的为起始点
                sweepAngle = (int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3);
            }
            else
            {
                startAngle = (int)(dK1 < dK3 ? dK3 : dK1);//数值较大的为起始点
                sweepAngle = 360 - ((int)(dK1 < dK3 ? dK3 : dK1) - (int)(dK1 < dK3 ? dK1 : dK3));
            }

            return new float[] { fTemp[0] - fTemp[2], fTemp[1] - fTemp[2], Math.Abs(fTemp[2] * 2), Math.Abs(fTemp[2] * 2), startAngle, sweepAngle };
        }

        /// <summary>
        /// 三点法计算圆心坐标和圆半径
        /// </summary>
        /// <param name="x1">第一点的X坐标</param>
        /// <param name="y1">第一点的Y坐标</param>
        /// <param name="x2">第二点的X坐标</param>
        /// <param name="y2">第二点的Y坐标</param>
        /// <param name="x3">第三点的X坐标</param>
        /// <param name="y3">第三点的Y坐标</param>
        /// <returns>圆参数float数组：圆心X坐标、圆心Y坐标、圆半径</returns>
        public static float[] GetCircleNew(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float a, b, c, g, e, f;
            float X, Y, R;
            e = 2 * (x2 - x1);
            f = 2 * (y2 - y1);
            g = x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1;
            a = 2 * (x3 - x2);
            b = 2 * (y3 - y2);
            c = x3 * x3 - x2 * x2 + y3 * y3 - y2 * y2;
            X = (g * b - c * f) / (e * b - a * f);
            Y = (a * g - c * e) / (a * f - b * e);
            R = (float)Math.Sqrt((X - x1) * (X - x1) + (Y - y1) * (Y - y1));
            return new[] { X, Y, R };
        }

        public static double ReturnCircleK(float fx1, float fy1, float fx2, float fy2)
        {
            double fA = Math.Atan2(fy1 - fy2, fx1 - fx2) / Math.PI * 180;
            if (fA < 0) fA += 360;
            return fA;
        }

        /// <summary>
        /// 物理坐标转为像素坐标，再转为图像坐标
        /// </summary>
        /// <param name="doubles">0：物理坐标X，1：物理坐标Y，2：基准点坐标X，3：基准点坐标Y，4：图像与像框的比例</param>
        /// <returns>返回图像int类型坐标点</returns>
        public static Point TransformToPixels(params double[] doubles)//(double unitX, double unitY, double originX, double originY, double radio)
        {
            double dx = GlueVariableDefine.PhysicalLength / GlueVariableDefine.PixelsNumber, dy = dx;
            int pixelX = Convert.ToInt32((doubles[0] + doubles[2] * dx) / dx);
            int pixelY = Convert.ToInt32((doubles[1] + doubles[3] * dy) / dy);
            if (doubles.Length > 4)
            {
                int picX = Convert.ToInt32(pixelX / doubles[4]);
                int picY = Convert.ToInt32(pixelY / doubles[4]);
                return new Point { X = picX, Y = picY };
            }
            return new Point { X = pixelX, Y = pixelY };
        }

        /// <summary>
        /// 物理坐标转为像素坐标，再转为图像坐标
        /// </summary>
        /// <param name="doubles">0：物理坐标X，1：物理坐标Y，2：基准点坐标X，3：基准点坐标Y，4：图像与像框的比例</param>
        /// <returns>返回图像float类型坐标点</returns>
        public static PointF TransformToPixelsF(params double[] doubles)//(double unitX, double unitY, double originX, double originY, double radio)
        {
            double dx = GlueVariableDefine.PhysicalLength / GlueVariableDefine.PixelsNumber, dy = dx;
            float pixelX = Convert.ToInt64((doubles[0] + doubles[2] * dx) / dx);
            float pixelY = Convert.ToInt64((doubles[1] + doubles[3] * dy) / dy);
            if (doubles.Length > 4)
            {
                float picX = pixelX / (float)doubles[4];
                float picY = pixelY / (float)doubles[4];
                return new PointF { X = picX, Y = picY };
            }
            return new PointF { X = pixelX, Y = pixelY };
        }

        /// <summary>
        /// 获取旋转后的物理坐标
        /// </summary>
        /// <param name="x">物理坐标X</param>
        /// <param name="y">物理坐标Y</param>
        /// <param name="originX">基准点坐标X</param>
        /// <param name="originY">基准点坐标Y</param>
        /// <param name="θ">旋转角度</param>
        /// <returns></returns>
        public static double[] GetRotatedPoint(double x, double y, double originX, double originY, double θ)
        {
            Point pixelPoint = TransformToPixels(x, y, originX, originY);

            //图像的宽度x高度为col x row,图像中某个像素P(x1, y1)，绕某个像素点Q(x2, y2)旋转θ角度后,则该像素点的新坐标位置为(x, y)
            //x1 = x1; 
            //y1 = row - y1; 
            //x2 = x2; 
            //y2 = row - y2; 
            //x = (x1 - x2)*cos(pi / 180.0 * θ) - (y1 - y2)*sin(pi / 180.0 * θ) + x2; 
            //y = (x1 - x2)*sin(pi / 180.0 * θ) + (y1 - y2)*cos(pi / 180.0 * θ) + y2; 
            //x=x; 
            //y = row - y;
            int beforeX = pixelPoint.X, beforeY = pixelPoint.Y;
            var afterX = (int)((beforeX - originX) * Math.Cos(Math.PI / 180.0 * θ) - (beforeY - originY) * Math.Sin(Math.PI / 180.0 * θ) + originX);
            var afterY = (int)((beforeX - originX) * Math.Sin(Math.PI / 180.0 * θ) + (beforeY - originY) * Math.Cos(Math.PI / 180.0 * θ) + originY);

            double dx = GlueVariableDefine.PhysicalLength / GlueVariableDefine.PixelsNumber, dy = dx;
            double xRound = Math.Round(Convert.ToDouble((afterX - originX) * dx), 3);
            double yRound = Math.Round(Convert.ToDouble((afterY - originY) * dy), 3);

            return new[] { xRound, yRound };
        }
    }
}
