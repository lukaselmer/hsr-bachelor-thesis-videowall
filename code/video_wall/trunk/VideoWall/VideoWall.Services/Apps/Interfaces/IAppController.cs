using System.Collections.Generic;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Apps.Interfaces
{
    /// <summary>
    /// The app controller interface.
    /// </summary>
    public interface IAppController
    {
        /// <summary>
        ///   The video wall applications.
        /// </summary>
        IEnumerable<IApp> Apps { get; }
    }
}