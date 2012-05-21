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
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using VideoWall.ServiceModels.HandCursor;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The Interface of the Cursor View Model
    /// </summary>
    public interface ICursorViewModel : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        ///   Gets the status.
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

        /// <summary>
        ///   Occurs when hand has changed.
        /// </summary>
        event HandChanged HandChanged;
    }
}