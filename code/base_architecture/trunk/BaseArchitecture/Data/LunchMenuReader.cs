using System.IO;
using System.Linq;
using Common;

namespace Data
{
    /// <summary>
    /// Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuReader : Notifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LunchMenuReader"/> class.
        /// </summary>
        public LunchMenuReader()
        {
            Path = @"...\...\...\Resources\LunchMenu";
        }
        public string Path { get; private set; }

        /// <summary>
        /// Gets the file.
        /// </summary>
        public string File
        {
            get { return Directory.GetFiles(Path, "*jpg").First(); }
        }
    }
}
