using System.ComponentModel.Composition;
using System.Windows.Controls;
using Interfaces;
using Views.Xaml;

namespace PosterApp
{
    [Export(typeof(IApp))]
    public class PosterApp : IApp
    {
        public PosterApp()
        {
            Name = "Posters";
            MainView = new PosterView();
            DemomodeText = "Lust etwas zu lernen?";
        }

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }
    }
}
