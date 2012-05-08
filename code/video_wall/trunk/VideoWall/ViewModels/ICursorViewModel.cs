using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Services.HandCursor;

namespace ViewModels
{

    /// <summary>
    /// The Interface of the Cursor View Model
    /// </summary>
    public interface ICursorViewModel : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the status.
        /// </summary>
        Point Position { get; }

        event HandChanged HandChanged;

        /// <summary>
        /// Sets the width of the window.
        /// </summary>
        /// <value>
        /// The width of the window.
        /// </value>
        double WindowWidth { set; }
        /// <summary>
        /// Sets the height of the window.
        /// </summary>
        /// <value>
        /// The height of the window.
        /// </value>
        double WindowHeight { set; }
    }
}
