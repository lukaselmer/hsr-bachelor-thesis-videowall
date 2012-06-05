using System;

namespace LunchMenuApp.ServiceModels.Implementation
{
    /// <summary>
    /// If the lunch menu is not parsable, this exception is thrown.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    internal class LunchMenuUnparsableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenuUnparsableException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public LunchMenuUnparsableException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}