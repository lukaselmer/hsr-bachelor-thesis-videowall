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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoWall.Tests.Mocks;
using VideoWall.ViewModels.Menu;

#endregion

namespace VideoWall.Tests.ViewModels
{
    ///<summary>
    ///  This is a test class for AppViewModelTest and is intended to contain all AppViewModelTest Unit Tests.
    ///</summary>
    [TestClass]
    public class AppViewModelTest
    {
        ///<summary>
        ///  A test for AppViewModel Constructor.
        ///</summary>
        [TestMethod]
        public void AppViewModelConstructorTest()
        {
            var app = new MockApp();
            var model = new AppViewModel(app);
            Assert.AreEqual(app.DemomodeText, model.App.DemomodeText);
            Assert.AreEqual(app.MainView, model.App.MainView);
            Assert.AreEqual(app.Name, model.App.Name);
            Assert.AreSame(AppViewModel_Accessor.UnselectedMenuStyle, model.MenuStyle);
            model.Selected = true;
            Assert.AreSame(AppViewModel_Accessor.SelectedMenuStyle, model.MenuStyle);
        }
    }
}
