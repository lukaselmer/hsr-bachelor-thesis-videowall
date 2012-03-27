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
using Microsoft.Kinect;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = MainWindowViewModel = viewModel;
            PosterViewer.FitToHeight();
            Cursor = Cursors.None;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var pos = e.GetPosition(MyGrid);
            Hand.Margin = new Thickness(pos.X - 80, pos.Y - 80, 0, 0);
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            kinectSensorChooser1.KinectSensorChanged += new DependencyPropertyChangedEventHandler(kinectSensorChooser1_KinectSensorChanged);
        }

        void kinectSensorChooser1_KinectSensorChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var oldSensor = (KinectSensor)e.OldValue;
            StopKinect(oldSensor);

            var newSensor = (KinectSensor)e.NewValue;

            if (newSensor == null) return;

            newSensor.ColorStream.Enable();
            newSensor.DepthStream.Enable();
            newSensor.SkeletonStream.Enable();
            //newSensor.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(newSensor_AllFramesReady);
            try
            {
                newSensor.Start();
            }
            catch (System.IO.IOException)
            {
                kinectSensorChooser1.AppConflictOccurred();
            }
        }


        void StopKinect(KinectSensor sensor)
        {
            if (sensor != null)
            {
                if (sensor.IsRunning)
                {
                    sensor.Stop();
                }
                if (sensor.AudioSource != null)
                {
                    sensor.AudioSource.Stop();
                }
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StopKinect(kinectSensorChooser1.Kinect);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PosterViewer.FitToHeight();
        }

        private void ArrowRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindowViewModel.NavigateToRightCommand.Execute(e);
        }

        private void ArrowLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindowViewModel.NavigateToLeftCommand.Execute(e);
        }

      
        private void Poster_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindowViewModel.ShowPosters.Execute(e);

            Rectangle_Poster.Fill = Brushes.Blue;
            Rectangle_Mittagsmenu.Fill = Brushes.White;
            Text_Poster.FontSize = 14;
            Text_Poster.FontWeight = FontWeights.Bold;
            Text_Mittagsmenu.FontSize = 12;
            Text_Mittagsmenu.FontWeight = FontWeights.Normal;
        }

        private void Mittagsmenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindowViewModel.ShowMenu.Execute(e);

            Rectangle_Poster.Fill = Brushes.White;
            Rectangle_Mittagsmenu.Fill = Brushes.Blue;
            Text_Poster.FontSize = 12;
            Text_Poster.FontWeight = FontWeights.Normal;
            Text_Mittagsmenu.FontSize = 14;
            Text_Mittagsmenu.FontWeight = FontWeights.Bold;

        }

        private void MyGrid_KeyDown(object sender, KeyEventArgs e)
        {

            var uriSource = new Uri(@"/Testapp;component/Resources/clock.png", UriKind.Relative);
            Hand.Source = new BitmapImage(uriSource);
        }

        private void MyGrid_KeyUp(object sender, KeyEventArgs e)
        {
            var uriSource = new Uri(@"/Testapp;component/Resources/hand.png", UriKind.Relative);
            Hand.Source = new BitmapImage(uriSource);
        }
      
    }
}
