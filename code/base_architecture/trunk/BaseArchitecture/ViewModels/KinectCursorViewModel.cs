using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Services;
using Services.HandCursor;

namespace ViewModels
{
    public class KinectCursorViewModel : Notifier, ICursorViewModel
    {
        private readonly Player _player;
        private readonly HandCursorPositionCalculator _handCursorPositionCalculator;
        private Color _background;

        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public Point Position
        {
            get
            {
                return _handCursorPositionCalculator.CalculatePositionFromSkeleton(new Size(WindowWidth, WindowHeight), _player.Skeleton);
            }
        }

        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }

        public ICommand GreenCommand { get; private set; }
        public ICommand RedCommand { get; private set; }
        public ICommand BlueCommand { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="handCursorPositionCalculator">The cursor position calculator </param>
        public KinectCursorViewModel(Player player, HandCursorPositionCalculator handCursorPositionCalculator)
        {
            _player = player;
            _handCursorPositionCalculator = handCursorPositionCalculator;
            _player.PropertyChanged += PlayerModelChanged;
            WindowWidth = 600;
            WindowHeight = 400;

            InitCommands();
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
            set
            {
                _background = value;
                Notify("Background");
            }
        }

        /// <summary>
        /// Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Position");
        }

        /// <summary>
        /// Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            _player.PropertyChanged -= PlayerModelChanged;
        }

        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }
    }
}
