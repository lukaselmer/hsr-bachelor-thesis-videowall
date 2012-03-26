using System;
using System.ComponentModel;
using Microsoft.Win32;

namespace Services.Recorder
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class Recorder : Common.Notifier, IDisposable
    {
        private readonly KinectRecorder _kinectRecorder;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recorder"/> class.
        /// </summary>
        public Recorder()
        {
            _kinectRecorder = new KinectRecorder();
            _kinectRecorder.PropertyChanged += NotifyChildChanged;
        }

        /// <summary>
        /// Notifies that the child changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void NotifyChildChanged(object sender, PropertyChangedEventArgs e)
        {
            Notify("Recording");
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Recorder"/> is recording.
        /// </summary>
        /// <value>
        ///   <c>true</c> if recording; otherwise, <c>false</c>.
        /// </value>
        public bool Recording { get { return _kinectRecorder.Recording; } }

        /// <summary>
        /// Starts the recording. Saves the file to specified path.
        /// </summary>
        public void StartRecording()
        {
            if (Recording) return;

            var saveFileDialog = new SaveFileDialog { Title = "Select filename", Filter = "Replay files|*.replay" };
            if (saveFileDialog.ShowDialog() != true) { return; }
            var pathToFile = saveFileDialog.FileName;

            _kinectRecorder.Start(pathToFile);
        }

        /// <summary>
        /// Stops the recording.
        /// </summary>
        public void StopRecording()
        {
            if (!Recording) return;
            _kinectRecorder.Stop();
            Notify("Recording");
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Recording) StopRecording();
            _kinectRecorder.PropertyChanged -= NotifyChildChanged;
        }
    }
}
