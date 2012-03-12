using System;
using Microsoft.Kinect;

namespace Data
{
    public class SkeletonsReadyEventArgs : EventArgs
    {
        public Skeleton[] Skeletons { get; private set; }

        public SkeletonsReadyEventArgs(Skeleton[] skeletons)
        {
            Skeletons = skeletons;
        }
    }
}