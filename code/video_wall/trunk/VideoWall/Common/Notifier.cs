﻿#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Threading;

#endregion

namespace Common
{
    /// <summary>
    ///   Implementation of INotifyPropertyChanged
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class Notifier : INotifyPropertyChanged
    {
        #region Declarations

        /// <summary>
        ///   Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The timer for the notify delay
        /// </summary>
        private DispatcherTimer _timer;

        /// <summary>
        /// The Lock for the notify delay
        /// </summary>
        private readonly object _lock = new object();

        private DateTime _mostRecentNotify;

        private static readonly TimeSpan NotifyDelay = TimeSpan.FromMilliseconds(1);

        #endregion

        #region Other

        private Action _action;

        /// <summary>
        ///   Notifies that the property with the specified name has changed.
        /// </summary>
        /// <param name="propertyName"> Name of the property. </param>
        /// <remarks>
        /// </remarks>
        protected void Notify(string propertyName)
        {
            lock (_lock)
            {
                var interval = DateTime.Now.Subtract(_mostRecentNotify);
                _mostRecentNotify = DateTime.Now;

                // Notify without delay when the last Notify() call was long ago (interval > NotifyDelay)
                if (interval > NotifyDelay) DoNotify(propertyName);

                _action = () => DoNotify(propertyName);

                if (_timer != null) return;

                _timer = new DispatcherTimer { Interval = NotifyDelay };
                _timer.Tick += Tick;
                _timer.Start();
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            lock (_lock)
            {
                _action();
                _action = null;
                _timer.Stop();
                _timer = null;
            }
        }

        private void DoNotify(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///   Notifies that the property with the specified name has changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        protected void Notify(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(sender, e);
        }

        #endregion
    }
}