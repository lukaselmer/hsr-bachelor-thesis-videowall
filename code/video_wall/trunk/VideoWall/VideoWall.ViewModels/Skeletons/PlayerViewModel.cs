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

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Kinect;
using VideoWall.Common.ViewHelpers;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;
using VideoWall.ViewModels.Skeletons;

#endregion

namespace VideoWall.ViewModels.Skeletons
{
    /// <summary>
    ///   The PlayerViewModel Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong.
    public class PlayerViewModel : Notifier, IDisposable
        // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly IPlayer _player;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the width/height of the canvas for the skeleton.
        /// </summary>
        public int WidthAndHeight { get; set; }

        /// <summary>
        ///   Gets the skeleton.
        /// </summary>
        private Skeleton Skeleton { get { return _player.Skeleton; } }

        /// <summary>
        ///   Gets the lines.
        /// </summary>
        public ObservableCollection<SkeletonLine> Lines { get; private set; }

        /// <summary>
        ///   Gets or sets the start/stop command.
        /// </summary>
        /// <value> The start/stop command. </value>
        public ICommand StopCommand { get; set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PlayerViewModel" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        public PlayerViewModel(IPlayer player)
        {
            Lines = new ObservableCollection<SkeletonLine>();

            _player = player;
            _player.SkeletonChanged += PlayerModelChanged;
            _player.StartPlaying();

            StopCommand = new ActionCommand(() => { if (_player.Playing) _player.StopPlaying(); });
            WidthAndHeight = 160;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            _player.SkeletonChanged -= PlayerModelChanged;
            _player.StopPlaying();
        }

        /// <summary>
        ///   Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The <see cref="VideoWall.Interfaces.SkeletonChangedEventArgs" /> instance containing the event data. </param>
        private void PlayerModelChanged(object sender, SkeletonChangedEventArgs args)
        {
            Lines.Clear();
            if (Skeleton != null) DrawLines();

            Notify("Lines");
            Notify("Status");
            Notify("Skeleton");
        }

        /// <summary>
        ///   Draws the lines of the skeleton.
        /// </summary>
        private void DrawLines()
        {
            //right arm
            DrawLine(JointType.HandRight, JointType.WristRight);
            DrawLine(JointType.WristRight, JointType.ElbowRight);
            DrawLine(JointType.ElbowRight, JointType.ShoulderRight);
            DrawLine(JointType.ShoulderRight, JointType.ShoulderCenter);
            //left arm
            DrawLine(JointType.HandLeft, JointType.WristLeft);
            DrawLine(JointType.WristLeft, JointType.ElbowLeft);
            DrawLine(JointType.ElbowLeft, JointType.ShoulderLeft);
            DrawLine(JointType.ShoulderLeft, JointType.ShoulderCenter);
            //right leg
            DrawLine(JointType.FootRight, JointType.AnkleRight);
            DrawLine(JointType.AnkleRight, JointType.KneeRight);
            DrawLine(JointType.KneeRight, JointType.HipRight);
            DrawLine(JointType.HipRight, JointType.HipCenter);
            //left leg
            DrawLine(JointType.FootLeft, JointType.AnkleLeft);
            DrawLine(JointType.AnkleLeft, JointType.KneeLeft);
            DrawLine(JointType.KneeLeft, JointType.HipLeft);
            DrawLine(JointType.HipLeft, JointType.HipCenter);
            //join
            DrawLine(JointType.HipCenter, JointType.Spine);
            DrawLine(JointType.Spine, JointType.ShoulderCenter);
            DrawLine(JointType.ShoulderCenter, JointType.Head);
        }

        private void DrawLine(JointType joint1, JointType joint2)
        {
            Lines.Add(new SkeletonLine(Skeleton.Joints[joint1], Skeleton.Joints[joint2], WidthAndHeight));
        }

        #endregion
    }
}
