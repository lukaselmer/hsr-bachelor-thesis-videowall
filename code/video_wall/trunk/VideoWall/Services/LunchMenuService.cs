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
using Common;
using Data;

#endregion

namespace Services
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuService : Notifier
    {
        private LunchMenu _lunchMenu;

        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuService" /> class.
        /// </summary>
        /// <param name="lunchMenuReader"> The lunch menu reader. </param>
        public LunchMenuService(LunchMenuReader lunchMenuReader)
        {
            LunchMenuReader = lunchMenuReader;
            LunchMenuReader.PropertyChanged += LunchMenuReaderChanged;
            ReadFromLunchMenuReader();
        }

        private LunchMenuReader LunchMenuReader { get; set; }

        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        public LunchMenu LunchMenu
        {
            get { return _lunchMenu; }
            set
            {
                _lunchMenu = value;
                Notify("LunchMenu");
            }
        }

        /// <summary>
        ///   Reads from lunch menu reader.
        /// </summary>
        private void ReadFromLunchMenuReader()
        {
            LunchMenu = new LunchMenu(LunchMenuReader.File);
        }

        /// <summary>
        ///   Calls ReadFromLunchMenuReader when LunchMenuReader was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void LunchMenuReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuReader();
        }
    }
}