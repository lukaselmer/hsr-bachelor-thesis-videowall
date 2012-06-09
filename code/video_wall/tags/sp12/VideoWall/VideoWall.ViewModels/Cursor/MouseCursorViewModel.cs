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

using System.Windows;
using System.Windows.Media;
using VideoWall.Common;
using VideoWall.ResourceLoader;
using VideoWall.ServiceModels.HandCursor;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The MouseCursorViewModel.
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    public class MouseCursorViewModel : Notifier, ICursorViewModel
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private Point _position;

        #endregion

        #region Properties

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

        /// <summary>
        ///   Gets the hand cursor image source (for left or right hand).
        /// </summary>
        public ImageSource HandCursorImageSource
        {
            get { return ResourceProvider.HandRight.Source; }
        }

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

        #region Events

        /// <summary>
        ///   Occurs when hand has changed.
        /// </summary>
        public event HandChanged HandChanged;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseCursorViewModel" /> class.
        /// </summary>
        public MouseCursorViewModel()
        {
            WindowWidth = 600;
            WindowHeight = 400;
            Notify("Position");
        }

        #endregion

        #region ICursorViewModel Members

        /// <summary>
        ///   Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            //TODO
        }

        #endregion

        #region Methods


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

        #endregion
    }
}
