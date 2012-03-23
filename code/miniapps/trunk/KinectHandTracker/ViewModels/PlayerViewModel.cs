using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
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
    public class PlayerViewModel : Notifier, IDisposable
    {
        public readonly Player Player;

        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status
        {
            get { return Player.Playing ? "Playing" : "Idle"; }
        }

        /// <summary>
        /// Gets the skeleton.
        /// </summary>
        public Skeleton Skeleton { get { return Player.Skeleton; } }


        /// <summary>
        /// Gets or sets the start/stop command.
        /// </summary>
        /// <value>
        /// The start/stop command.
        /// </value>
        public ICommand StartOrStopCommand { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerViewModel"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public PlayerViewModel(Player player)
        {
            Player = player;
            Player.PropertyChanged += PlayerModelChanged;
            StartOrStopCommand = new ActionCommand(() =>
            {
                if (Player.Playing) Player.StopPlaying();
                else Player.StartPlaying();
            });
        }

        /// <summary>
        /// Notifies when the PlayerModel was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Status");
            Notify("Skeleton");
        }

        /// <summary>
        /// Unregisters the notification and the player stops playing.
        /// </summary>
        public void Dispose()
        {
            Player.PropertyChanged -= Notify;
            Player.StopPlaying();
        }
    }
}
