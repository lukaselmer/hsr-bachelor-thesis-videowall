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
    /// The video wall exception occurs if something goes wrong which is video wall specific.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class VideoWallException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWallException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public VideoWallException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoWallException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public VideoWallException(string message, Exception innerException) : base(message, innerException) { }
    }
}
