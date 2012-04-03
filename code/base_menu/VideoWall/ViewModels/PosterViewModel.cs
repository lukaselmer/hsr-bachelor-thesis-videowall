using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Common;
using Services;

namespace ViewModels
{
    public class PosterViewModel : Notifier
    {

        private List<Poster> _posters;
        private bool _isPosterViewVisible;
        private Poster _currentPoster;
        private string _name;

        public PosterViewModel(IPosterService posterService)
        {
            Posters = posterService.Posters;
            CurrentPoster = Posters.First();
            Name = "Poster";
            NavigateToLeftCommand = new Command(OnNavigateToLeft);
            NavigateToRightCommand = new Command(OnNavigateToRight);
        }

        private void OnNavigateToRight(object obj)
        {
            int index = _posters.IndexOf(CurrentPoster) + 1;
            CurrentPoster = index >= _posters.Count ? _posters.First() : _posters[index];
        }

        private void OnNavigateToLeft(object obj)
        {
            int index = _posters.IndexOf(CurrentPoster) - 1;
            CurrentPoster = index < 0 ? _posters.Last() : _posters[index];
        }

        public ICommand NavigateToLeftCommand { get; set; }
        public ICommand NavigateToRightCommand { get; set; }

        public Poster CurrentPoster
        {
            get { return _currentPoster; }
            set
            {
                _currentPoster = value;
                Notify("CurrentPoster");
            }
        }

        public List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        public bool IsPosterViewVisible
        {
            get { return _isPosterViewVisible; }
            set
            {
                _isPosterViewVisible = value;
                Notify("IsPosterViewVisible");
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
    }
}
