using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Services
{
    class Poster : Notifier, IPoster
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        public Poster(PosterReader posterReader)
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
            Name = PosterReader.ReadPoster();
        }

        protected PosterReader PosterReader { get; set; }
    }
}
