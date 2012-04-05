using System;
using System.ComponentModel;
using Common;
using Services;

namespace ViewModels
{
    public class LunchMenuViewModel : Notifier, IDisposable
    {
        private LunchMenu _lunchMenu;
        private bool _isLunchMenuViewVisible;
        private string _name;
        private LunchMenuService _lunchMenuService;

        public LunchMenuViewModel(LunchMenuService lunchMenuService)
        {
            _lunchMenuService = lunchMenuService;
            _lunchMenuService.PropertyChanged += LunchMenuServiceChanged;
            ReadFromLunchMenuService();
            Name = "Mittagsmenü";
        }

        private void LunchMenuServiceChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuService();
        }

        private void ReadFromLunchMenuService()
        {
            LunchMenu = _lunchMenuService.LunchMenu;
        }

        public LunchMenu LunchMenu
        {
            get { return _lunchMenu; }
            set
            {
                _lunchMenu = value;
                Notify("LunchMenu");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        public bool IsLunchMenuViewVisible
        {
            get { return _isLunchMenuViewVisible; }
            set
            {
                _isLunchMenuViewVisible = value;
                Notify("IsLunchMenuViewVisible");
            }
        }

        public void Dispose()
        {
            _lunchMenuService.PropertyChanged -= LunchMenuServiceChanged;
        }
    }
}
