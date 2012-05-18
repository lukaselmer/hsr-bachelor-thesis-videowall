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

using System;
using System.Windows;

#endregion

namespace VideoWall.ViewModels.HitButton
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class HitStateArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="HitStateArgs" /> class.
        /// </summary>
        /// <param name="uiElement"> The user interface element. </param>
        public HitStateArgs(UIElement uiElement)
        {
            UIElement = uiElement;
        }

        /// <summary>
        ///   Gets the UI element.
        /// </summary>
        public UIElement UIElement { get; private set; }
    }
}