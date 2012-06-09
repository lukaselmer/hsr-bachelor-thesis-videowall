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

using LunchMenuApp.ViewModels;

#endregion

namespace LunchMenuApp.Views
{
    /// <summary>
    ///   Interaction logic for LunchMenuView.xaml
    /// </summary>
    public partial class LunchMenuView
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuView" /> class.
        /// </summary>
        public LunchMenuView(LunchMenuViewModel lunchMenuViewModel)
        {
            DataContext = lunchMenuViewModel;
            InitializeComponent();
        }
    }
}
