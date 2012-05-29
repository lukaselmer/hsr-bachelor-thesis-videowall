using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Player
{
    public class SkeletonService : ISkeletonService
    {
        private readonly Player _player;
        public event SkeletonChangedEvent SkeletonChanged = delegate { };

        public SkeletonService(Player player)
        {
            _player = player;
            _player.PropertyChanged += PlayerChanged;
        }

        private void PlayerChanged(object sender, PropertyChangedEventArgs e)
        {
            if(!_player.Playing) return;
            SkeletonChanged(this, new SkeletonChangedEventArgs(_player.Skeleton));
        }
    }
}
