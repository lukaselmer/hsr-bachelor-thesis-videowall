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
using System.Windows.Media;
using VideoWall.Common.Extensions;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.DemoMode.Interfaces;
using VideoWall.ServiceModels.Player.Interfaces;

#endregion

namespace VideoWall.ServiceModels.DemoMode.Implementation
{
    /// <summary>
    ///   The demo mode service
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable UnusedMember.Global
    // Created by unity, so ReSharper thinks this class is unused, which is wrong.
    internal class DemoModeService : IDemoModeService
    // ReSharper restore UnusedMember.Global
    {
        #region Declarations

        /// <summary>
        ///   The demo mode config
        /// </summary>
        private readonly IDemoModeConfig _demoModeConfig;

        /// <summary>
        ///   The mode timer realizes a state machine for the demo mode
        /// </summary>
        private readonly DemoModeStateTimers _demoModeStateTimers;

        /// <summary>
        ///   The player
        /// </summary>
        private readonly IPlayer _player;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the state.
        /// </summary>
        /// <value> The state. </value>
        public VideoWallState State { get { return _demoModeStateTimers.State; } }

        /// <summary>
        ///   Gets or sets the color of the current.
        /// </summary>
        /// <value> The color of the current. </value>
        public Color CurrentBackgroundColor { get; private set; }

        /// <summary>
        ///   Gets the countdown.
        /// </summary>
        public int Countdown { get { return _demoModeStateTimers.Countdown; } }

        #endregion

        #region Events

        /// <summary>
        ///   Occurs when demo mode state changed.
        /// </summary>
        public event EventHandler DemoModeStateChanged = delegate { };

        /// <summary>
        ///   Occurs when demo mode app should be changed.
        /// </summary>
        public event EventHandler DemoModeAppChanged = delegate { };

        /// <summary>
        ///   Occurs when demo mode color should be changed.
        /// </summary>
        public event EventHandler DemoModeColorChanged = delegate { };

        /// <summary>
        ///   Occurs when demo mode countdown changed.
        /// </summary>
        public event EventHandler DemoModeCountdownChanged = delegate { };

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="DemoModeService" /> class.
        /// </summary>
        /// <param name="player"> The player. </param>
        /// <param name="demoModeConfig"> The demo mode config. </param>
        public DemoModeService(IPlayer player, IDemoModeConfig demoModeConfig)
        {
            _player = player;
            _demoModeConfig = demoModeConfig;

            ChangeColorAndApp();
            _demoModeStateTimers = new DemoModeStateTimers(_demoModeConfig);
            _demoModeStateTimers.DemoModeStateChanged += (sender, args) => DemoModeStateChanged(sender, args);
            _demoModeStateTimers.AppChanged += ChangedAppTimerTick;
            _demoModeStateTimers.CountdownChanged += (sender, args) => DemoModeCountdownChanged(sender, args);

            player.SkeletonChanged += OnPlayerChanged;
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Called when player was changed (this means a new skeleton is availible).
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="args"> The <see cref="VideoWall.Interfaces.SkeletonChangedEventArgs" /> instance containing the event data. </param>
        private void OnPlayerChanged(object sender, SkeletonChangedEventArgs args)
        {
            if (_player.Skeleton != null) _demoModeStateTimers.SkeletonChanged();
        }

        /// <summary>
        ///   Changes the color and app.
        /// </summary>
        private void ChangeColorAndApp()
        {
            CurrentBackgroundColor = _demoModeConfig.BackgroundColors.RandomElement();
            DemoModeColorChanged(this, null);
            DemoModeAppChanged(this, null);
        }

        /// <summary>
        ///   Called when the change app timer ticks.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.EventArgs" /> instance containing the event data. </param>
        private void ChangedAppTimerTick(object sender, EventArgs e)
        {
            ChangeColorAndApp();
        }

        #endregion
    }
}
