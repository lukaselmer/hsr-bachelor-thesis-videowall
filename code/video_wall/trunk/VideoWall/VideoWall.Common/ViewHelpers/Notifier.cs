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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Threading;

#endregion

namespace VideoWall.Common
{
    /// <summary>
    ///   Implementation of INotifyPropertyChanged
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class Notifier : INotifyPropertyChanged
    {

        #region Events

        /// <summary>
        ///   Occurs when a property value changes.
        /// </summary>
        /// <remarks>
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        ///   Notifies that the property with the specified name has changed.
        /// </summary>
        /// <param name="propertyName"> Name of the property. </param>
        /// <remarks>
        /// </remarks>
        protected void Notify(string propertyName)
        {
            Notify(this, new PropertyChangedEventArgs(propertyName));
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
