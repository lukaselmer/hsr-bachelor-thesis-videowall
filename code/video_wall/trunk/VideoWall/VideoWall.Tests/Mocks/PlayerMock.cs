using System;
using Microsoft.Kinect;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

namespace VideoWall.Tests.Mocks
{
    internal class PlayerMock : IPlayer
    {
        #region Implementation of IPlayer

        public Skeleton Skeleton
        {
            get { return null; } }

        public bool Playing
        {
            get { return false; } }

        public event EventHandler<SkeletonChangedEventArgs> SkeletonChanged = delegate {};
        public void StartPlaying()
        {
        }

        public void StopPlaying()
        {
        }

        public void TriggerSkeletonChangedEvent()
        {
            SkeletonChanged(this, null);
        }

        #endregion
    }
}