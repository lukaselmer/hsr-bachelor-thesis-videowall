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
using Interfaces;

#endregion

namespace DiagnosticsApp
{
    [Export(typeof (IApp))]
    public class DiagnosticsApp : IApp
    {
        public DiagnosticsApp()
        {
            MainView = new DiagnosticsView();
            Name = "Diagnostics";
        }

        #region IApp Members

        public UserControl MainView { get; private set; }
        public String Name { get; private set; }

        #endregion
    }
}