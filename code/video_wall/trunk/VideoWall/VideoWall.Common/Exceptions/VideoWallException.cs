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

#endregion

namespace VideoWall.Common.Exceptions
{
    /// <summary>
    ///   The videowall exception.
    /// </summary>
    public class VideoWallException : Exception
    {
        public VideoWallException(string message) : base(message)
        {
        }

        public VideoWallException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
