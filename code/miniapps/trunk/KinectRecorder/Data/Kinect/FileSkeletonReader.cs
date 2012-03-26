using System;
using System.IO;
using Kinect.Toolbox.Record;

namespace Data.Kinect
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    class FileSkeletonReader : ISkeletonReader
    {
        private readonly SkeletonReplay _skeletonReplay;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSkeletonReader"/> class.
        /// </summary>
        /// <param name="kinectReplayFile">The kinect replay file.</param>
        public FileSkeletonReader(KinectReplayFile kinectReplayFile)
        {
            using (var stream = File.OpenRead(kinectReplayFile.Path))
            {
                _skeletonReplay = new SkeletonReplay(stream);
                _skeletonReplay.SkeletonFrameReady += OnSkeletonFrameReady;
            }
        }

        /// <summary>
        /// Called when [skeleton frame ready].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Kinect.Toolbox.Record.ReplaySkeletonFrameReadyEventArgs"/> instance containing the event data.</param>
        private void OnSkeletonFrameReady(object sender, ReplaySkeletonFrameReadyEventArgs e)
        {
            SkeletonsReady(this, new SkeletonsReadyEventArgs(e.SkeletonFrame.Skeletons));
        }

        /// <summary>
        /// Starts the reading process
        /// </summary>
        public void Start()
        {
            _skeletonReplay.Start();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _skeletonReplay.SkeletonFrameReady -= OnSkeletonFrameReady;
            _skeletonReplay.Stop();
        }

        /// <summary>
        /// Occurs when [skeletons ready].
        /// </summary>
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady = delegate { };
    }
}