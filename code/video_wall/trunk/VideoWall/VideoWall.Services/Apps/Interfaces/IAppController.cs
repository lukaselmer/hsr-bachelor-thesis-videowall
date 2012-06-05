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

using System.Collections.Generic;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Apps.Interfaces
{
    /// <summary>
    ///   The app controller interface.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public interface IAppController
    {
        #region Properties

        /// <summary>
        ///   The video wall applications.
        /// </summary>
        IEnumerable<IApp> Apps { get; }

        #endregion
    }
}
