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

using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The Interface of the Cursor View Model.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface ICursorViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///   Gets the position.
        /// </summary>
        Point Position { get; }

        /// <summary>
        ///   Sets the width of the window.
        /// </summary>
        /// <value> The width of the window. </value>
        double WindowWidth { set; }

        /// <summary>
        ///   Sets the height of the window.
        /// </summary>
        /// <value> The height of the window. </value>
        double WindowHeight { set; }

        /// <summary>
        ///   Gets the hand cursor image source.
        /// </summary>
        ImageSource HandCursorImageSource { get; }
    }
}
