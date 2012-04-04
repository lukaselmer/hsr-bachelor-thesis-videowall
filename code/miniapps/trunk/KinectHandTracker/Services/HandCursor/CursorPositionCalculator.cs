using System;
using System.Diagnostics;
using System.Windows.Forms;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;
using System.Windows;

namespace Services.HandCursor
{
    public class CursorPositionCalculator
    {
        protected Padding RelativeZonePadding { get; set; }

        public CursorPositionCalculator()
        {
            RelativeZonePadding = new Padding(0.45, 0.3, 0.3, 0.35);
            //RelativeZonePadding = new Padding(0.5, 0, 0, 0);
        }

        public Point CalculatePositionFromSkeleton(double windowWidth, double windowHeight, Skeleton skeleton)
        {
            if (skeleton == null || (int)windowHeight == 0 || (int)windowWidth == 0) return new Point(0, 0);

            var joint = skeleton.Joints[JointType.HandRight];

            //Console.WriteLine(absolutePosition.Position.X + "/" + absolutePosition.Position.Y);
            var absolutePosition = joint.ScaleTo((int)windowWidth, (int)windowHeight);

            return RelativePositionFor(windowWidth, windowHeight, absolutePosition);
        }

        private Point RelativePositionFor(double windowWidth, double windowHeight, Joint absolutePosition)
        {
            var marginLeft = windowWidth * (RelativeZonePadding.Left);
            var marginTop = windowHeight * (RelativeZonePadding.Top);
            var marginRight = windowWidth * (RelativeZonePadding.Right);
            var marginBottom = windowHeight * (RelativeZonePadding.Bottom);

            var zonePositonTopLeft = new Point(marginLeft, marginTop);
            var zonePositionBottomRight = new Point(windowWidth - marginRight, windowHeight - marginBottom);

            var posX = (double)absolutePosition.Position.X;
            var posY = (double)absolutePosition.Position.Y;

            posX = Math.Max(posX, zonePositonTopLeft.X);
            posX = Math.Min(posX, zonePositionBottomRight.X);
            posY = Math.Max(posY, zonePositonTopLeft.Y);
            posY = Math.Min(posY, zonePositionBottomRight.Y);

            var zoneWidth = windowWidth - marginRight - marginLeft;
            var zoneHeight = windowHeight - marginTop - marginBottom;

            posX -= marginLeft;
            posY -= marginTop;

            posX = posX * windowWidth / zoneWidth;
            posY = posY * windowHeight / zoneHeight;

            /*Console.WriteLine("--");
            Console.WriteLine(absolutePosition.Position.X + "/" + absolutePosition.Position.Y);
            Console.WriteLine(posX + "/" + posY);
            Console.WriteLine(windowWidth+", "+windowHeight);
            Console.WriteLine(zoneWidth+", "+zoneHeight);*/

            /*if (posY > zonePositionBottomRight.Y) posY = zonePositionBottomRight.Y;
            else if (posY < zonePositonTopLeft.Y) posY = zonePositonTopLeft.Y;

            if (posX > zonePositionBottomRight.X) posX = zonePositionBottomRight.X;
            else if (posX < zonePositonTopLeft.X) posX = zonePositonTopLeft.X;*/


            //var absolutePosition = joint.ScaleTo((int)(windowWidth + marginRight + marginLeft), (int)(windowHeight + marginTop + marginBottom));


            //return new Point(absolutePosition.Position.X, absolutePosition.Position.Y);

            //var posX = absolutePosition.Position.X * windowWidth / zoneWidth;
            //var posY = absolutePosition.Position.Y * windowHeight / zoneHeight;


            //var scaledHeight = absolutePosition.Position.Y * windowHeight / zoneHeight;
            //var scaledWidth = absolutePosition.Position.X * windowWidth / zoneWidth;

            return new Point(posX, posY);
        }

        public class Padding
        {
            public double Left { get; private set; }
            public double Top { get; private set; }
            public double Right { get; private set; }
            public double Bottom { get; private set; }

            public Padding(double left, double top, double right, double bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;

                Debug.Assert(left + right < 1.0, "left+right < 1.0");
                Debug.Assert(top + bottom < 1.0, "top + bottom < 1.0");
            }
        }
    }
}