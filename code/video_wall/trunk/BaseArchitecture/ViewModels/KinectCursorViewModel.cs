using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Kinect;
using Services;
using Services.HandCursor;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class KinectCursorViewModel : Notifier, ICursorViewModel
    {
        private const int CursorSmoothingLevel = 10;

        private readonly Player _player;
        private readonly HandCursorPositionCalculator _handCursorPositionCalculator;
        private readonly Queue<Skeleton> _skeletonHistory;

        #region Properties
        /// <summary>
        /// Gets the position.
        /// </summary>
        public Point Position
        {
            get
            {
                return _handCursorPositionCalculator.CalculatePositionFromSkeletons(new Size(WindowWidth, WindowHeight), _skeletonHistory);
            }
        }

        /// <summary>
        /// Sets the width of the window.
        /// </summary>
        /// <value>
        /// The width of the window.
        /// </value>
        public double WindowWidth { private get; set; }

        /// <summary>
        /// Sets the height of the window.
        /// </summary>
        /// <value>
        /// The height of the window.
        /// </value>
        public double WindowHeight { private get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="handCursorPositionCalculator">The cursor position calculator </param>
        public KinectCursorViewModel(Player player, HandCursorPositionCalculator handCursorPositionCalculator)
        {
            _skeletonHistory = new Queue<Skeleton>(CursorSmoothingLevel);

            _player = player;
            _handCursorPositionCalculator = handCursorPositionCalculator;
            _player.PropertyChanged += PlayerModelChanged;
            WindowWidth = 0;
            WindowHeight = 0;
            _handCursorPositionCalculator.HandChanged += OnHandCursorHandChanged;
        }

        public event HandChanged HandChanged;

        private void OnHandChanged(bool isRightHand)
        {
            if (HandChanged != null)
            {
                HandChanged(isRightHand);
            }
        }

        private void OnHandCursorHandChanged(bool isRightHand)
        {
            OnHandChanged(isRightHand);
        }
        /// <summary>
        /// Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Skeleton") return;

            if (_skeletonHistory.Count >= CursorSmoothingLevel) _skeletonHistory.Dequeue();
            _skeletonHistory.Enqueue(_player.Skeleton);

            Notify("Position");
        }

        /// <summary>
        /// Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            _player.PropertyChanged -= PlayerModelChanged;
        }

        /// <summary>
        /// Notifies when the window size is changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }
    }
}
