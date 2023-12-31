﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlueReadWrite
{
    enum EnumLineType
    {
        Line,
        Arc
    }

    enum EnumCircleMode
    {
        XY,
        XZ,
        YZ,
        XYZ,
        XYZR,
        XYZRA
    }

    public static class GlueVariableDefine
    {
        public static double PhysicalLength { get; set; }

        public static int PixelsNumber { get; set; }

        public static double OffsetX { get; set; }

        public static double OffsetY { get; set; }
    }
}
