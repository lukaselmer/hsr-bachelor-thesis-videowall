﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Interfaces;

namespace DemoMode
{
    class DemoModeApp : IApp
    {
        public DemoModeApp()
        {
            MainView = new DemoModeView();
            Name = "Demo Mode App";
            DemomodeText = "I don't need any text";
        }

        public UserControl MainView { get; private set; }

        public string Name { get; private set; }

        public string DemomodeText { get; private set; }
    }
}
