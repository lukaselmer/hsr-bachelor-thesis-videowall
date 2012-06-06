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

using System.Reflection;
using log4net;

#endregion

namespace VideoWall.Common.Logging
{
    /// <summary>
    ///   The logger wrapper.
    /// </summary>
    /// <remarks>
    ///   Reviewed by Lukas Elmer, 05.06.2012
    /// </remarks>
    public static class Logger
    {
        #region Declarations

        /// <summary>
        ///   The Logger
        /// </summary>
        private static readonly ILog TheLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Properties

        /// <summary>
        ///   Gets the currrent logger
        /// </summary>
        public static ILog Get { get { return TheLogger; } }

        #endregion
    }
}
