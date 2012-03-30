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

        public ILunchMenu LunchMenu { get; set; }

        public String Name { get { return LunchMenu.Name; } }

        private void LunchMenuChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Name");
        }
    }
}
