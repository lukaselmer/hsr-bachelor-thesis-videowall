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
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public partial class LunchMenuView
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuView" /> class.
        /// </summary>
        /// <param name="lunchMenuViewModel"> The lunch menu view model. </param>
        public LunchMenuView(LunchMenuViewModel lunchMenuViewModel)
        {
            DataContext = lunchMenuViewModel;
            InitializeComponent();
        }
    }
}
