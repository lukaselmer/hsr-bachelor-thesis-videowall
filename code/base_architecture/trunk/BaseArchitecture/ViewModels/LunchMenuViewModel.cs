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
        }

        private bool _isLunchMenuViewVisible;

        public ILunchMenu LunchMenu { get; set; }

        public String Name { get { return LunchMenu.Name; } }

        public bool IsLunchMenuViewVisible
        {
            get { return _isLunchMenuViewVisible; }
            set
            {
                _isLunchMenuViewVisible = value;
                Notify("IsLunchMenuViewVisible");
            }
        }

        private void LunchMenuChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Name");
        }
    }
}
