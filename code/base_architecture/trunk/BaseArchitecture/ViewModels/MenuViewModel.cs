using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel(PosterViewModel posterViewModel, LunchMenuViewModel lunchMenuViewModel)
        {
            PosterViewModel = posterViewModel;
            LunchMenuViewModel = lunchMenuViewModel;
            ShowPosterViewCommand = new Command(OnShowPosterView);
            ShowLunchMenuViewCommand = new Command(OnShowLunchMenuView);
            OnShowPosterView(null);
        }

        public PosterViewModel PosterViewModel { get; set; }
        public LunchMenuViewModel LunchMenuViewModel { get; set; }

        private void OnShowPosterView(object obj)
        {
            LunchMenuViewModel.IsLunchMenuViewVisible = false;
            PosterViewModel.IsPosterViewVisible = true;
        }

        private void OnShowLunchMenuView(object obj)
        {
            PosterViewModel.IsPosterViewVisible = false;
            LunchMenuViewModel.IsLunchMenuViewVisible = true;
        }
        public ICommand ShowLunchMenuViewCommand { get; set; }

        public ICommand ShowPosterViewCommand { get; set; }
    }
}
