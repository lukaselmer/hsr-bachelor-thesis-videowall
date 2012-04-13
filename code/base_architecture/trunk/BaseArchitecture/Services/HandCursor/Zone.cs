using System.Windows;

namespace Services.HandCursor
{
    internal class Zone
    {
        public Point TopLeft { get; private set; }
        public Point BottomRight { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Zone(Size window, AbsoloutePadding padding)
        {
            TopLeft = new Point(padding.Left, padding.Top);
            BottomRight = new Point(window.Width - padding.Right, window.Height - padding.Bottom);
            Width = window.Width - padding.Right - padding.Left;
            Height = window.Height - padding.Top - padding.Bottom;
        }
    }
}
