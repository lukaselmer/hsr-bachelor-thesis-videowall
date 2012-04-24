using System.Collections.Generic;
using System.IO;
using Common;

namespace Data
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class PosterReader : Notifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PosterReader"/> class.
        /// </summary>
        public PosterReader()
        {
            Path = @"...\...\...\Resources\Poster";
        }

        /// <summary>
        /// Gets the path of the files.
        /// </summary>
        public string Path { get; private set; }
        
        /// <summary>
        /// Gets the files.
        /// </summary>
        public IEnumerable<string> Files
        {
            get { return Directory.GetFiles(Path, "*jpg"); }
        }
    }
}
