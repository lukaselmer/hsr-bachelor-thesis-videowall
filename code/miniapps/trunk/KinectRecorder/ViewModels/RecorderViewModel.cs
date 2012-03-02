using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Common;
using Microsoft.Expression.Interactivity.Core;
using Services;

namespace ViewModels
{
    public class RecorderViewModel : Notifier, IDisposable
    {
        #region Properties
        public string Status
        {
            get { return _recorder.Recording ? "Recoring" : "Idle"; }
        }

        public Color Color
        {
            get { return _recorder.Recording ? Color.FromArgb(255, 255, 196, 30) : Colors.AliceBlue; }
        }

        public ICommand StartStopCommand { get; set; }
        #endregion

        private readonly Recorder _recorder;

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

        private void RecorderModelChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Status");
            Notify("Color");
        }

        public void Dispose()
        {
            _recorder.PropertyChanged -= Notify;
        }
    }
}
