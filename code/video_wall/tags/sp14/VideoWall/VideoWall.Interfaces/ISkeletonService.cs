using System;

namespace VideoWall.Interfaces
{
    /// <summary>
    /// The skeleton service provides the skeletal tracking
    /// </summary>
    public interface ISkeletonService : IVideoWallService
    {
        /// <summary>
        /// Occurs when skeleton changes.
        /// </summary>
        event EventHandler<SkeletonChangedEventArgs> SkeletonChanged;
    }
}