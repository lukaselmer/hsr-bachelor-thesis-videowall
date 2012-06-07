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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.Common.Exceptions;
using VideoWall.ServiceModels.Apps.Implementation;

#endregion

namespace VideoWall.Tests.ServiceModels.Apps
{
    ///<summary>
    ///  This is a test class for ExtensionsConfigTest and is intended to contain all ExtensionsConfigTest Unit Tests.
    ///</summary>
    [TestClass]
    public class ExtensionsConfigTest
    {
        ///<summary>
        ///  A test for ExtensionsConfig Constructor.
        ///</summary>
        [TestMethod]
        public void ExtensionsConfigConstructorTest()
        {
            var extensionsDirectoryPath = FileDirectoryForTests.TestFilePrefix + "Extensions";
            var config = new ExtensionsConfig(extensionsDirectoryPath);
            var dirs = config.ExtensionDirectories.ToList();
            Assert.AreEqual(2, dirs.Count);
            Assert.AreEqual("DiagnosticsApp", dirs[0].Name);
            Assert.AreEqual("DiagnosticsApp2", dirs[1].Name);
        }

        ///<summary>
        ///  A test for ExtensionsConfig Constructor throwing an exception.
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(VideoWallException))]
        public void ExtensionsConfigConstructorTestThrowing()
        {
            var extensionsDirectoryPath = FileDirectoryForTests.TestFilePrefix + "__FolderDoesNotExist__";
            new ExtensionsConfig(extensionsDirectoryPath);
        }
    }
}
