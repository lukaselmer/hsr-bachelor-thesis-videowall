using System.ComponentModel.Composition;
using System.IO;
using System.Windows.Controls;
using VideoWall.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Views.Xaml;

namespace PosterApp.Main
{
    [Export(typeof(IApp))]
    public class PosterApp : IApp
    {
        public PosterApp()
        {
            Name = "Posters";
            DemomodeText = "Lust etwas zu lernen?";
        }

        public void Activate(IVideoWallServiceProvider serviceProvider)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(serviceProvider);
            MainView = unityContainer.Resolve<PosterView>();
        }

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }
    }
}
