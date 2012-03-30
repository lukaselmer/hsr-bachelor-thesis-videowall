using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(PosterViewModel posterViewModel)
        {
            PosterViewModel = posterViewModel;
        }

        public PosterViewModel PosterViewModel { get; private set; }
    }
}
