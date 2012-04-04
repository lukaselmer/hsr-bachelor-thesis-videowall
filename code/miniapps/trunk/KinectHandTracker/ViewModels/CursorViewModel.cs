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
    public class CursorViewModel : Notifier, IDisposable
    {
        private readonly Player _player;
        private readonly CursorPositionCalculator _cursorPositionCalculator;

        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public Point Position
        {
            get
            {
                return _cursorPositionCalculator.CalculatePositionFromSkeleton(WindowWidth, WindowHeight, _player.Skeleton);
            }
        }

        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="cursorPositionCalculator">The cursor position calculator </param>
        public CursorViewModel(Player player, CursorPositionCalculator cursorPositionCalculator)
        {
            _player = player;
            _cursorPositionCalculator = cursorPositionCalculator;
            _player.PropertyChanged += PlayerModelChanged;
            WindowWidth = 600;
            WindowHeight = 400;
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
            _player.PropertyChanged -= Notify;
        }

        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }
    }
}
