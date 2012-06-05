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
using System.Windows;

#endregion

namespace VideoWall.ViewModels.HitButton
{
    /// <summary>
    ///   The HitStateArgs.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 17.04.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class HitStateArgs : EventArgs
    {
        #region Properties

        /// <summary>
        ///   Gets the UI element.
        /// </summary>
        // ReSharper disable InconsistentNaming
        public UIElement UIElement { get; private set; }

        // ReSharper restore InconsistentNaming

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="HitStateArgs" /> class.
        /// </summary>
        /// <param name="uiElement"> The user interface element. </param>
        public HitStateArgs(UIElement uiElement)
        {
            UIElement = uiElement;
        }

        #endregion
    }
}
