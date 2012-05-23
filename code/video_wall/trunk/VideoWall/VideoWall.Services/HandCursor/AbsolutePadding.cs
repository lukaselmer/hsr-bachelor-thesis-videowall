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

using System.Diagnostics;
using System.Windows;
using VideoWall.Common;

#endregion

namespace VideoWall.ServiceModels.HandCursor
{
    /// <summary>
    ///   The absolute padding. Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    internal class AbsolutePadding
    {
        #region Declarations

        private readonly RelativePadding _relative;
        private readonly Size _window;

        #endregion

        #region Properties

        internal double Left { get { return _window.Width * _relative.Left; } }
        internal double Right { get { return _window.Width * _relative.Right; } }
        internal double Top { get { return _window.Height * _relative.Top; } }
        internal double Bottom { get { return _window.Height * _relative.Bottom; } }

        #endregion

        #region Constructors / Destructor

        internal AbsolutePadding(RelativePadding relative, Size window)
        {
            _relative = relative;
            _window = window;

            PreOrPostCondition.AssertTrue(relative != null, "relative != null");
        }

        #endregion
    }
}