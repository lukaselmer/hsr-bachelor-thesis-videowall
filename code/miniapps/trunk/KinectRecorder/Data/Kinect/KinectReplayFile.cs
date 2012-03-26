namespace Data.Kinect
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class KinectReplayFile
    {
        /// <summary>
        /// Gets or sets the path of the replay file.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinectReplayFile"/> class.
        /// </summary>
        /// <param name="path">The path of the replay file.</param>
        public KinectReplayFile(string path)
        {
            Path = path;
        }
    }
}