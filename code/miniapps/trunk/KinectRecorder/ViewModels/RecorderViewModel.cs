using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Services;
using Services.Recorder;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class RecorderViewModel : Notifier, IDisposable
    {
        #region Properties
        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status
        {
            get { return _recorder.Recording ? "Recoring" : "Idle"; }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        public Color Color
        {
            get { return _recorder.Recording ? Color.FromArgb(255, 255, 196, 30) : Colors.AliceBlue; }
        }

        public ICommand StartStopCommand { get; set; }
        #endregion

        private readonly Recorder _recorder;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecorderViewModel"/> class.
        /// </summary>
        /// <param name="recorder">The recorder.</param>
        public RecorderViewModel(Recorder recorder)
        {
            _recorder = recorder;
            _recorder.PropertyChanged += RecorderModelChanged;
            StartStopCommand = new ActionCommand(() =>
            {
                if (_recorder.Recording) _recorder.StopRecording();
                else _recorder.StartRecording();
            });
        }

        /// <summary>
        /// Notifies when the recorder model was changed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void RecorderModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Status");
            Notify("Color");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _recorder.PropertyChanged -= Notify;
        }
    }
}
