#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
//  Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using VideoWall.Common;
using ServiceModels;
using ViewModels.Helpers;

#endregion

namespace ViewModels.Posters
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class PosterViewModel : Notifier, IDisposable
    {
        private readonly PosterService _posterService;
        private Poster _currentPoster;
        private bool _isPosterViewVisible;
        private string _name;
        private List<Poster> _posters;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterViewModel" /> class.
        /// </summary>
        /// <param name="posterService"> The poster service. </param>
        public PosterViewModel(PosterService posterService)
        {
            _posterService = posterService;
            _posterService.PropertyChanged += PosterServiceChanged;
            ReadFromPosterService();
            Name = "Poster";
            NavigateToLeftCommand = new Command(OnNavigateToLeft);
            NavigateToRightCommand = new Command(OnNavigateToRight);
        }

        /// <summary>
        ///   Gets or sets the navigate to left command.
        /// </summary>
        /// <value> The navigate to left command. </value>
        public ICommand NavigateToLeftCommand { get; set; }

        /// <summary>
        ///   Gets or sets the navigate to right command.
        /// </summary>
        /// <value> The navigate to right command. </value>
        public ICommand NavigateToRightCommand { get; set; }

        /// <summary>
        ///   Gets or sets the current poster.
        /// </summary>
        /// <value> The current poster. </value>
        public Poster CurrentPoster
        {
            get { return _currentPoster; }
            set
            {
                _currentPoster = value;
                Notify("CurrentPoster");
            }
        }

        /// <summary>
        ///   Gets or sets the posters.
        /// </summary>
        /// <value> The posters. </value>
        public List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether the poster view visible.
        /// </summary>
        /// <value> <c>true</c> if the view is visible; otherwise, <c>false</c> . </value>
        public bool IsPosterViewVisible
        {
            get { return _isPosterViewVisible; }
            set
            {
                _isPosterViewVisible = value;
                Notify("IsPosterViewVisible");
            }
        }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        #region IDisposable Members

        /// <summary>
        ///   Unregisters the notification when the poster service is changed.
        /// </summary>
        public void Dispose()
        {
            _posterService.PropertyChanged -= PosterServiceChanged;
        }

        #endregion

        /// <summary>
        ///   Posters the service changed.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data. </param>
        private void PosterServiceChanged(object sender, PropertyChangedEventArgs e)
        {
            ReadFromPosterService();
        }

        /// <summary>
        ///   Reads from poster service.
        /// </summary>
        private void ReadFromPosterService()
        {
            Posters = _posterService.Posters;
            CurrentPoster = Posters.First();
        }

        /// <summary>
        ///   Called when [navigate to right].
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnNavigateToRight(object obj)
        {
            var index = _posters.IndexOf(CurrentPoster) + 1;
            CurrentPoster = index >= _posters.Count ? _posters.First() : _posters[index];
        }

        /// <summary>
        ///   Called when [navigate to left].
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnNavigateToLeft(object obj)
        {
            var index = _posters.IndexOf(CurrentPoster) - 1;
            CurrentPoster = index < 0 ? _posters.Last() : _posters[index];
        }
    }
}