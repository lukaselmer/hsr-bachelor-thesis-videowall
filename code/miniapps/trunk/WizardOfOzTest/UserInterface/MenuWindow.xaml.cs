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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : UserControl
    {
        public MenuWindow()
        {
            InitializeComponent();
            MenuViewer.FitToHeight();  
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MenuViewer.FitToHeight();
        }
    }
}
