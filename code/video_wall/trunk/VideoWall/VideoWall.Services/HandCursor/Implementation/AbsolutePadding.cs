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
using VideoWall.Common.Helpers;

#endregion

namespace VideoWall.ServiceModels.HandCursor.Implementation
{
    /// <summary>
    ///   The absolute padding.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 17.04.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class AbsolutePadding
    {
        #region Declarations

        /// <summary>
        /// The relative padding
        /// </summary>
        private readonly RelativePadding _relative;

        /// <summary>
        /// The window size
        /// </summary>
        private readonly Size _window;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the left padding.
        /// </summary>
        internal double Left { get { return _window.Width * _relative.Left; } }

        /// <summary>
        /// Gets the right padding.
        /// </summary>
        internal double Right { get { return _window.Width * _relative.Right; } }

        /// <summary>
        /// Gets the top padding.
        /// </summary>
        internal double Top { get { return _window.Height * _relative.Top; } }

        /// <summary>
        /// Gets the bottom padding.
        /// </summary>
        internal double Bottom { get { return _window.Height * _relative.Bottom; } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AbsolutePadding"/> class.
        /// </summary>
        /// <param name="relative">The relative.</param>
        /// <param name="window">The window.</param>
        internal AbsolutePadding(RelativePadding relative, Size window)
        {
            _relative = relative;
            _window = window;

            PreOrPostCondition.AssertTrue(relative != null, "relative != null");
        }

        #endregion
    }
}
