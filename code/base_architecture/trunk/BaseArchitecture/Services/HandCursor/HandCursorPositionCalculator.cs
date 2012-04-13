using System;
using System.Diagnostics;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;
using System.Windows;

namespace Services.HandCursor
{
    public class HandCursorPositionCalculator
    {
        protected RelativePadding RelativePadding { get; private set; }

        public HandCursorPositionCalculator()
        {
            RelativePadding = new RelativePadding(0.45, 0.1, 0.3, 0.49);
            //AbsoloutePadding = new Padding(0.5, 0, 0, 0);
        }

        public Point CalculatePositionFromSkeleton(Size window, Skeleton skeleton)
        {
            if (skeleton == null || (int)window.Height <= 0 || (int)window.Width <= 0) return new Point(0, 0);

            var joint = skeleton.Joints[JointType.HandRight];

            var absolutePosition = joint.ScaleTo((int)window.Width, (int)window.Height);

            return RelativePositionFor(window, new Point(absolutePosition.Position.X, absolutePosition.Position.Y));
        }

        private Point RelativePositionFor(Size window, Point position)
        {
            var posX = position.X;
            var posY = position.Y;

            var padding = new AbsoloutePadding(RelativePadding, window);

            var zone = new Zone(window, padding);

            // Map points which are out of the zone to the border of the zone
            posX = Math.Max(posX, zone.TopLeft.X);
            posY = Math.Max(posY, zone.TopLeft.Y);
            posX = Math.Min(posX, zone.BottomRight.X);
            posY = Math.Min(posY, zone.BottomRight.Y);

            // Subtract the padding left and padding top so 
            // 0 <= posX <= zone.Width and 0 <= posY <= zone.Height
            posX -= padding.Left;
            posY -= padding.Top;
            Debug.Assert(0 <= (int)posX && (int)posX <= (int)zone.Width, "posX must contain a value so 0 <= posX <= zone.Width");
            Debug.Assert(0 <= (int)posY && (int)posY <= (int)zone.Height, "posY must contain a value so 0 <= posY <= zone.Height");

            // Scale the zone relative coordinate to the window size
            posX = posX * window.Width / zone.Width;
            posY = posY * window.Height / zone.Height;

            return new Point(posX, posY);
        }
    }
}
