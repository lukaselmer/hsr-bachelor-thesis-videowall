#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

#endregion

namespace Services.HandCursor
{
    public delegate void HandChanged(bool isRightHand);

    /// <summary>
    ///   Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class HandCursorPositionCalculator
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="HandCursorPositionCalculator" /> class.
        /// </summary>
        public HandCursorPositionCalculator()
        {
            //TODO: Magic numbers. Where do these come from? Needs explanation
            //0.45, 0.1, 0.3, 0.49
            RelativePadding = new RelativePadding(0.45, 0.1, 0.3, 0.49);
        }

        protected RelativePadding RelativePadding { get; private set; }

        public event HandChanged HandChanged;

        private void OnHandChanged(bool isRightHand)
        {
            if (HandChanged != null)
            {
                HandChanged(isRightHand);
            }
        }

        /// <summary>
        ///   Calculates the position of the hand cursor from the position of multiple skeletons by taking their avertage.
        /// </summary>
        /// <param name="window"> The size of the window. </param>
        /// <param name="skeletons"> The skeletons. </param>
        /// <returns> </returns>
        public Point CalculatePositionFromSkeletons(Size window, Queue<Skeleton> skeletons)
        {
            var totalPosition = new Point(0, 0);
            foreach (var singlePosition in skeletons.Select(skeleton => CalculatePositionFromSkeleton(window, skeleton)))
            {
                totalPosition.X += singlePosition.X;
                totalPosition.Y += singlePosition.Y;
            }
            totalPosition.X /= skeletons.Count;
            totalPosition.Y /= skeletons.Count;
            return totalPosition;

            // Alternative implementation. Is this better readable?
            //var points = new List<Point>(skeletons.Count);
            //points.AddRange(skeletons.Select(skeleton => CalculatePositionFromSkeleton(window, skeleton)));
            //var xSum = points.Sum(point => point.X);
            //var ySum = points.Sum(point => point.Y);
            //return new Point(xSum / skeletons.Count, ySum / skeletons.Count);
        }

        /// <summary>
        ///   Calculates the position of the hand cursor from the position of the skeleton.
        /// </summary>
        /// <param name="window"> The size of the window. </param>
        /// <param name="skeleton"> The skeleton. </param>
        /// <returns> </returns>
        private Point CalculatePositionFromSkeleton(Size window, Skeleton skeleton)
        {
            if (skeleton == null || (int) window.Height <= 0 || (int) window.Width <= 0) return new Point(0, 0);

            Joint joint;
            if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y)
            {
                joint = skeleton.Joints[JointType.HandLeft];
                OnHandChanged(false);
                RelativePadding.SetPaddingForLeftHanded();
            }
            else
            {
                joint = skeleton.Joints[JointType.HandRight];
                OnHandChanged(true);
                RelativePadding.SetPaddingForRightHanded();
            }

            var absolutePosition = joint.ScaleTo((int) window.Width, (int) window.Height);

            return RelativePositionFor(window, new Point(absolutePosition.Position.X, absolutePosition.Position.Y));
        }

        /// <summary>
        ///   Calculates the relative position for a defined window size and a position.
        /// </summary>
        /// <param name="window"> The window. </param>
        /// <param name="position"> The position. </param>
        /// <returns> </returns>
        private Point RelativePositionFor(Size window, Point position)
        {
            var posX = position.X;
            var posY = position.Y;

            var padding = new AbsolutePadding(RelativePadding, window);

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
            Debug.Assert(0 <= (int) posX && (int) posX <= (int) zone.Width, "posX must contain a value so 0 <= posX <= zone.Width");
            Debug.Assert(0 <= (int) posY && (int) posY <= (int) zone.Height, "posY must contain a value so 0 <= posY <= zone.Height");

            // Scale the zone relative coordinate to the window size
            posX = posX*window.Width/zone.Width;
            posY = posY*window.Height/zone.Height;

            return new Point(posX, posY);
        }
    }
}