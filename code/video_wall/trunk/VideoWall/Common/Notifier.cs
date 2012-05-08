#region Header

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

using System.ComponentModel;

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

        #endregion

        #region Other

        /// <summary>
        ///   Notifies that the property with the specified name has changed.
        /// </summary>
        /// <param name="propertyName"> Name of the property. </param>
        /// <remarks>
        /// </remarks>
        protected void Notify(string propertyName)
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