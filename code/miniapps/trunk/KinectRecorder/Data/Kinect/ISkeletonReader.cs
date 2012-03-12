using System;

namespace Data.Kinect
{
    public interface ISkeletonReader : IDisposable
    {
        event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady;
    }
}