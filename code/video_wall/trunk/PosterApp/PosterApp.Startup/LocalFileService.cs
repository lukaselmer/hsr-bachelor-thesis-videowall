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

using VideoWall.Interfaces;

#endregion

namespace PosterApp.Startup
{
    public class LocalFileService : IFileService
    {
        public LocalFileService(string directory)
        {
            ResourceDirectory = directory;
        }

        public string ResourceDirectory { get; private set; }
    }
}