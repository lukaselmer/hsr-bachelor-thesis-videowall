#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using VideoWall.Interfaces;

#endregion

namespace DiagnosticsApp
{
    [Export(typeof(IApp))]
    public class DiagnosticsApp : IApp
    {
        public DiagnosticsApp()
        {
            Name = "Diagnostics";
            DemomodeText = "Techie?";
        }

        #region IApp Members

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }
        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
            MainView = new DiagnosticsView();
        }

        #endregion
    }
}