using System.Collections.Generic;
using System.ComponentModel;
using Common;
using Data;

namespace Services
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class PosterService : Notifier
    {
        private List<Poster> _posters;
        private PosterReader PosterReader { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PosterService"/> class.
        /// </summary>
        /// <param name="posterReader">The poster reader.</param>
        public PosterService(PosterReader posterReader)
        {
            PosterReader = posterReader;
            PosterReader.PropertyChanged += PosterReaderChanged;
            ReadFromPosterReader();
        }

        /// <summary>
        /// Gets or sets the posters.
        /// </summary>
        /// <value>
        /// The posters.
        /// </value>
        public List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        /// <summary>
        /// Reads from poster reader.
        /// </summary>
        private void ReadFromPosterReader()
        {
            Posters = new List<Poster>();
            foreach (var file in PosterReader.Files)
            {
                Posters.Add(new Poster(file));
            }
        }

        /// <summary>
        /// Calls ReadFromPosterReader when PosterReader was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void PosterReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromPosterReader();
        }
    }
}
