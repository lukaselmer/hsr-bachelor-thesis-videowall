using System;
using Microsoft.Kinect;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

namespace VideoWall.Tests.Mocks
{
    internal class PlayerMock : IPlayer
    {
        #region Implementation of IPlayer

        public Skeleton Skeleton { get; private set; }
        public bool Playing { get; private set; }
        public event EventHandler<SkeletonChangedEventArgs> SkeletonChanged;
        public void StartPlaying()
        {
        }

        public void StopPlaying()
        {
        }

        #endregion
    }
}