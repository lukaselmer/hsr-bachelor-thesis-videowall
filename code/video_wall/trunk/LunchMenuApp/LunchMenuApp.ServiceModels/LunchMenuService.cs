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

namespace ServiceModels
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
            LunchMenu = new LunchMenu(LunchMenuReader.Html);
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
    }
}