using System.ComponentModel.Composition;
using System.Windows.Controls;
using VideoWall.Interfaces;

namespace ShapeGame.App
{
    [Export(typeof(IApp))]
    public class ShapeGameApp : IApp
    {
        private UserControl _shapeGame;

        public UserControl MainView
        {
            get { return _shapeGame; }
        }

        public string Name
        {
            get { return "Shape Game"; }
        }

        public string DemomodeText
        {
            get { return "Verspielt?"; }
        }

        public void Activate(IVideoWallServiceProvider videoWallServiceProvider)
        {
            _shapeGame = new ShapeGameUserControl(videoWallServiceProvider.GetExtension<ISkeletonService>());
        }
    }
}
