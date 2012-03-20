using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Services;

namespace UserInterface
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(IPostersService postersService)
        {
            Posters = new ListCollectionView(postersService.Posters);
        }

        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ListCollectionView Posters { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
