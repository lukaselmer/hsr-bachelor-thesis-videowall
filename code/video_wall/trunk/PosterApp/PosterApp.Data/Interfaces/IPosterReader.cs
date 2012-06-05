using System.Collections.Generic;

namespace PosterApp.Data.Interfaces
{
    /// <summary>
    /// The poster reader provides the data for the posters.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IPosterReader
    {
        /// <summary>
        ///   Gets the files.
        /// </summary>
        IEnumerable<string> Files { get; }
    }
}