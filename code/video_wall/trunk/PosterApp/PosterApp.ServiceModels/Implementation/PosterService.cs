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
using System.Linq;
using PosterApp.Data.Interfaces;
using PosterApp.ServiceModels.Interfaces;

#endregion

namespace PosterApp.ServiceModels.Implementation
{
    /// <summary>
    ///   The poster service.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    public class PosterService : IPosterService
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        /// <summary>
        /// Gets or sets the poster reader.
        /// </summary>
        /// <value>
        /// The poster reader.
        /// </value>
        private readonly IPosterReader _posterReader;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets and notifies the posters.
        /// </summary>
        /// <value> The posters. </value>
        public IEnumerable<IPoster> Posters { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterService" /> class.
        /// </summary>
        /// <param name="posterReader"> The poster reader. </param>
        public PosterService(IPosterReader posterReader)
        {
            _posterReader = posterReader;
            ReadFromPosterReader();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Reads from poster reader.
        /// </summary>
        private void ReadFromPosterReader()
        {
            Posters = _posterReader.Files.Select(file => new Poster(file));
        }

        #endregion
    }
}
