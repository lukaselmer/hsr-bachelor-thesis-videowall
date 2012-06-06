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
using VideoWall.Common.Helpers;
using VideoWall.Data.Kinect.Interfaces;

#endregion

namespace VideoWall.Data.Kinect.Implementation
{
    /// <summary>
    ///    This class is used for the development only.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class AutoPlayFileSkeletonReader : ISkeletonReader
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        /// <summary>
        /// The interval in which the replay timer check if the replay should be restarted.
        /// </summary>
        private static readonly TimeSpan CheckTimerInterval = TimeSpan.FromMilliseconds(1400);

        /// <summary>
        /// The interval the replay is restarted after which no skeleton was tracked.
        /// </summary>
        private static readonly TimeSpan RestartReplayAfterSoMuchTime = TimeSpan.FromMilliseconds(20000);

        /// <summary>
        /// The kinect replay file
        /// </summary>
        private readonly KinectReplayFile _kinectReplayFile;

        /// <summary>
        /// The last time the replay was started / restarted.
        /// </summary>
        private DateTime _lastTimeReady;

        /// <summary>
        /// The replay timer.
        /// </summary>
        private DispatcherTimer _replayTimer;

        /// <summary>
        /// The skeleton replay.
        /// </summary>
        private SkeletonReplay _skeletonReplay;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the dispatcher.
        /// </summary>
        /// <value>
        /// The dispatcher.
        /// </value>
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
        ///   Replays the timer on elapsed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="eventArgs"> The <see cref="System.EventArgs" /> instance containing the event data. </param>
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
