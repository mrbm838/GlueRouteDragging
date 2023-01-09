using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace GlueReadWrite
{
    public static class GluePathForZ
    {
        public static void TransformToPixels(double unitX,
            double unitY,
            out int pixelX,
            out int pixelY)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                pixelX = (int)((g.DpiX / 96) * unitX);
                pixelY = (int)((g.DpiY / 96) * unitY);
            }

            // alternative:
            // using (Graphics g = Graphics.FromHdc(IntPtr.Zero)) { }
        }
    }
}
