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
using System.Windows.Shapes;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for CursorWindow.xaml
    /// </summary>
    public partial class CursorWindow : Window
    {
        public CursorViewModel CursorViewModel { get; private set; }

        public CursorWindow(CursorViewModel cursorViewModel)
        {
            DataContext = CursorViewModel = cursorViewModel;
            InitializeComponent();
        }
    }
}
