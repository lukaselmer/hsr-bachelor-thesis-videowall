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
using System.Windows;

#endregion

namespace DiagnosticsApp
{
    /// <summary>
    ///   Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DiagnosticsView
    {
        public DiagnosticsView()
        {
            InitializeComponent();
        }

        private void ClickA(object sender, RoutedEventArgs e)
        {
            Click("A");
        }

        private void ClickB(object sender, RoutedEventArgs e)
        {
            Click("B");
        }

        private void ClickC(object sender, RoutedEventArgs e)
        {
            Click("C");
        }

        private void Click(string s)
        {
            actionLog.Text = String.Format("{0} : {1}\n{2}", DateTime.Now, s, actionLog.Text);
        }
    }
}