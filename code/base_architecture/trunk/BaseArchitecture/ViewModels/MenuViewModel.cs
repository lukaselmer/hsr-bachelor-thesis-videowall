using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class MenuViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        /// <param name="posterViewModel">The poster view model.</param>
        /// <param name="lunchMenuViewModel">The lunch menu view model.</param>
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

        public ICommand ShowLunchMenuViewCommand { get; set; }
        public ICommand ShowPosterViewCommand { get; set; }

        /// <summary>
        /// Called when [show poster view].
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void OnShowPosterView(object obj)
        {
            LunchMenuViewModel.IsLunchMenuViewVisible = false;
            PosterViewModel.IsPosterViewVisible = true;
        }

        /// <summary>
        /// Called when [show lunch menu view].
        /// </summary>
        /// <param name="obj">The obj.</param>
        private void OnShowLunchMenuView(object obj)
        {
            PosterViewModel.IsPosterViewVisible = false;
            LunchMenuViewModel.IsLunchMenuViewVisible = true;
        }
    }
}
