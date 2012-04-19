using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ViewModels
{
    public interface ICursorViewModel : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        Point Position { get; }

        double WindowWidth { set; }
        double WindowHeight { set; }

        ICommand RedCommand { get; }
        ICommand BlueCommand { get; }
        ICommand GreenCommand { get; }
        Color Background { get; }
    }
}
