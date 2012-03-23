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

        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public Point Position
        {
            get
            {
                if (_player.Skeleton == null) return new Point(50, 50);
                var joint = _player.Skeleton.Joints[JointType.HandRight];
                var pos = joint.ScaleTo(1000, 1000);
                return new Point(pos.Position.X, pos.Position.Y);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public CursorViewModel(Player player)
        {
            _player = player;
            _player.PropertyChanged += PlayerModelChanged;
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
    }
}
