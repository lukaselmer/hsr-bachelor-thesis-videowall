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

using System.Windows;
using Common;
using Services.HandCursor;

#endregion

namespace ViewModels
{
    /// <summary>
    ///   The Mouse Cursor View Model
    /// </summary>
    public class MouseCursorViewModel : Notifier, ICursorViewModel
    {
        #region Properties

        private Point _position;

        /// <summary>
        ///   Gets the status.
        /// </summary>
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Notify("Position");
            }
        }

        public event HandChanged HandChanged;

        /// <summary>
        ///   Sets the width of the window.
        /// </summary>
        /// <value> The width of the window. </value>
        public double WindowWidth { get; set; }

        /// <summary>
        ///   Sets the height of the window.
        /// </summary>
        /// <value> The height of the window. </value>
        public double WindowHeight { get; set; }

        #endregion

        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseCursorViewModel" /> class.
        /// </summary>
        public MouseCursorViewModel()
        {
            WindowWidth = 600;
            WindowHeight = 400;
            Notify("Position");
        }

        #region ICursorViewModel Members

        /// <summary>
        ///   Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        /// <summary>
        ///   Notifies when the window size is changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.Windows.SizeChangedEventArgs" /> instance containing the event data. </param>
        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }
    }
}