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

using System.Reflection;
using log4net;

#endregion

namespace VideoWall.Common
{
    /// <summary>
    ///   The Logger wrapper
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///   The Logger
        /// </summary>
        private static readonly ILog TheLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///   Gets the currrent logger
        /// </summary>
        public static ILog Get { get { return TheLogger; } }
    }
}