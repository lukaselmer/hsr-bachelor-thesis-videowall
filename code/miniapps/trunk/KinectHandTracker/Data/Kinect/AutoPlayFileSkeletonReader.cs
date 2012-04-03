using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Threading;
using Kinect.Toolbox.Record;
using Timer = System.Timers.Timer;

namespace Data.Kinect
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    class AutoPlayFileSkeletonReader : ISkeletonReader
    {
        private const double CheckTimerInterval = 1400;
        private const double RestartReplayAfterSoManyMilliseconds = 4000;

        private readonly KinectReplayFile _kinectReplayFile;
        private SkeletonReplay _skeletonReplay;
        private DateTime _lastTimeReady;
        private Timer _replayTimer;
        private Dispatcher Dispatcher { get; set; }

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSkeletonReader"/> class.
        /// </summary>
        /// <param name="kinectReplayFile">The kinect replay file.</param>
        public AutoPlayFileSkeletonReader(KinectReplayFile kinectReplayFile)
        {
            _kinectReplayFile = kinectReplayFile;

            InitReplayTimer();
            InitSkeletonReplay();
        }

        private void InitReplayTimer()
        {
            _replayTimer = new Timer(CheckTimerInterval);
            Dispatcher = Dispatcher.CurrentDispatcher;
            _replayTimer.Elapsed += ReplayTimerOnElapsed;
            _replayTimer.Start();
        }

        private void InitSkeletonReplay()
        {
            using (var stream = File.OpenRead(_kinectReplayFile.Path))
            {
                _skeletonReplay = new SkeletonReplay(stream);
                _skeletonReplay.SkeletonFrameReady += OnSkeletonFrameReady;
            }
        }
        #endregion

        private void ReplayTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (MillisecondsPassedSinceLastSkeletonMovment() <= RestartReplayAfterSoManyMilliseconds) return;
            Dispatcher.Invoke(new Action(Start));
        }

        private double MillisecondsPassedSinceLastSkeletonMovment()
        {
            return DateTime.Now.Subtract(_lastTimeReady).TotalMilliseconds;
        }

        /// <summary>
        /// Called when the next skeleton frame is ready.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see>
        ///                       <cref>Kinect.Toolbox.Record.ReplaySkeletonFrameReadyEventArgs</cref>
        ///                     </see> instance containing the event data.</param>
        private void OnSkeletonFrameReady(object sender, ReplaySkeletonFrameReadyEventArgs e)
        {
            _lastTimeReady = DateTime.Now;
            SkeletonsReady(this, new SkeletonsReadyEventArgs(e.SkeletonFrame.Skeletons));
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            Debug.Assert(_skeletonReplay != null, "_skeletonReplay != null");
            _skeletonReplay.Start();
            _lastTimeReady = DateTime.Now;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _replayTimer.Elapsed -= ReplayTimerOnElapsed;
            _replayTimer.Stop();
            _skeletonReplay.SkeletonFrameReady -= OnSkeletonFrameReady;
            _skeletonReplay.Stop();
        }

        /// <summary>
        /// Occurs when the next skeletons frame is ready.
        /// </summary>
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady = delegate { };
    }

}