using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PluginApp;
using System.ComponentModel.Composition;

namespace MasterApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IMasterPlugin> Plugins { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            ExtensionManager.Init(this);
            AddNewPlugin = new MyCommand(OnAddPlugin);
        }

        private void OnAddPlugin(object parameter)
        {
        }

        public ICommand AddNewPlugin { get; private set; }
    }

    [Export(typeof(IMasterPlugin))]
    public class MyTestPlugin : IMasterPlugin
    {
        public string Name
        {
            get { return "teset"; }
        }
    }
}