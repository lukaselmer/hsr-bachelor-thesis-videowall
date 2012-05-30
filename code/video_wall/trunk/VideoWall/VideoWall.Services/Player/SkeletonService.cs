using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using VideoWall.Interfaces;

namespace VideoWall.ServiceModels.Player
{
    /// <summary>
    /// The skeleton service provides events when the skeleton changes.
    /// </summary>
    public class SkeletonService : ISkeletonService
    {
        private readonly Player _player;

        /// <summary>
        /// Occurs when skeleton changes.
        /// </summary>
        public event SkeletonChangedEvent SkeletonChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="SkeletonService"/> class.
        /// </summary>
        /// <param name="player">The player.</param>
        public SkeletonService(Player player)
        {
            _player = player;
            _player.PropertyChanged += PlayerChanged;
        }

        private void PlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            //if(!_player.Playing) return;
            if(args.Skeleton == null) return;
            SkeletonChanged(this, new SkeletonChangedEventArgs(args.Skeleton));
        }
    }
}
