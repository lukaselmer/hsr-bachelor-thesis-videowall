using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Interfaces;

namespace DiagnosticsApp2
{
    [Export(typeof(IApp))]
    public class DiagnosticsApp : IApp
    {
        public UserControl MainView { get; private set; }
        public String Name { get; private set; }

        public DiagnosticsApp()
        {
            MainView = new DiagnosticsView();
            Name = "Diagnostics";
        }
    }
}
