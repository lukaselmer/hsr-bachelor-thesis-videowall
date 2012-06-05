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

using System.Windows;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

#endregion

namespace VideoWall.ViewModels.Skeletons
{
    /// <summary>
    ///   The SkeletonLine. Reviewed by Christina Heidt, 23.04.2012
    /// </summary>
    public class SkeletonLine
    {
        #region Declarations

        private readonly Point _endPosition;
        private readonly Point _startPosition;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the end position of the line.
        /// </summary>
        public Point EndPosition { get { return _endPosition; } }

        /// <summary>
        ///   Gets the start position of the line.
        /// </summary>
        public Point StartPosition { get { return _startPosition; } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="SkeletonLine" /> class.
        /// </summary>
        /// <param name="startPosition"> The start position. </param>
        /// <param name="endPosition"> The end position. </param>
        /// <param name="scale"> The scale to fit the skeleton into the canvas. </param>
        public SkeletonLine(Joint startPosition, Joint endPosition, int scale)
        {
            var startJoint = startPosition.ScaleTo(scale, scale);
            var endJoint = endPosition.ScaleTo(scale, scale);
            _startPosition = new Point(startJoint.Position.X, startJoint.Position.Y);
            _endPosition = new Point(endJoint.Position.X, endJoint.Position.Y);
        }

        #endregion
    }
}
