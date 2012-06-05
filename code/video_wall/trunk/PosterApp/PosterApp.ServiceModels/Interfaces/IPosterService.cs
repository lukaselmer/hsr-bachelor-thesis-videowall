using System.Collections.Generic;

namespace PosterApp.ServiceModels.Interfaces
{
    /// <summary>
    /// The poster service interface.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IPosterService
    {
        /// <summary>
        ///   Gets or sets and notifies the posters.
        /// </summary>
        /// <value> The posters. </value>
        IEnumerable<IPoster> Posters { get; }
    }
}