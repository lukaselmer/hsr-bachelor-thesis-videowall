using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Common;
using Data;

namespace Services
{
    public interface IPosterService
    {
        List<Poster> Posters { get; set; }
    }

    class PosterService : Notifier, IPosterService
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
            Posters = new List<Poster>();
            PosterReader.PropertyChanged += PosterReaderChanged;
            ReadFromPosterReader();
        }

        private void PosterReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromPosterReader();
        }

        private void ReadFromPosterReader()
        {
            foreach (var file in PosterReader.Files)
            {
                _posters.Add(new Poster(file));
            }
        }

    }
}
