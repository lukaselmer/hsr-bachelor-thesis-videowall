using System.Windows.Input;

namespace ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PosterViewModel posterViewModel, LunchMenuViewModel lunchMenuViewModel, PlayerViewModel playerViewModel)
        {
            PosterViewModel = posterViewModel;
            LunchMenuViewModel = lunchMenuViewModel;
            PlayerViewModel = playerViewModel;
            ShowPosterViewCommand = new Command(OnShowPosterView);
            ShowLunchMenuViewCommand = new Command(OnShowLunchMenuView);
            OnShowPosterView(null);
        }

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


        public PosterViewModel PosterViewModel { get; set; }
        public LunchMenuViewModel LunchMenuViewModel { get; set; }
        public PlayerViewModel PlayerViewModel { get; set; }

        public ICommand ShowLunchMenuViewCommand { get; set; }

        public ICommand ShowPosterViewCommand { get; set; }
    }
}
