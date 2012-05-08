using System.Windows;

namespace Services.HandCursor
{
    /// <summary>
    /// Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    internal class Zone
    {
        /// <summary>
        /// Gets the top left point.
        /// </summary>
        public Point TopLeft { get; private set; }
        /// <summary>
        /// Gets the bottom right point.
        /// </summary>
        public Point BottomRight { get; private set; }
        /// <summary>
        /// Gets the width.
        /// </summary>
        public double Width { get; private set; }
        /// <summary>
        /// Gets the height.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="padding">The padding.</param>
        public Zone(Size window, AbsolutePadding padding)
        {
            TopLeft = new Point(padding.Left, padding.Top);
            BottomRight = new Point(window.Width - padding.Right, window.Height - padding.Bottom);
            Width = window.Width - padding.Right - padding.Left;
            Height = window.Height - padding.Top - padding.Bottom;
        }
    }
}
