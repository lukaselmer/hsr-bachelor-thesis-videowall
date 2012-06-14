using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BrowserApp.ViewModels
{
    public class BrowserViewModel
    {
        private readonly DispatcherTimer _timer;
        private WebBrowser _browser;
        private const string Url = "http://prezi.com/embed/jiu425sue2ni/?internal=1&bgcolor=ffffff&lock_to_path=0&autoplay=autostart&autohide_ctrls=1";

        public WebBrowser Browser
        {
            get { return _browser; }
            set
            {
                _browser = value;
                RefreshBrowserContent(this, null);
            }
        }

        private void RefreshBrowserContent(object sender, EventArgs e)
        {
            if (Browser == null) return;

            Browser.Navigate(Url);
            SupressScriptErrors();
        }

        /// <summary>
        /// Hack to supress javascript errors
        /// </summary>
        private void SupressScriptErrors()
        {
            var fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            var objComWebBrowser = fiComWebBrowser.GetValue(Browser);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { true });
        }
    }
}