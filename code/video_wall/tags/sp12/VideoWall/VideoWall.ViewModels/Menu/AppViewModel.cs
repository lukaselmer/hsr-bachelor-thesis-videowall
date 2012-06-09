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

using VideoWall.Common;
using VideoWall.Interfaces;

#endregion

namespace VideoWall.ViewModels.Menu
{
    /// <summary>
    ///   The app view model wrapps the app
    /// </summary>
    public class AppViewModel : Notifier
    {
        #region Declarations

        private IApp _app;
        private bool _selected;

        #endregion

        #region Properties

        /// <summary>
        ///   The app
        /// </summary>
        public IApp App
        {
            get { return _app; }
            set
            {
                _app = value;
                Notify("App");
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="AppViewModel" /> is active.
        /// </summary>
        /// <value> <c>true</c> if active; otherwise, <c>false</c> . </value>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                Notify("Selected");
            }
        }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="AppViewModel" /> class.
        /// </summary>
        /// <param name="app"> The app. </param>
        public AppViewModel(IApp app)
        {
            App = app;
        }

        #endregion
    }
}
