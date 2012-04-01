using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Common;
using Services;

namespace ViewModels
{
    public class LunchMenuViewModel : Notifier
    {
        public LunchMenuViewModel(ILunchMenu lunchMenu)
        {
            LunchMenu = lunchMenu;
            LunchMenu.PropertyChanged += LunchMenuChanged;
            IsLunchMenuVisible = false;
            ShowLunchMenuViewCommand = new Command(OnShowLunchMenuView);
        }

        private bool _isLunchMenuVisible;

        public ILunchMenu LunchMenu { get; set; }

        public String Name { get { return LunchMenu.Name; } }

        public bool IsLunchMenuVisible
        {
            get { return _isLunchMenuVisible; }
            set
            {
                _isLunchMenuVisible = value;
                Notify("IsLunchMenuVisible");
            }
        }

        public Command ShowLunchMenuViewCommand { get; set; }

        private void OnShowLunchMenuView(object obj)
        {
            IsLunchMenuVisible = true;
        }

        private void LunchMenuChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Name");
        }
    }
}
