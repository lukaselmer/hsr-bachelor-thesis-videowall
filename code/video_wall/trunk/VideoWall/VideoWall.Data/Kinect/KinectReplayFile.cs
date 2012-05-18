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

namespace VideoWall.Data.Kinect
{
    /// <summary>
    ///   Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class KinectReplayFile
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="KinectReplayFile" /> class.
        /// </summary>
        /// <param name="path"> The path of the replay file. </param>
        public KinectReplayFile(string path)
        {
            Path = path;
        }

        /// <summary>
        ///   Gets or sets the path of the replay file.
        /// </summary>
        /// <value> The path. </value>
        public string Path { get; set; }
    }
}