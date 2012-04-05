using System.Collections.Generic;
using System.ComponentModel;
using Common;
using Data;

namespace Services
{
    public class PosterService : Notifier
    {
        private List<Poster> _posters;

        private PosterReader PosterReader { get; set; }

        public List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        public PosterService(PosterReader posterReader)
        {
            PosterReader = posterReader;
            PosterReader.PropertyChanged += PosterReaderChanged;
            ReadFromPosterReader();
        }

        private void PosterReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromPosterReader();
        }

        private void ReadFromPosterReader()
        {
            Posters = new List<Poster>();
            foreach (var file in PosterReader.Files)
            {
                Posters.Add(new Poster(file));
            }
        }

    }
}
