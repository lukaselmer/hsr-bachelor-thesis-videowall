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
    public class PlayerViewModel : Notifier, IDisposable
    {
        #region Properties
        public string Status
        {
            get { return _player.Playing ? "Playing" : "Idle"; }
        }

        public Skeleton Skeleton { get { return _player.Skeleton; } }

        public ICommand StartStopCommand { get; set; }
        #endregion

        private readonly Player _player;

        public PlayerViewModel(Player player)
        {
            _player = player;
            _player.PropertyChanged += PlayerModelChanged;
            StartStopCommand = new ActionCommand(() =>
            {
                if (_player.Playing) _player.StopPlaying();
                else _player.StartPlaying();
            });
        }

        private void PlayerModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Status");
            Notify("Skeleton");
        }

        public void Dispose()
        {
            _player.PropertyChanged -= Notify;
            _player.StopPlaying();
        }
    }
}
