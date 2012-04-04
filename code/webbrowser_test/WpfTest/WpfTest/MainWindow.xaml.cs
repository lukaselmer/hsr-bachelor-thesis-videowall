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

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path;
        private List<string> _files;
        private int currentFileIndex;

        public MainWindow()
        {
            InitializeComponent();
            _path = @"D:\Video Wall\code\webbrowser_test\WpfTest\Resources\";
            _files = new List<string>
                               {
                                   "Poster_Android.pdf", "Poster_Bodyscanner.pdf", "Poster_EventAssistant.pdf", "Poster_Exchange.pdf",
                                   "Poster_FireTabletPlus.pdf", "Poster_iPhone.pdf", "Poster_Isochrones.pdf", "Poster_Lumin.pdf", "Poster_SnapIt.pdf"
                               };
            currentFileIndex = 0;
            Navigate();
        }

        private void Navigate()
        {
            webBrowser.Navigate(new Uri(_path + _files[currentFileIndex], UriKind.RelativeOrAbsolute));
        }

        private void Next()
        {
            currentFileIndex = (currentFileIndex + 1 == _files.Count) ? 0 : currentFileIndex + 1;
        }

        private void Previous()
        {
            currentFileIndex = (currentFileIndex - 1 < 0) ? _files.Count - 1 : currentFileIndex - 1;
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            Previous();
            Navigate();
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            Next();
            Navigate();
        }
    }
}
