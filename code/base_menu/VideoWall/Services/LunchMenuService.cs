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
        //private LunchMenu 

        public LunchMenuService(LunchMenuReader lunchMenuReader)
        {
            LunchMenuReader = lunchMenuReader;
            LunchMenuReader.PropertyChanged += LunchMenuReaderChanged;
            ReadFromLunchMenuReader();
        }

        private void ReadFromLunchMenuReader()
        {
            throw new NotImplementedException();
        }

        private void LunchMenuReaderChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuReader();
        }
    }
}
