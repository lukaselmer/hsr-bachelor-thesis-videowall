using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Services
{
    public class LunchMenuService : Notifier
    {
        private LunchMenuReader LunchMenuReader { get; set; }
        private LunchMenu _lunchMenu;

        public LunchMenuService(LunchMenuReader lunchMenuReader)
        {
            LunchMenuReader = lunchMenuReader;
            LunchMenuReader.PropertyChanged += LunchMenuReaderChanged;
            ReadFromLunchMenuReader();
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

        private void ReadFromLunchMenuReader()
        {
            LunchMenu = new LunchMenu(LunchMenuReader.File);
        }

        private void LunchMenuReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuReader();
        }
    }
}
