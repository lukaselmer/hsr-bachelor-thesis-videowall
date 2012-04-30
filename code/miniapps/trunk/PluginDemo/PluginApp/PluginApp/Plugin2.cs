using System.ComponentModel.Composition;

namespace PluginApp
{
    [Export(typeof(IMasterPlugin))]
    public class Plugin2 : IMasterPlugin
    {
        public string Name
        {
            get { return "MySecondPlugin"; }
        }
    }
}