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

namespace VideoWall.ServiceModels.HandCursor.Implementation
{
    /// <summary>
    ///   Hand changed event args
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public class HandChangedEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="HandChangedEventArgs" /> class.
        /// </summary>
        /// <param name="handType"> Type of the hand. </param>
        public HandChangedEventArgs(HandType handType)
        {
            HandType = handType;
        }

        /// <summary>
        ///   Gets the type of the hand.
        /// </summary>
        /// <value> The type of the hand. </value>
        public HandType HandType { get; private set; }
    }
}
