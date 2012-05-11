using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels.DemoMode;

namespace Views.Xaml
{
    /// <summary>
    /// Interaction logic for DemoModeView.xaml
    /// </summary>
    public partial class DemoModeView : UserControl
    {
        private readonly DemoModeViewModel _demoModeViewModel;

        public DemoModeView()
        {
            InitializeComponent();
        }
    }
}
