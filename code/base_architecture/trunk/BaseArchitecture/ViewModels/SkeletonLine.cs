using System.Windows;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.04.2012
    /// </summary>
    public class SkeletonLine
    {
        private readonly Point _startPosition;
        private readonly Point _endPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkeletonLine"/> class.
        /// </summary>
        /// <param name="startPosition">The start position.</param>
        /// <param name="endPosition">The end position.</param>
        /// <param name="scale">The scale to fit the skeleton into the canvas.</param>
        public SkeletonLine(Joint startPosition, Joint endPosition, int scale)
        {
            var startJoint = startPosition.ScaleTo(scale, scale);
            var endJoint = endPosition.ScaleTo(scale, scale);
            _startPosition = new Point(startJoint.Position.X, startJoint.Position.Y);
            _endPosition = new Point(endJoint.Position.X, endJoint.Position.Y); ;
        }

        /// <summary>
        /// Gets the end position of the line.
        /// </summary>
        public Point EndPosition
        {
            get { return _endPosition; }
        }

        /// <summary>
        /// Gets the start position of the line.
        /// </summary>
        public Point StartPosition
        {
            get { return _startPosition; }
        }
    }
}
