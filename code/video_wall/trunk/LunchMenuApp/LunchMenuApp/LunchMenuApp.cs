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
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }

        public UserControl MainView { get; private set; }
        
        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
            Name = "Mittagsmenü";
            DemomodeText = "Hunger?";
            MainView = new LunchMenuView();
        }
    }
}
