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
using System.Windows;
using System.Windows.Media;
using VideoWall.Common;
using VideoWall.Common.Extensions;
using VideoWall.Common.Helpers;
using VideoWall.Common.ViewHelpers;
using VideoWall.Interfaces;
using VideoWall.ServiceModels.DemoMode;
using VideoWall.ServiceModels.DemoMode.Implementation;
using VideoWall.ServiceModels.DemoMode.Interfaces;
using VideoWall.ServiceModels.Player;
using VideoWall.ViewModels.Menu;
using VideoWall.ViewModels.Skeletton;

#endregion

namespace VideoWall.ViewModels.DemoMode
{
    /// <summary>
    ///   The DemoModeViewModel
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Class is instantiated by the unity container, so ReSharper thinks that
    // this class could be made abstract, which is wrong
    public class DemoModeViewModel : Notifier
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The menu view model
        /// </summary>
        private readonly MenuViewModel _menuViewModel;

        /// <summary>
        /// The player view model
        /// </summary>
        private readonly PlayerViewModel _playerViewModel;

        /// <summary>
        /// The demo mode service
        /// </summary>
        private readonly IDemoModeService _demoModeService;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the player view model.
        /// </summary>
        /// <value> The player view model. </value>
        public PlayerViewModel PlayerViewModel { get { return _playerViewModel; } }

        /// <summary>
        ///   Gets the visibility.
        /// </summary>
        public Visibility DemoModeVisibility { get { return _demoModeService.State == VideoWallState.Active ? Visibility.Collapsed : Visibility.Visible; } }

        /// <summary>
        ///   Gets a value indicating whether the countdown is visible or not.
        /// </summary>
        public Visibility CountDownVisibility { get { return _demoModeService.State == VideoWallState.Countdown ? Visibility.Visible : Visibility.Collapsed; } }

        /// <summary>
        ///   Gets a value indicating whether the text is visible or not.
        /// </summary>
        public Visibility TeaserVisibility { get { return _demoModeService.State == VideoWallState.Teaser ? Visibility.Visible : Visibility.Collapsed; } }

        /// <summary>
        ///   Gets the teaser text.
        /// </summary>
        public string TeaserText { get { return _menuViewModel.CurrentApp.App.DemomodeText; } }

        /// <summary>
        /// Gets or sets the current color.
        /// </summary>
        /// <value>
        /// The color of the current.
        /// </value>
        public Color CurrentBackgroundColor
        {
            get { return _demoModeService.CurrentBackgroundColor; }
        }

        /// <summary>
        ///   Gets the countdown which counts down when a skeleton is tracked (before switch from demo mode to app mode).
        /// </summary>
        public int Countdown
        {
            get { return _demoModeService.Countdown; }
        }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoModeViewModel"/> class.
        /// </summary>
        /// <param name="playerViewModel">The player view model.</param>
        /// <param name="menuViewModel">The menu view model.</param>
        /// <param name="demoModeService">The demo mode service.</param>
        public DemoModeViewModel(PlayerViewModel playerViewModel, MenuViewModel menuViewModel, IDemoModeService demoModeService)
        {
            PreOrPostCondition.AssertNotNull(menuViewModel, "menuViewModel");
            PreOrPostCondition.AssertNotNull(playerViewModel, "playerViewModel");
            PreOrPostCondition.AssertNotNull(demoModeService, "demoModeService");

            _demoModeService = demoModeService;
            _demoModeService.DemoModeStateChanged += DemoModeStateChanged;
            _demoModeService.DemoModeAppChanged += DemoModeAppChanged;
            _demoModeService.DemoModeColorChanged += DemoModeColorChanged;
            _demoModeService.DemoModeCountdownChanged += DemoModeCountdownChanged;

            _menuViewModel = menuViewModel;
            _menuViewModel.PropertyChanged += (sender, args) => Notify("DemoModeText");

            _playerViewModel = playerViewModel;
            _playerViewModel.WidthAndHeight = 500; //TODO: use relative value or extract to options
        }

        #endregion

        #region Methods

        /// <summary>
        /// Occurs when the demo mode countdown changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DemoModeCountdownChanged(object sender, EventArgs eventArgs)
        {
            Notify("Countdown");
        }

        /// <summary>
        /// Occurs when the demo mode color changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DemoModeColorChanged(object sender, EventArgs eventArgs)
        {
            Notify("CurrentBackgroundColor");
        }

        /// <summary>
        /// Occurs when the demo mode app changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DemoModeAppChanged(object sender, EventArgs eventArgs)
        {
            _menuViewModel.ChangeToRandomApp();
        }

        /// <summary>
        /// Occurs when the demo mode state changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DemoModeStateChanged(object sender, EventArgs args)
        {
            Notify("DemoModeVisibility");
            Notify("CountDownVisibility");
            Notify("TeaserVisibility");
        }

        #endregion
    }
}
