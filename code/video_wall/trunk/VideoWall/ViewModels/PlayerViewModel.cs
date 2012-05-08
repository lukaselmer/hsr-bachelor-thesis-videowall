using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Kinect;
using Services;

namespace ViewModels
{
    /// <summary>
    /// The PlayerViewModel
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class PlayerViewModel : Notifier, IDisposable
    {
        private readonly Player _player;

        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status
        {
            get { return _player.Playing ? "Playing" : "Idle"; }
        }

        /// <summary>
        /// Gets the width/height of the canvas for the skeleton.
        /// </summary>
        public int WidthAndHeight { get; private set; }

        /// <summary>
        /// Gets the skeleton.
        /// </summary>
        public Skeleton Skeleton { get { return _player.Skeleton; } }


        /// <summary>
        /// Gets the lines.
        /// </summary>
        public ObservableCollection<SkeletonLine> Lines { get; private set; }

        /// <summary>
        /// Gets or sets the start/stop command.
        /// </summary>
        /// <value>
        /// The start/stop command.
        /// </value>
        public ICommand StopCommand { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerViewModel(Player player)
        {
            Lines = new ObservableCollection<SkeletonLine>();

            _player = player;
            _player.PropertyChanged += PlayerModelChanged;
            _player.StartPlaying();

            StopCommand = new ActionCommand(() =>
            {
                if (_player.Playing) _player.StopPlaying();
            });

            WidthAndHeight = 153;
        }

        /// <summary>
        /// Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Lines.Clear();
            if(Skeleton!=null) DrawLines();
            
            Notify("Lines");
            Notify("Status");
            Notify("Skeleton");
        }

        /// <summary>
        /// Draws the lines of the skeleton.
        /// </summary>
        private void DrawLines()
        {
            //right arm
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.HandRight], Skeleton.Joints[JointType.WristRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.WristRight], Skeleton.Joints[JointType.ElbowRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.ElbowRight], Skeleton.Joints[JointType.ShoulderRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.ShoulderRight], Skeleton.Joints[JointType.ShoulderCenter], WidthAndHeight));
            //left arm
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.HandLeft], Skeleton.Joints[JointType.WristLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.WristLeft], Skeleton.Joints[JointType.ElbowLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.ElbowLeft], Skeleton.Joints[JointType.ShoulderLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.ShoulderLeft], Skeleton.Joints[JointType.ShoulderCenter], WidthAndHeight));
            //right leg
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.FootRight], Skeleton.Joints[JointType.AnkleRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.AnkleRight], Skeleton.Joints[JointType.KneeRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.KneeRight], Skeleton.Joints[JointType.HipRight], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.HipRight], Skeleton.Joints[JointType.HipCenter], WidthAndHeight));
            //left leg
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.FootLeft], Skeleton.Joints[JointType.AnkleLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.AnkleLeft], Skeleton.Joints[JointType.KneeLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.KneeLeft], Skeleton.Joints[JointType.HipLeft], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.HipLeft], Skeleton.Joints[JointType.HipCenter], WidthAndHeight));
            //join
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.HipCenter], Skeleton.Joints[JointType.Spine], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.Spine], Skeleton.Joints[JointType.ShoulderCenter], WidthAndHeight));
            Lines.Add(new SkeletonLine(Skeleton.Joints[JointType.ShoulderCenter], Skeleton.Joints[JointType.Head], WidthAndHeight));
        }

        /// <summary>
        /// Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            _player.PropertyChanged -= Notify;
            _player.StopPlaying();
        }
    }
}