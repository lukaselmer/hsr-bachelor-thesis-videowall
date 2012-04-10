using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Coding4Fun.Kinect.Wpf;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Kinect;
using Services;
using Services.HandCursor;
using Services.Player;
using Services.Recorder;

namespace ViewModels
{
    /// <summary>
    /// The PlayerViewModel
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class MouseCursorViewModel : Notifier, ICursorViewModel
    {
        #region Properties

        private Point _position;
        private Color _background;

        /// <summary>
        /// Gets the status.
        /// </summary>
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Notify("Position");
            }
        }

        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }

        public ICommand GreenCommand { get; private set; }
        public ICommand RedCommand { get; private set; }
        public ICommand BlueCommand { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseCursorViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="handCursorPositionCalculator">The cursor position calculator </param>
        public MouseCursorViewModel()
        {
            WindowWidth = 600;
            WindowHeight = 400;
            Notify("Position");
            InitCommands();
            Background = Colors.Gold;
        }

        /// <summary>
        /// Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
        }

        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }


        private void InitCommands()
        {
            GreenCommand = new ActionCommand(() => Background = Colors.Green);
            RedCommand = new ActionCommand(() => Background = Colors.Red);
            BlueCommand = new ActionCommand(() => Background = Colors.Blue);
        }

        public Color Background
        {
            get
            {
                return _background;
            }
            private set
            {
                _background = value;
                Notify("Background");
            }
        }
    }
}
