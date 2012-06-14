using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;
using BrowserApp.Data;

namespace BrowserApp.ViewModels
{
    public class BrowserViewModel
    {
        private readonly DispatcherTimer _timer;
        private WebBrowser _browser;
        private readonly List<BrowserContent> _urls;
        private BrowserContent _current;

        public WebBrowser Browser
        {
            get { return _browser; }
            set
            {
                _browser = value;
                RefreshBrowserContent(this, null);
            }
        }

        public BrowserViewModel(BrowserContents browserContent)
        {
            _urls = browserContent.Urls;

            _timer = new DispatcherTimer();
            _timer.Tick += RefreshBrowserContent;

            RefreshBrowserContent(this, null);
        }

        private BrowserContent NextContent()
        {
            if (_current == null) return _urls[0];
            return _urls[(_urls.IndexOf(_current) + 1) % _urls.Count];
        }

        private void RefreshBrowserContent(object sender, EventArgs e)
        {
            if (Browser == null) return;

            _current = NextContent();

            if (_current.Type == BrowserContentType.Url) Browser.Navigate(_current.Content);
            if (_current.Type == BrowserContentType.Html) Browser.NavigateToString(_current.Content);

            _timer.Interval = _current.Duration;
            _timer.Start();
        }
    }
}