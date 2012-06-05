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

using VideoWall.Interfaces;

#endregion

namespace LunchMenuApp.Startup
{
    /// <summary>
    ///   Interaction logic for MainWindow.xaml
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public partial class MainWindow
    {
        #region Constructors / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            IApp app = new Main.LunchMenuApp();
            app.Activate(new LocalAppInfo());
            LunchMenuContainer.Children.Add(app.MainView);
        }

        #endregion
    }
}
