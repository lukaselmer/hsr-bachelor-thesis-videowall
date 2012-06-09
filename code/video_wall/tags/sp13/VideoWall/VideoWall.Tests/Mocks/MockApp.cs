using System.Windows.Controls;
using VideoWall.Interfaces;

namespace VideoWall.Tests.Mocks
{
    internal class MockApp : IApp
    {
        #region Properties

        public UserControl MainView { get; private set; }
        public string Name { get; private set; }
        public string DemomodeText { get; private set; }

        #endregion

        public MockApp()
        {
            Name = "MockApp";
            DemomodeText = "MockAppText";
        }
        
        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
        }
    }
}
