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
using PosterApp.ServiceModels.Interfaces;
using VideoWall.Common.ViewHelpers;

#endregion

namespace PosterApp.ViewModels
{
    /// <summary>
    ///   The poster view model.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Delia Treichler, 17.04.2012
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    // ReSharper disable ClassNeverInstantiated.Global
    public class PosterViewModel : Notifier
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Declarations

        /// <summary>
        /// The poster service.
        /// </summary>
        private readonly IPosterService _posterService;

        /// <summary>
        /// The current poster.
        /// </summary>
        private IPoster _currentPoster;

        /// <summary>
        /// All posters.
        /// </summary>
        private List<IPoster> _posters;

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
        public IPoster CurrentPoster
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
        private List<IPoster> Posters
        {
            get { return _posters; }
            set
            {
                _posters = value;
                Notify("Posters");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterViewModel" /> class.
        /// </summary>
        /// <param name="posterService"> The poster service. </param>
        public PosterViewModel(IPosterService posterService)
        {
            _posterService = posterService;
            LoadPosters();
            NavigateToLeftCommand = new Command(OnNavigateToLeft);
            NavigateToRightCommand = new Command(OnNavigateToRight);
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Reads from poster service.
        /// </summary>
        private void LoadPosters()
        {
            Posters = _posterService.Posters.ToList();
            CurrentPoster = Posters.First();
        }

        /// <summary>
        ///   Called when user wants to navigate to the right.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnNavigateToRight(object obj)
        {
            CurrentPoster = _posters[(_posters.IndexOf(CurrentPoster) + 1) % _posters.Count];
        }

        /// <summary>
        ///   Called when user wants to navigate to the left.
        /// </summary>
        /// <param name="obj"> The obj. </param>
        private void OnNavigateToLeft(object obj)
        {
            CurrentPoster = _posters[(_posters.IndexOf(CurrentPoster) - 1 + _posters.Count) % _posters.Count];
        }

        #endregion
    }
}
