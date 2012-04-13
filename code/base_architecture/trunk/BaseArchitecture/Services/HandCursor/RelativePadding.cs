using System;
using System.Diagnostics;

namespace Services.HandCursor
{
    public class RelativePadding
    {
        public Double Left { get; private set; }
        public double Top { get; private set; }
        public double Right { get; private set; }
        public double Bottom { get; private set; }

        public RelativePadding(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            Debug.Assert(Left >= 0.0, "Left must be >= 0");
            Debug.Assert(Top >= 0.0, "Top must be >= 0");
            Debug.Assert(Right >= 0.0, "Right must be >= 0");
            Debug.Assert(Bottom >= 0.0, "Bottom must be >= 0");
            Debug.Assert(Left + Right < 1.0, "left+right < 1.0");
            Debug.Assert(Top + Bottom < 1.0, "top + bottom < 1.0");
        }
    }
}
