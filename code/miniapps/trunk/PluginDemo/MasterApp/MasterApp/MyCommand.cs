using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MasterApp
{
    public class MyCommand : ICommand
    {
        private readonly Action<object> _onAddPlugin;

        public MyCommand(Action<object> onAddPlugin)
        {
            Debug.Assert(onAddPlugin != null, "onAddPlugin != null");
            _onAddPlugin = onAddPlugin;
        }

        public void Execute(object parameter)
        {
            _onAddPlugin(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}