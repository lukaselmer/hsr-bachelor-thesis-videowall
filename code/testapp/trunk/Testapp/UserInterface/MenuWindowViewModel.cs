using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Services;

namespace UserInterface
{
    public class MenuWindowViewModel : INotifyPropertyChanged
    {
        private bool _isMenuViewVisible;

        public MenuWindowViewModel(MenuService menuService)
        {
            CurrentMenu = menuService.Menu;
        }

        public Menu CurrentMenu { get; set; }

        public bool IsMenuViewVisible
        {
            get
            {
                return _isMenuViewVisible;
            }
            set
            {
                _isMenuViewVisible = value;
                Notify("IsMenuViewVisible");
            }
        }

        //Notify
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
