#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using VideoWall.Interfaces;

#endregion

namespace PosterApp.Startup
{
    public class LocalFileService : IFileService
    {
        #region Constructors / Destructor

        public LocalFileService(string directory)
        {
            ResourceDirectory = directory;
        }

        #endregion

        #region Methods

        public string ResourceDirectory { get; private set; }

        #endregion
    }
}
