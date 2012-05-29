using System;
using Microsoft.Kinect;

namespace VideoWall.Interfaces
{
    public class SkeletonChangedEventArgs : EventArgs
    {
        public Skeleton Skeleton { get; private set; }

        public SkeletonChangedEventArgs(Skeleton skeleton)
        {
            Skeleton = skeleton;
        }
    }
}