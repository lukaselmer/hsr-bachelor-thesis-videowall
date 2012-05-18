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
using System.Windows.Media;
using Microsoft.Kinect;
using VideoWall.Common;
using VideoWall.ResourceLoader;
using VideoWall.ServiceModels.HandCursor;
using VideoWall.ServiceModels.Player;
using VideoWall.ViewModels.Skeletton;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 17.04.2012
    /// </summary>
    public class KinectCursorViewModel : Notifier, ICursorViewModel
    {
        /// <summary>
        ///   The cursor smoothing level represents the size of the skeleton history queue. The bigger the smoothing level, the bigger the queue, the more cursor smooting.
        /// </summary>
        private const int CursorSmoothingLevel = 10;

        private readonly HandCursorPositionCalculator _handCursorPositionCalculator;
        private readonly Player _player;

        /// <summary>
        ///   The skeleton history is used for the mouse smoothing
        /// </summary>
        private readonly Queue<Skeleton> _skeletonHistory;

        /// <summary>
        ///   The active hand.
        /// </summary>
        private HandType _activeHand = HandType.Right;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PlayerViewModel" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        /// <param name="handCursorPositionCalculator"> The player. </param>
        public KinectCursorViewModel(Player player, HandCursorPositionCalculator handCursorPositionCalculator)
        {
            _skeletonHistory = new Queue<Skeleton>(CursorSmoothingLevel);

            _player = player;
            _handCursorPositionCalculator = handCursorPositionCalculator;
            _player.PropertyChanged += PlayerModelChanged;
            WindowWidth = 0;
            WindowHeight = 0;
            _handCursorPositionCalculator.HandChanged += OnHandChanged;
        }

        /// <summary>
        ///   Gets or sets the active hand.
        /// </summary>
        /// <value> The active hand. </value>
        private HandType ActiveHand
        {
            get { return _activeHand; }
            set
            {
                if (_activeHand == value) return;
                _activeHand = value;
                // Problem was discussed on 2012-05-10 (Lukas Elmer, Silvan Gehrig, Michael Gfeller). Workaround: Event based update instead of INotifyPropertyChanged.
                // Other workaround could be: implement a timestamp to not fire the event too often.
                // This code, as it is, will produce a stack overflow, because Notify() is called too often in little time.
                Notify("HandCursorImageSource");
                Notify("ActiveHand");
            }
        }

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

        /// <summary>
        ///   Gets the hand cursor image source (for left or right hand).
        /// </summary>
        public ImageSource HandCursorImageSource
        {
            get
            {
                return ActiveHand == HandType.Right ? ResourceProvider.HandRight.Source : ResourceProvider.HandLeft.Source;
            }
        }

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

        private void OnHandChanged(HandType handType)
        {
            ActiveHand = handType;
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