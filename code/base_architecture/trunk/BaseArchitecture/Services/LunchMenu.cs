using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Common;
using Data;

namespace Services
{
    class LunchMenu : Notifier, ILunchMenu
    {
        private string _name;

        public string Name {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        protected LunchMenuReader LunchMenuReader { get; set; }

        public LunchMenu(LunchMenuReader lunchMenuReader)
        {
            LunchMenuReader = lunchMenuReader;
            LunchMenuReader.PropertyChanged += LunchMenuReaderChanged;
            ReadFromLunchMenuReader();
        }

        private void LunchMenuReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuReader();
        }

        private void ReadFromLunchMenuReader()
        {
            Name = LunchMenuReader.ReadMenu();
        }
    }
}
