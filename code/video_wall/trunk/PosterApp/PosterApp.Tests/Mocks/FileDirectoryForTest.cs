using System;
using System.IO;

namespace PosterApp.Tests.Mocks
{
    /// <summary>
    /// This class locates the test files. The problem is that mstest and dotcover have different test file locations.
    /// </summary>
    internal static class FileDirectoryForTests
    {
        public static string TestFilePrefix
        {
            get
            {
                if (new DirectoryInfo("TestFiles").Exists) return "";
                var testFiles = new DirectoryInfo("../../../TestFiles");
                if (testFiles.Exists) return testFiles.FullName + "/";
                throw new Exception("Test files not found!");
            }
        }
    }
}