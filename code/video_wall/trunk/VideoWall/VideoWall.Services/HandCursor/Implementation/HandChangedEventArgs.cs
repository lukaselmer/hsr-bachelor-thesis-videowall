using System;

namespace VideoWall.ServiceModels.HandCursor.Implementation
{
    /// <summary>
    /// Hand changed event args
    /// </summary>
    public class HandChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the type of the hand.
        /// </summary>
        /// <value>
        /// The type of the hand.
        /// </value>
        public HandType HandType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandChangedEventArgs"/> class.
        /// </summary>
        /// <param name="handType">Type of the hand.</param>
        public HandChangedEventArgs(HandType handType)
        {
            HandType = handType;
        }
    }
}