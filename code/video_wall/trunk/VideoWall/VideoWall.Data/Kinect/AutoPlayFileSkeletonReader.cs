#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.IO;
using System.Windows.Threading;
using Kinect.Toolbox.Record;
using VideoWall.Common;

#endregion

namespace VideoWall.Data.Kinect
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class AutoPlayFileSkeletonReader : ISkeletonReader
    {
        #region Declarations

        private static readonly TimeSpan CheckTimerInterval = TimeSpan.FromMilliseconds(1400);
        private static readonly TimeSpan RestartReplayAfterSoMuchTime = TimeSpan.FromMilliseconds(20000);

        private readonly KinectReplayFile _kinectReplayFile;
        private DateTime _lastTimeReady;
        private DispatcherTimer _replayTimer;
        private SkeletonReplay _skeletonReplay;

        #endregion

        #region Properties

        private Dispatcher Dispatcher { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when the next skeletons frame is ready.
        /// </summary>
        public event EventHandler<SkeletonsReadyEventArgs> SkeletonsReady = delegate { };

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="FileSkeletonReader" /> class.
        /// </summary>
        /// <param name="kinectReplayFile"> The kinect replay file. </param>
        public AutoPlayFileSkeletonReader(KinectReplayFile kinectReplayFile)
        {
            _kinectReplayFile = kinectReplayFile;

            InitReplayTimer();
            InitSkeletonReplay();

            Start();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Starts this instance.
        /// </summary>
        public void Start()
        {
            if (!CanStart()) return;
            PreOrPostCondition.AssertNotNull(_skeletonReplay, "_skeletonReplay");
            _skeletonReplay.Start();
            _lastTimeReady = DateTime.Now;
        }

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _replayTimer.Tick -= ReplayTimerOnElapsed;
            _replayTimer.Stop();
            _skeletonReplay.SkeletonFrameReady -= OnSkeletonFrameReady;
            _skeletonReplay.Stop();
        }

        /// <summary>
        ///   Initializes the replay timer.
        /// </summary>
        private void InitReplayTimer()
        {
            _replayTimer = new DispatcherTimer { Interval = CheckTimerInterval };
            Dispatcher = Dispatcher.CurrentDispatcher;
            _replayTimer.Tick += ReplayTimerOnElapsed;
            _replayTimer.Start();
        }

        /// <summary>
        ///   Inits the skeleton replay.
        /// </summary>
        private void InitSkeletonReplay()
        {
            using (var stream = File.OpenRead(_kinectReplayFile.Path))
            {
                _skeletonReplay = new SkeletonReplay(stream);
                _skeletonReplay.SkeletonFrameReady += OnSkeletonFrameReady;
            }
        }

        /// <summary>
        /// Replays the timer on elapsed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ReplayTimerOnElapsed(object sender, EventArgs eventArgs)
        {
            if (!CanStart()) return;
            Dispatcher.Invoke(new Action(Start));
        }

        /// <summary>
        ///   Determines whether this instance can start.
        /// </summary>
        /// <returns> <c>true</c> if this instance can start; otherwise, <c>false</c> . </returns>
        private bool CanStart()
        {
            return MillisecondsPassedSinceLastSkeletonMovement() >= RestartReplayAfterSoMuchTime;
        }

        /// <summary>
        ///   Millisecondses the passed since last skeleton movement.
        /// </summary>
        /// <returns> </returns>
        private TimeSpan MillisecondsPassedSinceLastSkeletonMovement()
        {
            return DateTime.Now.Subtract(_lastTimeReady);
        }

        /// <summary>
        ///   Called when the next skeleton frame is ready.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see>
        ///                        <cref>Kinect.Toolbox.Record.ReplaySkeletonFrameReadyEventArgs</cref>
        ///                      </see> instance containing the event data. </param>
        private void OnSkeletonFrameReady(object sender, ReplaySkeletonFrameReadyEventArgs e)
        {
            _lastTimeReady = DateTime.Now;
            SkeletonsReady(this, new SkeletonsReadyEventArgs(e.SkeletonFrame.Skeletons));
        }

        #endregion
    }
}