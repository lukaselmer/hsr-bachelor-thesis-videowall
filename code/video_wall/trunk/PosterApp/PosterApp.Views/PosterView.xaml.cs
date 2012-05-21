#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using PosterApp.ViewModels;

#endregion

namespace Views.Xaml
{
    /// <summary>
    ///   Interaction logic for PosterView.xaml
    /// </summary>
    public partial class PosterView
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterView" /> class.
        /// </summary>
        public PosterView(PosterViewModel posterViewModel)
        {
            DataContext = posterViewModel;
            InitializeComponent();
        }
    }
}
