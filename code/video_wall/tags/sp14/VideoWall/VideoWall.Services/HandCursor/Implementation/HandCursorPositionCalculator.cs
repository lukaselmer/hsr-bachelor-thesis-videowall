#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;
using VideoWall.Common;
using VideoWall.ServiceModels.HandCursor.Interfaces;

#endregion

namespace VideoWall.ServiceModels.HandCursor.Implementation
{
    /// <summary>
    ///   The HandCursorPositionCalculator. Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class HandCursorPositionCalculator : IHandCursorPositionCalculator
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        private readonly RelativePadding _relativePaddingForLeftHanded;
        private readonly RelativePadding _relativePaddingForRightHanded;
        private Skeleton _latestSkeleton;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the relative padding.
        /// </summary>
        private RelativePadding RelativePadding { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when the hand changed.
        /// </summary>
        public event EventHandler<HandChangedEventArgs> HandChanged;

        #endregion

        #region Constructors / Destructor


        /// <summary>
        /// Initializes a new instance of the <see cref="HandCursorPositionCalculator"/> class.
        /// </summary>
        /// <param name="relativePaddingForRightHanded">The relative padding for right hander.</param>
        public HandCursorPositionCalculator(RelativePadding relativePaddingForRightHanded)
        {
            //TODO: Magic numbers. Where do these come from? Needs explanation
            //_relativePaddingForRightHanded = new RelativePadding(0.45, 0.1, 0.3, 0.49);
            _relativePaddingForRightHanded = relativePaddingForRightHanded;
            _relativePaddingForLeftHanded = new RelativePadding(_relativePaddingForRightHanded.Right, _relativePaddingForRightHanded.Top, _relativePaddingForRightHanded.Left, _relativePaddingForRightHanded.Bottom);
            RelativePadding = _relativePaddingForRightHanded;
        }

        #endregion

        #region Methods

        private void OnHandChanged(HandType handType)
        {
            if (HandChanged != null)
            {
                HandChanged(this, new HandChangedEventArgs(handType));
            }
        }

        /// <summary>
        ///   Calculates the position of the hand cursor from the position of multiple skeletons by taking their avertage.
        /// </summary>
        /// <param name="window"> The size of the window. </param>
        /// <param name="skeletons"> The skeletons. </param>
        /// <param name="latestSkeleton"> </param>
        /// <returns> </returns>
        public Point CalculatePositionFromSkeletons(Size window, Queue<Skeleton> skeletons, Skeleton latestSkeleton)
        {
            PreOrPostCondition.AssertNotNull(window, "window");
            PreOrPostCondition.AssertNotNull(skeletons, "skeletons");
            //PreOrPostCondition.AssertTrue(skeletons.Count > 0, "skeletons.Count must be > 0");
            //PreOrPostCondition.AssertNotNull(latestSkeleton, "latestSkeleton");
            if (latestSkeleton != null) _latestSkeleton = latestSkeleton;
            var activeHand = SelectHandForLatestSkeleton();
            OnHandChanged(activeHand);

            var totalPosition = new Point(0, 0);
            foreach (var singlePosition in skeletons.Select(skeleton => CalculatePositionFromSkeleton(window, skeleton, activeHand)))
            {
                totalPosition.X += singlePosition.X;
                totalPosition.Y += singlePosition.Y;
            }
            totalPosition.X /= skeletons.Count;
            totalPosition.Y /= skeletons.Count;


            return totalPosition;
        }

        private HandType SelectHandForLatestSkeleton()
        {
            if (_latestSkeleton == null) return HandType.Right;
            var rightHandYPosition = _latestSkeleton.Joints[JointType.HandRight].Position.Y;
            var leftHandYPosition = _latestSkeleton.Joints[JointType.HandLeft].Position.Y;
            return rightHandYPosition > leftHandYPosition ? HandType.Right : HandType.Left;
        }

        /// <summary>
        /// Calculates the position of the hand cursor from the position of the skeleton.
        /// </summary>
        /// <param name="window">The size of the window.</param>
        /// <param name="skeleton">The skeleton.</param>
        /// <param name="handType">Type of the hand.</param>
        /// <returns></returns>
        private Point CalculatePositionFromSkeleton(Size window, Skeleton skeleton, HandType handType)
        {
            //PreOrPostCondition.AssertNotNull(handType, "handType");

            if (skeleton == null || (int)window.Height <= 0 || (int)window.Width <= 0) return new Point(0, 0);

            var joint = skeleton.Joints[handType == HandType.Right ? JointType.HandRight : JointType.HandLeft];
            //OnHandChanged(HandType.Left);
            RelativePadding = handType == HandType.Right ? _relativePaddingForRightHanded : _relativePaddingForLeftHanded;

            /*if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y)
            {
                joint = skeleton.Joints[JointType.HandLeft];
                OnHandChanged(HandType.Left);
                RelativePadding = _relativePaddingForLeftHanded;
            }
            else
            {
                joint = skeleton.Joints[JointType.HandRight];
                OnHandChanged(HandType.Right);
                RelativePadding = _relativePaddingForRightHanded;
            }*/

            var absolutePosition = joint.ScaleTo((int)window.Width, (int)window.Height);

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
            PreOrPostCondition.AssertTrue(0 <= (int)posX && (int)posX <= (int)zone.Width, "posX must contain a value so 0 <= posX <= zone.Width");
            PreOrPostCondition.AssertTrue(0 <= (int)posY && (int)posY <= (int)zone.Height, "posY must contain a value so 0 <= posY <= zone.Height");

            // Scale the zone relative coordinate to the window size
            posX = posX * window.Width / zone.Width;
            posY = posY * window.Height / zone.Height;

            return new Point(posX, posY);
        }

        #endregion
    }
}