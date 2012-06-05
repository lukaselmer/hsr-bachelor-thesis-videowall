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

namespace PosterApp.Views
{
    /// <summary>
    ///   Interaction logic for PosterView.xaml
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public partial class PosterView
    {
        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterView" /> class.
        /// </summary>
        public PosterView(PosterViewModel posterViewModel)
        {
            DataContext = posterViewModel;
            InitializeComponent();
        }

        #endregion
    }
}
