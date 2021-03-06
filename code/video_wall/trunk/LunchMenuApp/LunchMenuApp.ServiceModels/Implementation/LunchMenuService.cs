﻿#region Header

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
using LunchMenuApp.Data.Interfaces;
using LunchMenuApp.ServiceModels.Interfaces;
using VideoWall.Common.Logging;

#endregion

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The lunch menu service.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    public class LunchMenuService : ILunchMenuService
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The lunch menu
        /// </summary>
        private ILunchMenu _lunchMenu;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value> The lunch menu. </value>
        public ILunchMenu LunchMenu
        {
            get { return _lunchMenu; }
            private set
            {
                _lunchMenu = value;
                LunchMenuChanged(this, null);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the lunch menu has changed.
        /// </summary>
        public event EventHandler LunchMenuChanged = delegate { };

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenuService"/> class.
        /// </summary>
        /// <param name="lunchMenuReader">The lunch menu reader.</param>
        /// <param name="lunchMenuParser">The lunch menu parser.</param>
        public LunchMenuService(ILunchMenuReader lunchMenuReader, ILunchMenuParser lunchMenuParser)
        {
            try
            {
                LunchMenu = new LunchMenu(lunchMenuReader.Html, lunchMenuParser);
            }
            catch (LunchMenuUnparsableException exception)
            {
                Logger.Get.Warn("Lunch menu unparsable", exception);
                LunchMenu = null;
            }
        }

        #endregion
    }
}
