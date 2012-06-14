using System.Windows.Controls;
using BrowserApp.Data;
using BrowserApp.ViewModels;
using VideoWall.Interfaces;

namespace BrowserApp.App
{
    public class BrowserAppImpl : IApp
    {
        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }

        public BrowserAppImpl()
        {
            MainView = new BrowserUserControl(new BrowserViewModel(new BrowserContents()));
            Name = "Browser";
            DemomodeText = "Kommunikativ?";
        }

        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
        }
    }
}