using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PosterViewModel posterViewModel, LunchMenuViewModel lunchMenuViewModel)
        {
            PosterViewModel = posterViewModel;
            LunchMenuViewModel = lunchMenuViewModel;
        }

        public PosterViewModel PosterViewModel { get; private set; }

        public LunchMenuViewModel LunchMenuViewModel { get; private set; }
    }
}
