#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Common;
using Microsoft.Kinect;
using ServiceModels.HandCursor;
using ServiceModels.Player;
using ViewModels.Skeletton;

#endregion

namespace ViewModels.Cursor
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class KinectCursorViewModel : Notifier, ICursorViewModel
    {
        private const int CursorSmoothingLevel = 10;

        private readonly HandCursorPositionCalculator _handCursorPositionCalculator;
        private readonly Player _player;
        private readonly Queue<Skeleton> _skeletonHistory;

        /// <summary>
        ///   Gets the position.
        /// </summary>
        public Point Position { get { return _handCursorPositionCalculator.CalculatePositionFromSkeletons(new Size(WindowWidth, WindowHeight), _skeletonHistory); } }

        /// <summary>
        ///   Sets the width of the window.
        /// </summary>
        /// <value> The width of the window. </value>
        public double WindowWidth { private get; set; }

        /// <summary>
        ///   Sets the height of the window.
        /// </summary>
        /// <value> The height of the window. </value>
        public double WindowHeight { private get; set; }

        private ImageSource _handCursorImageSource;

        /// <summary>
        /// Gets the hand cursor image source (for left or right hand).
        /// </summary>
        public ImageSource HandCursorImageSource
        {
            get
            {
                return _handCursorImageSource;
            }
            private set
            {
                if (_handCursorImageSource == value) return;
                _handCursorImageSource = value; 
                // TODO: discuss this problem!! Too many notifications here... D: D: D:
                //Notify("HandCursorImageSource");
            }
        }

        private ImageSource _rightHandSource;
        private ImageSource _leftHandSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="handCursorPositionCalculator">The player.</param>
        public KinectCursorViewModel(Player player, HandCursorPositionCalculator handCursorPositionCalculator)
        {
            _skeletonHistory = new Queue<Skeleton>(CursorSmoothingLevel);

            _player = player;
            _handCursorPositionCalculator = handCursorPositionCalculator;
            _player.PropertyChanged += PlayerModelChanged;
            WindowWidth = 0;
            WindowHeight = 0;
            InitCursorImages();
            _handCursorPositionCalculator.HandChanged += OnHandChanged;
        }

        private void InitCursorImages()
        {
            _leftHandSource = ResourceLoader.ResourceProvider.HandLeft.Source;
            _rightHandSource = ResourceLoader.ResourceProvider.HandRight.Source;
            HandCursorImageSource = _rightHandSource;
        }

        #region ICursorViewModel Members

        /// <summary>
        ///   Occurs when hand has changed.
        /// </summary>
        public event HandChanged HandChanged;

        /// <summary>
        ///   Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            _player.PropertyChanged -= PlayerModelChanged;
        }

        #endregion

        private void OnHandChanged(HandType handType)
        {
            HandCursorImageSource = handType == HandType.Right ? _rightHandSource : _leftHandSource;
            if (HandChanged != null) HandChanged(handType);
        }

        /// <summary>
        ///   Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Skeleton") return;

            if (_skeletonHistory.Count >= CursorSmoothingLevel) _skeletonHistory.Dequeue();
            _skeletonHistory.Enqueue(_player.Skeleton);

            Notify("Position");
        }

        /// <summary>
        ///   Notifies when the window size is changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.Windows.SizeChangedEventArgs" /> instance containing the event data. </param>
        public void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            WindowWidth = e.NewSize.Width;
            WindowHeight = e.NewSize.Height;
        }
    }
}