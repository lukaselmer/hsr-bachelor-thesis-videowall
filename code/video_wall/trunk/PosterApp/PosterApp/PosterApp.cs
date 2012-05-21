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

using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using VideoWall.Interfaces;
using Views.Xaml;

#endregion

namespace PosterApp.Main
{
    [Export(typeof (IApp))]
    public class PosterApp : IApp
    {
        #region Properties

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }

        #endregion

        #region Constructors / Destructor

        public PosterApp()
        {
            Name = "Posters";
            DemomodeText = "Neugierig?";
        }

        #endregion

        #region Methods

        public void Activate(IVideoWallServiceProvider serviceProvider)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(serviceProvider);
            MainView = unityContainer.Resolve<PosterView>();
        }

        #endregion
    }
}
