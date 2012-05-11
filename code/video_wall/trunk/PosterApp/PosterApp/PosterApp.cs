using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Interfaces;
using Views.Xaml;

namespace PosterApp
{
    [Export(typeof(IApp))]
    class PosterApp : IApp
    {
        public PosterApp()
        {
            Name = "Posters";
            MainView = new PosterView();
        }

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
    }
}
