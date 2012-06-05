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
using VideoWall.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

#endregion

namespace VideoWall.ServiceModels.Player.Implementation
{
    /// <summary>
    ///   The skeleton service provides events when the skeleton changes.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class can be made abstract, which is wrong.
    internal class SkeletonService : ISkeletonService
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The player
        /// </summary>
        private readonly IPlayer _player;

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when skeleton changes.
        /// </summary>
        public event EventHandler<SkeletonChangedEventArgs> SkeletonChanged = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="SkeletonService" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        public SkeletonService(IPlayer player)
        {
            _player = player;
            _player.SkeletonChanged += PlayerChanged;
        }

        #endregion

        #region Methods

        private void PlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            //if(!_player.Playing) return;
            if (args.Skeleton == null) return;
            SkeletonChanged(this, new SkeletonChangedEventArgs(args.Skeleton));
        }

        #endregion
    }
}
