using System.Threading;
using System;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectSimulator : IDisposable
    {
        private readonly KinectTracker _kinectTracker;
        private readonly Thread _t;
        private int _counter;
        private bool _running = true;

        public KinectSimulator(KinectTracker kinectTracker)
        {
            _kinectTracker = kinectTracker;
            _t = new Thread(DoWork);
            _t.Start();
        }

        private void DoWork()
        {
            while (_running)
            {
                _counter += 1;
                //_kinectTracker.OnObjectMove(4, _counter % 475, _counter % 290);
                //_kinectTracker.OnObjectMove(27, (2 * _counter) % 475, (_counter * 2) % 290);
                if (_counter % 100 == 0)
                {
                    //_kinectTracker._kinectService.Elements.RemoveAll((o) => true);
                    //_kinectTracker._kinectService.AddElement(new TrackedElement() { Id = 33, Left = _counter % 421, Top = _counter % 250, Name = "asdasdf"+_counter});

                }
                else if (_counter % 100 == 50)
                {
                    
                }
                Thread.Sleep(10);
            }
        }

        public void Dispose()
        {
            _running = false;
        }
    }
}