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

using System.Windows.Threading;

#endregion

namespace VideoWall.ServiceModels.DemoMode
{
    // TODO: Instead of extension methods, wrap the dispatcher timer (adapter)

    /// <summary>
    ///   The extensions for the dispatcher timer
    /// </summary>
    public static class DispatcherTimerExtension
    {
        /// <summary>
        ///   Resets the specified timer.
        /// </summary>
        /// <param name="timer"> The timer. </param>
        public static void Reset(this DispatcherTimer timer)
        {
            timer.Stop();
            timer.Start();
        }

        /// <summary>
        ///   Gets the interval seconds.
        /// </summary>
        /// <param name="timer"> The timer. </param>
        /// <returns> The interval in seconds.  </returns>
        public static int GetIntervalSeconds(this DispatcherTimer timer)
        {
            return timer.Interval.Seconds;
        }
    }
}