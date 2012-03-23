using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Common;
using Services;

namespace ViewModels
{
    public class PosterViewModel : Notifier, IDisposable
    {
        public PosterViewModel(IPoster poster)
        {
            Poster = poster;
            Poster.PropertyChanged += PosterChanged;
        }

        private void PosterChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Name");
            Notify("Color");
        }

        protected IPoster Poster { get; set; }

        public string Name { get { return Poster.Name; } }
        public Color Color
        {
            get
            {
                return Name.ToLower().StartsWith("a") ? Colors.Red : Colors.Green;
            }
        }

        public void ChangeName()
        {
            Poster.Name = "Hi! <3";
        }

        public void Dispose()
        {
            Poster.PropertyChanged -= PosterChanged;
        }
    }
}
