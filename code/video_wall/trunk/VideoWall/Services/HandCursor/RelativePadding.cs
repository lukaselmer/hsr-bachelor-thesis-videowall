using System;
using System.Diagnostics;

namespace Services.HandCursor
{
    /// <summary>
    /// Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class RelativePadding
    {
        public double Left { get; private set; }
        public double Top { get; private set; }
        public double Right { get; private set; }
        public double Bottom { get; private set; }
        private readonly double _rightHandedLeft;
        private readonly double _rightHandedRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelativePadding"/> class.
        /// </summary>
        /// <param name="left">The left padding.</param>
        /// <param name="top">The top padding.</param>
        /// <param name="right">The right padding.</param>
        /// <param name="bottom">The bottom padding.</param>
        public RelativePadding(double left, double top, double right, double bottom)
        {
            Left = _rightHandedLeft = left;
            Top = top;
            Right = _rightHandedRight = right;
            Bottom = bottom;

            Debug.Assert(Left >= 0.0, "Left must be >= 0");
            Debug.Assert(Top >= 0.0, "Top must be >= 0");
            Debug.Assert(Right >= 0.0, "Right must be >= 0");
            Debug.Assert(Bottom >= 0.0, "Bottom must be >= 0");
            Debug.Assert(Left + Right < 1.0, "left+right < 1.0");
            Debug.Assert(Top + Bottom < 1.0, "top + bottom < 1.0");
        }

        public void SetPaddingForRightHanded()
        {
            Left = _rightHandedLeft;
            Right = _rightHandedRight;
        }

        public void SetPaddingForLeftHanded()
        {
            Left = _rightHandedRight;
            Right = _rightHandedLeft;
        }
    }
}
