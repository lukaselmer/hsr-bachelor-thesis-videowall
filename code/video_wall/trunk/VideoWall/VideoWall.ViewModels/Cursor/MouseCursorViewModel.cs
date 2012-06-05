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
using System.Windows.Media;
using VideoWall.Common.ViewHelpers;
using VideoWall.ResourceLoader;
using VideoWall.ServiceModels.HandCursor.Implementation;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The MouseCursorViewModel. This class is used for the development only.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class can be made abstract, which is wrong.
    public class MouseCursorViewModel : Notifier, ICursorViewModel
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The position of the cursor.
        /// </summary>
        private Point _position;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the position of the cursor.
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
        public ImageSource HandCursorImageSource { get { return ResourceProvider.HandRight.Source; } }

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
        /// <remarks>
        ///   In this model (cursor) this event is never used, but it is in the interface (ICursorViewModel). TODO: refactor this
        /// </remarks>
        public event EventHandler<HandChangedEventArgs> HandChanged;

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseCursorViewModel" /> class.
        /// </summary>
        public MouseCursorViewModel()
        {
            // TODO: why are there numbers?
            WindowWidth = 600;
            WindowHeight = 400;
            Notify("Position");
        }

        #endregion

        #region Methods

        // TODO: why is this unused?

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
