﻿using System;
using System.ComponentModel;
using Common;
using Services;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuViewModel : Notifier, IDisposable
    {
        private LunchMenu _lunchMenu;
        private bool _isLunchMenuViewVisible;
        private string _name;
        private readonly LunchMenuService _lunchMenuService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenuViewModel"/> class.
        /// </summary>
        /// <param name="lunchMenuService">The lunch menu service.</param>
        public LunchMenuViewModel(LunchMenuService lunchMenuService)
        {
            _lunchMenuService = lunchMenuService;
            _lunchMenuService.PropertyChanged += LunchMenuServiceChanged;
            ReadFromLunchMenuService();
            Name = "Mittagsmenü";
        }

        /// <summary>
        /// Gets or sets and notifies the lunch menu.
        /// </summary>
        /// <value>
        /// The lunch menu.
        /// </value>
        public LunchMenu LunchMenu
        {
            get { return _lunchMenu; }
            set
            {
                _lunchMenu = value;
                Notify("LunchMenu");
            }
        }

        /// <summary>
        /// Gets or sets and notifies the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        /// <summary>
        /// Gets or sets and notifies a value indicating whether the lunch menu view is visible.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the lunch menu view is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsLunchMenuViewVisible
        {
            get { return _isLunchMenuViewVisible; }
            set
            {
                _isLunchMenuViewVisible = value;
                Notify("IsLunchMenuViewVisible");
            }
        }

        /// <summary>
        /// Reads from lunch menu service.
        /// </summary>
        private void ReadFromLunchMenuService()
        {
            LunchMenu = _lunchMenuService.LunchMenu;
        }

        /// <summary>
        /// Calls ReadFromLunchMenuService when LunchMenuService was changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LunchMenuServiceChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromLunchMenuService();
        }

        /// <summary>
        /// Unregisters the notification.
        /// </summary>
        public void Dispose()
        {
            _lunchMenuService.PropertyChanged -= LunchMenuServiceChanged;
        }
    }
}
