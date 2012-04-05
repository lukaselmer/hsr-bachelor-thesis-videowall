using System.Diagnostics;
using System.Windows;

namespace Services.HandCursor
{
    internal class AbsoloutePadding
    {
        private readonly RelativePadding _relative;
        private readonly Size _window;

        public AbsoloutePadding(RelativePadding relative, Size window)
        {
            _relative = relative;
            _window = window;

            Debug.Assert(relative != null, "relative != null");
            Debug.Assert(window != null, "window != null");
        }

        public double Left { get { return _window.Width * _relative.Left; } }
        public double Right { get { return _window.Width * _relative.Right; } }
        public double Top { get { return _window.Height * _relative.Top; } }
        public double Bottom { get { return _window.Height * _relative.Bottom; } }
    }
}