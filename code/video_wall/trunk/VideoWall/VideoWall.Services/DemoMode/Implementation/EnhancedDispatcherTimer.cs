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
using System.Windows.Threading;
using VideoWall.Common.Helpers;

#endregion

namespace VideoWall.ServiceModels.DemoMode.Implementation
{
    /// <summary>
    ///   An enhanced dispatcher timer which wraps the dispatcher timer.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class EnhancedDispatcherTimer
    {
        #region Declarations

        /// <summary>
        ///   The dispatcher timer
        /// </summary>
        private readonly DispatcherTimer _timer;

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="EnhancedDispatcherTimer" /> class.
        /// </summary>
        /// <param name="eventHandler"> The event handler. </param>
        /// <param name="toDemoModeTimeSpan"> To demo mode time span. </param>
        /// <param name="started"> if set to <c>true</c> the timer is started. </param>
        public EnhancedDispatcherTimer(EventHandler eventHandler, TimeSpan toDemoModeTimeSpan, bool started = false)
        {
            PreOrPostCondition.AssertNotNull(eventHandler, "eventHandler");
            PreOrPostCondition.AssertNotNull(toDemoModeTimeSpan, "toDemoModeTimeSpan");

            _timer = new DispatcherTimer { Interval = toDemoModeTimeSpan };
            _timer.Tick += eventHandler;
            if (started) _timer.Start(); // TODO: stop the timer?
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Starts this instance.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        ///   Stops this instance.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }

        #endregion
    }
}
