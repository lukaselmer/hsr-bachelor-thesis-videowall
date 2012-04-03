using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PosterViewModel posterViewModel, LunchMenuViewModel lunchMenuViewModel, PlayerViewModel playerViewModel)
        {
            PosterViewModel = posterViewModel;
            LunchMenuViewModel = lunchMenuViewModel;
            PlayerViewModel = playerViewModel;
            ShowLunchMenuViewCommand = new Command(OnShowLunchMenuView);
            ShowPosterViewCommand = new Command(OnShowPosterView);
            OnShowPosterView(null);
        }

        public PosterViewModel PosterViewModel { get; private set; }

        public LunchMenuViewModel LunchMenuViewModel { get; private set; }

        public PlayerViewModel PlayerViewModel { get; private set; }

        public Command ShowLunchMenuViewCommand { get; set; }

        public Command ShowPosterViewCommand { get; set; }

        private void OnShowPosterView(object obj)
        {
            PosterViewModel.IsPosterViewVisible = true;
            LunchMenuViewModel.IsLunchMenuViewVisible = false;
        }

        private void OnShowLunchMenuView(object obj)
        {
            PosterViewModel.IsPosterViewVisible = false;
            LunchMenuViewModel.IsLunchMenuViewVisible = true;
        }
    }
}
