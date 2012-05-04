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

namespace DiagnosticsApp2
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class DiagnosticsView : UserControl
    {
        public DiagnosticsView()
        {
            InitializeComponent();
        }

        private void ClickA(object sender, RoutedEventArgs e)
        {
            Click("A");
        }

        private void Click(string s)
        {
            MessageBox.Show(s);
        }

        private void ClickB(object sender, RoutedEventArgs e)
        {
            Click("B");
        }

        private void ClickC(object sender, RoutedEventArgs e)
        {
            Click("C");
        }
    }
}
