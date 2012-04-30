using System.ComponentModel.Composition;

namespace PluginApp
{
    [Export(typeof(IMasterPlugin))]
    public class Plugin1 : IMasterPlugin
    {
        public string Name
        {
            get { return "MyFirstPlugin"; }
        }
    }
}