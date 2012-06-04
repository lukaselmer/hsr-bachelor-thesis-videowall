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

namespace VideoWall.Data.Kinect.Implementation
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 23.03.2012
    ///   This class is for development only.
    /// </summary>
    // ReSharper disable ClassNeverInstantiated.Global
    // Created by unity, so ReSharper thinks this class can be made abstract, which is wrong.
    internal class KinectReplayFile
    // ReSharper restore ClassNeverInstantiated.Global
    {
        #region Properties

        /// <summary>
        ///   Gets or sets the path of the replay file.
        /// </summary>
        /// <value> The path. </value>
        public string Path { get; private set; }

        #endregion

        #region Constructors / Destructor

        /// <summary>
        ///   Initializes a new instance of the <see cref="KinectReplayFile" /> class.
        /// </summary>
        /// <param name="path"> The path of the replay file. </param>
        public KinectReplayFile(string path)
        {
            Path = path;
        }

        #endregion
    }
}