using System;

namespace VideoWall.Common.Exceptions
{
    public class VideoWallException : Exception
    {
        public VideoWallException(string message) : base(message) { }
        public VideoWallException(string message, Exception innerException) : base(message, innerException) { }
    }
}