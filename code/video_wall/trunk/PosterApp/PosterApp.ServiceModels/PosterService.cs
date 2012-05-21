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
using System.ComponentModel;
using PosterApp.Data;
using VideoWall.Common;

#endregion

namespace PosterApp.ServiceModels
{
    /// <summary>
    ///   The PosterService
    /// </summary>
    public class PosterService : Notifier
    {
        #region Declarations

        private List<Poster> _posters;

        #endregion

        #region Properties

        private PosterReader PosterReader { get; set; }

        /// <summary>
        ///   Gets or sets and notifies the posters.
        /// </summary>
        /// <value> The posters. </value>
        public List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterService" /> class.
        /// </summary>
        /// <param name="posterReader"> The poster reader. </param>
        public PosterService(PosterReader posterReader)
        {
            PosterReader = posterReader;
            PosterReader.PropertyChanged += PosterReaderChanged;
            ReadFromPosterReader();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Calls ReadFromPosterReader when PosterReader was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void PosterReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromPosterReader();
        }

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
