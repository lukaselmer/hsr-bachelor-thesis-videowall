using System.Windows;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.04.2012
    /// </summary>
    public class LineViewModel
    {
        //private readonly Joint _startPosition;
        //private readonly Joint _endPosition;
        private Point _startPosition;
        private Point _endPosition;

        public LineViewModel(Joint startPosition, Joint endPosition)
        {
            //TODO: Refactor with PlayerViewModel
            var startJoint = startPosition.ScaleTo(153, 153);
            var endJoint = endPosition.ScaleTo(153, 153);
            _startPosition = new Point(startJoint.Position.X, startJoint.Position.Y);
            _endPosition = new Point(endJoint.Position.X, endJoint.Position.Y); ;
        }

        public Point EndPosition
        {
            get { return _endPosition; }
        }

        public Point StartPosition
        {
            get { return _startPosition; }
        }



    }
}
