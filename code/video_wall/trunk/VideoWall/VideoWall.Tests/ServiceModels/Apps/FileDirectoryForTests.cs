#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright � Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.IO;

#endregion

namespace VideoWall.Tests.ServiceModels.Apps
{
    /// <summary>
    ///   This class locates the test files. The problem is that mstest and dotcover have different test file locations.
    /// </summary>
    internal static class FileDirectoryForTests
    {
        public static string TestFilePrefix
        {
            get
            {
                if (new DirectoryInfo("Extensions").Exists) return "";
                var testFiles = new DirectoryInfo("../../../TestFiles");
                if (testFiles.Exists) return testFiles.FullName + "/";
                throw new Exception("Test files not found!");
            }
        }
    }
}
