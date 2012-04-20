using Microsoft.Kinect;

namespace ViewModels
{
    public class LineViewModel
    {
        private readonly Joint _startPosition;
        private readonly Joint _endPosition;

        public LineViewModel(Joint startPosition, Joint endPosition)
        {
            _startPosition = startPosition;
            _endPosition = endPosition;
        }

        public Joint EndPosition
        {
            get { return _endPosition; }
        }

        public Joint StartPosition
        {
            get { return _startPosition; }
        }
    }
}
