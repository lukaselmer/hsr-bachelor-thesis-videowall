using BrowserApp.ViewModels;

namespace BrowserApp.App
{
    public partial class BrowserUserControl
    {
        internal BrowserUserControl(BrowserViewModel browserViewModel)
        {
            InitializeComponent();
            browserViewModel.Browser = webBrowser;
        }
    }
}