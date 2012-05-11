using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Interfaces;
using Views.Xaml;

namespace LunchMenuApp
{
    [Export(typeof(IApp))]
    public class LunchMenuApp : IApp
    {
        public LunchMenuApp()
        {
            Name = "Mittagsmenü";
            MainView = new LunchMenuView();
        }
        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
    }
}
