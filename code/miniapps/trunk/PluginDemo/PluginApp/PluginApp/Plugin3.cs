using System.ComponentModel.Composition;

namespace PluginApp
{
    [Export(typeof(IMasterPlugin))]
    public class Plugin3 : IMasterPlugin
    {
        public string Name
        {
            get { return "MyThirdPlugin"; }
        }
    }
}