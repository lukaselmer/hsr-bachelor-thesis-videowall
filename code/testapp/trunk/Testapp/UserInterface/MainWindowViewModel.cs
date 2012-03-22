using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using Services;

namespace UserInterface
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //Declarations
        private IPoster _currentPoster;
        private IList<IPoster> _posters;
        private bool _isMenuViewVisible;

        //Constructor
        public MainWindowViewModel(IPostersService postersService)
        {
            _posters = postersService.Posters;
            CurrentPoster = _posters.First();
            NavigateToLeftCommand = new Command(OnNavigateToLeft);
            NavigateToRightCommand = new Command(OnNavigateToRight);
            ShowMenu = new Command(OnShowMenu);
            ShowPosters = new Command(OnShowPosters);
        }

        public bool IsMenuViewVisible
        {
            get { return _isMenuViewVisible; }
            set 
            {
                _isMenuViewVisible = value;
                Notify("IsMenuViewVisible");
            }
        }

        private void OnShowMenu(object obj)
        {
            IsMenuViewVisible = true;
        }

        private void OnShowPosters(object obj)
        {
            IsMenuViewVisible = false;
        }


        //Notify
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        //Properties
       public IPoster CurrentPoster
        {
            get { return _currentPoster; }
            private set 
            { 
                _currentPoster = value;
                Notify("CurrentPoster");
            }
        }

        //Commands
        public ICommand NavigateToLeftCommand { get; private set; } 
        public ICommand NavigateToRightCommand { get; private set; }
        public ICommand ShowMenu { get; private set; }
        public ICommand ShowPosters { get; private set; }


        private void OnNavigateToLeft(object obj)
        {
            int index = _posters.IndexOf(CurrentPoster) - 1;
            CurrentPoster = index < 0 ? _posters.Last() : _posters[index];
            Notify("CurrentPoster");
        }
        private void OnNavigateToRight(object obj)
        {
            int index = _posters.IndexOf(CurrentPoster) + 1;
            CurrentPoster = index >= _posters.Count ? _posters.First() : _posters[index];
            Notify("CurrentPoster");
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Windows.Data;
//using System.Windows.Input;
//using Services;
//
//namespace UserInterface
//{
//    public class MainWindowViewModel : INotifyPropertyChanged
//    {
//        //Declarations
//        private bool _isMenuViewVisible;
//
//        //Constructor
//        public MainWindowViewModel(MenuService menuService)
//        {
//            CurrentPoster = menuService.Menu;
//            ShowMenu = new Command(OnShowMenu);
//            ShowPosters = new Command(OnShowPosters);
//        }
//
//        public bool IsMenuViewVisible
//        {
//            get { return _isMenuViewVisible; }
//            set 
//            {
//                _isMenuViewVisible = value;
//                Notify("IsMenuViewVisible");
//            }
//        }
//
//        private void OnShowMenu(object obj)
//        {
//            IsMenuViewVisible = true;
//        }
//
//        private void OnShowPosters(object obj)
//        {
//            IsMenuViewVisible = false;
//        }
//
//
//        //Notify
//        public event PropertyChangedEventHandler PropertyChanged;
//        private void Notify(string propertyName)
//        {
//            if (PropertyChanged != null)
//                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
//        }
//
//
//        //Properties
//        public Menu CurrentPoster { get; private set; }
//
//        //Commands
//        public ICommand ShowMenu { get; private set; }
//        public ICommand ShowPosters { get; private set; }
//       
//    }
//}
