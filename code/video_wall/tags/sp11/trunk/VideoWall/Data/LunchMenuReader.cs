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

using System.IO;
using System.Linq;
using Common;

#endregion

namespace Data
{
    /// <summary>
    ///   Reviewed by Delia Treichler, 17.04.2012
    /// </summary>
    public class LunchMenuReader : Notifier
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LunchMenuReader" /> class.
        /// </summary>
        public LunchMenuReader()
        {
            Path = @"..\..\..\ResourceLoader\Files\LunchMenu";
        }

        /// <summary>
        ///   Gets the path of the file.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        ///   Gets the file.
        /// </summary>
        public string File { get { return Directory.GetFiles(Path, "*.jpg").First(); } }
    }
}