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
using VideoWall.Common.ViewHelpers;
using VideoWall.ResourceLoader;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The mouse cursor view model. This class is used for the development only.
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
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        // This property is never used, but it is defined by the interface and tough has to be implemented.
        // But it is not important because this class is used for development only.
        public double WindowWidth { private get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Local

        /// <summary>
        ///   Sets the height of the window.
        /// </summary>
        /// <value> The height of the window. </value>
        // ReSharper disable UnusedAutoPropertyAccessor.Local
        // This property is never used, but it is defined by the interface and tough has to be implemented.
        // But it is not important because this class is used for development only.
        public double WindowHeight { private get; set; }
        // ReSharper restore UnusedAutoPropertyAccessor.Local

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseCursorViewModel" /> class.
        /// </summary>
        public MouseCursorViewModel()
        {
            Notify("Position");
        }

        #endregion
    }
}
