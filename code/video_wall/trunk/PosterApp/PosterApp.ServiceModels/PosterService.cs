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
using PosterApp.Data;

#endregion

namespace PosterApp.ServiceModels
{
    /// <summary>
    ///   The PosterService
    /// </summary>
    public class PosterService
    {
        #region Properties

        private PosterReader PosterReader { get; set; }

        /// <summary>
        ///   Gets or sets and notifies the posters.
        /// </summary>
        /// <value> The posters. </value>
        public List<Poster> Posters { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterService" /> class.
        /// </summary>
        /// <param name="posterReader"> The poster reader. </param>
        public PosterService(PosterReader posterReader)
        {
            PosterReader = posterReader;
            ReadFromPosterReader();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Reads from poster reader.
        /// </summary>
        private void ReadFromPosterReader()
        {
            Posters = new List<Poster>();
            foreach (var file in PosterReader.Files)
            {
                Posters.Add(new Poster(file));
            }
        }

        #endregion
    }
}
