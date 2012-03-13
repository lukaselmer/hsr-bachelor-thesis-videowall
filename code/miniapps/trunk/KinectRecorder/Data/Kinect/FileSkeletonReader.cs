using System;
using System.IO;
using Kinect.Toolbox.Record;

namespace Data.Kinect
{
    class FileSkeletonReader : ISkeletonReader
    {
        private readonly SkeletonReplay _skeletonReplay;

        public FileSkeletonReader(KinectReplayFile kinectReplayFile)
        {
            using (var stream = File.OpenRead(kinectReplayFile.Path))
            {
                _skeletonReplay = new SkeletonReplay(stream);
                _skeletonReplay.SkeletonFrameReady += OnSkeletonFrameReady;
            }
        }

        private void OnSkeletonFrameReady(object sender, ReplaySkeletonFrameReadyEventArgs e)
        {
            SkeletonsReady(this, new SkeletonsReadyEventArgs(e.SkeletonFrame.Skeletons));
        }

        public void Start()
        {
            _skeletonReplay.Start();
        }

        public void Dispose()
        {
            _skeletonReplay.SkeletonFrameReady -= OnSkeletonFrameReady;
            _skeletonReplay.Stop();
        }

        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady = delegate { };
    }
}