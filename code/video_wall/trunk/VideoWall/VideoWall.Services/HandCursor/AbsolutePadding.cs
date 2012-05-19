﻿#region Header

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

using System.Diagnostics;
using System.Windows;

#endregion

namespace VideoWall.ServiceModels.HandCursor
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    internal class AbsolutePadding
    {
        private readonly RelativePadding _relative;
        private readonly Size _window;

        public AbsolutePadding(RelativePadding relative, Size window)
        {
            _relative = relative;
            _window = window;

            Debug.Assert(relative != null, "relative != null");
            Debug.Assert(window != null, "window != null");
        }

        public double Left { get { return _window.Width*_relative.Left; } }
        public double Right { get { return _window.Width*_relative.Right; } }
        public double Top { get { return _window.Height*_relative.Top; } }
        public double Bottom { get { return _window.Height*_relative.Bottom; } }
    }
}