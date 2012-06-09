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
    public partial class MainWindow
    {
        #region Constructors / Destructor

        public MainWindow()
        {
            InitializeComponent();
            IApp app = new Main.LunchMenuApp();
            app.Activate(new LocalAppInfo());
            LunchMenuContainer.Children.Add(app.MainView);
        }

        #endregion
    }

    public class LocalAppInfo : IVideoWallServiceProvider
    {
        #region IVideoWallServiceProvider Methods

        public T GetExtension<T>() where T : IVideoWallService
        {
            return default(T);
        }

        #endregion
    }
}
