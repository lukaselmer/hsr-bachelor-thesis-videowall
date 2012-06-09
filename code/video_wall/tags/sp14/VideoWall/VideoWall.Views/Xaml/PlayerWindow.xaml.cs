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

using VideoWall.ViewModels.Skeletton;

#endregion

namespace VideoWall.Views.Xaml
{
    /// <summary>
    ///   Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow
    {
        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PlayerWindow" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        public PlayerWindow(PlayerViewModel player)
        {
            InitializeComponent();
            DataContext = player;
        }

        #endregion
    }
}