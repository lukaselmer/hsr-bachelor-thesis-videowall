#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Microsoft.Kinect;
using VideoWall.Common.ViewHelpers;
using VideoWall.Interfaces;
using VideoWall.ResourceLoader;
using VideoWall.ServiceModels.HandCursor.Implementation;
using VideoWall.ServiceModels.HandCursor.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

#endregion

namespace VideoWall.ViewModels.Cursor
{
    /// <summary>
    ///   The kinect cursor view model.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Christina Heidt, 17.04.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    public class KinectCursorViewModel : Notifier, ICursorViewModel
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        // NOTE: the smoothing level could be moved to the configuration

        /// <summary>
        /// The cursor smoothing level represents the size of the skeleton history queue. The bigger the
        /// smoothing level, the bigger the queue, the more cursor smoothing.
        /// </summary>
        private const int CursorSmoothingLevel = 10;

        /// <summary>
        /// The hand cursor position calculator.
        /// </summary>
        private readonly IHandCursorPositionCalculator _handCursorPositionCalculator;

        /// <summary>
        /// The player.
        /// </summary>
        private readonly IPlayer _player;

        /// <summary>
        ///   The skeleton history is used for the mouse smoothing.
        /// </summary>
        private readonly Queue<Skeleton> _skeletonHistory;

        /// <summary>
        ///   The active hand.
        /// </summary>
        private HandType _activeHand = HandType.Right;

        /// <summary>
        ///   The latest skeleton
        /// </summary>
        private Skeleton _latestSkeleton;

        #endregion

        #region Properties

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
                Notify("HandCursorImageSource");
                Notify("ActiveHand");
            }
        }

        /// <summary>
        ///   Gets the position.
        /// </summary>
        public Point Position { get { return _handCursorPositionCalculator.CalculatePositionFromSkeletons(new Size(WindowWidth, WindowHeight), _skeletonHistory, _latestSkeleton); } }

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
        public ImageSource HandCursorImageSource { get { return ActiveHand == HandType.Right ? ResourceProvider.HandRight.Source : ResourceProvider.HandLeft.Source; } }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="KinectCursorViewModel" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        /// <param name="handCursorPositionCalculator"> The handCursorPositionCalculator. </param>
        public KinectCursorViewModel(IPlayer player, IHandCursorPositionCalculator handCursorPositionCalculator)
        {
            _skeletonHistory = new Queue<Skeleton>(CursorSmoothingLevel);

            _player = player;
            _handCursorPositionCalculator = handCursorPositionCalculator;
            _handCursorPositionCalculator.HandChanged += OnHandChanged;
            _player.SkeletonChanged += PlayerModelChanged;
            WindowWidth = 0;
            WindowHeight = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when hand changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="VideoWall.ServiceModels.HandCursor.Implementation.HandChangedEventArgs"/> instance containing the event data.</param>
        private void OnHandChanged(object sender, HandChangedEventArgs eventArgs)
        {
            ActiveHand = eventArgs.HandType;
        }

        /// <summary>
        ///   Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The <see cref="VideoWall.Interfaces.SkeletonChangedEventArgs" /> instance containing the event data. </param>
        private void PlayerModelChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_skeletonHistory.Count >= CursorSmoothingLevel) _skeletonHistory.Dequeue();
            _skeletonHistory.Enqueue(_player.Skeleton);
            _latestSkeleton = _player.Skeleton;

            Notify("Position");
        }

        #endregion
    }
}
