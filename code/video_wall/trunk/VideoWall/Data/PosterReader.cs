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

#region Usings

using System.Collections.Generic;
using System.IO;
using Common;

#endregion

namespace Data
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class PosterReader : Notifier
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PosterReader" /> class.
        /// </summary>
        public PosterReader()
        {
            Path = @"...\...\...\Resources\Poster";
        }

        /// <summary>
        ///   Gets the path of the files.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        ///   Gets the files.
        /// </summary>
        public IEnumerable<string> Files { get { return Directory.GetFiles(Path, "*jpg"); } }
    }
}