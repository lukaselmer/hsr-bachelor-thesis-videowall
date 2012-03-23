using System;
using System.ComponentModel;
using Microsoft.Win32;

namespace Services.Recorder
{
    public class Recorder : Common.Notifier, IDisposable
    {
        private readonly KinectRecorder _kinectRecorder;

        public Recorder()
        {
            _kinectRecorder = new KinectRecorder();
            _kinectRecorder.PropertyChanged += NotifyChildChanged;
        }

        private void NotifyChildChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Recording");
        }

        public bool Recording { get { return _kinectRecorder.Recording; } }

        public void StartRecording()
        {
            if (Recording) return;

            var saveFileDialog = new SaveFileDialog { Title = "Select filename", Filter = "Replay files|*.replay" };
            if (saveFileDialog.ShowDialog() != true) { return; }
            var pathToFile = saveFileDialog.FileName;

            _kinectRecorder.Start(pathToFile);
        }

        public void StopRecording()
        {
            if (!Recording) return;
            _kinectRecorder.Stop();
            Notify("Recording");
        }

        public void Dispose()
        {
            if (Recording) StopRecording();
            _kinectRecorder.PropertyChanged -= NotifyChildChanged;
        }
    }
}
