using System.Windows.Controls;
using BrowserApp.ViewModels;
using VideoWall.Interfaces;
using System.ComponentModel.Composition;

namespace BrowserApp.App
{
    [Export(typeof(IApp))]
    public class BrowserAppImpl : IApp
    {
        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }

        public BrowserAppImpl()
        {
            MainView = new BrowserUserControl(new BrowserViewModel());
            Name = "Präsentation";
            DemomodeText = "Neugierig?";
        }

        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
        }
    }
}