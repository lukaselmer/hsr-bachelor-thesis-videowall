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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PosterApp.ServiceModels;
using VideoWall.Common.ViewHelpers;

#endregion

namespace PosterApp.ViewModels
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    public class PosterViewModel : Notifier
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        private readonly PosterService _posterService;
        private Poster _currentPoster;
        private string _name;
        private List<Poster> _posters;

        #endregion

        #region Properties

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
            private set
            {
                _currentPoster = value;
                Notify("CurrentPoster");
            }
        }

        /// <summary>
        ///   Gets or sets the posters.
        /// </summary>
        /// <value> The posters. </value>
        private List<Poster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        /// <summary>
        ///   Gets or sets the name.
        /// </summary>
        /// <value> The name. </value>
        private string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterViewModel" /> class.
        /// </summary>
        /// <param name="posterService"> The poster service. </param>
        public PosterViewModel(PosterService posterService)
        {
            _posterService = posterService;
            ReadFromPosterService();
            Name = "Poster";
            NavigateToLeftCommand = new Command(OnNavigateToLeft);
            NavigateToRightCommand = new Command(OnNavigateToRight);
        }

        #endregion

        #region Methods

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

        #endregion
    }
}
