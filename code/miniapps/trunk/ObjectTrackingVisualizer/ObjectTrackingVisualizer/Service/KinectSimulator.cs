using System.Threading;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectSimulator
    {
        private readonly KinectTracker _kinectTracker;
        private int _counter;
        private readonly Thread _t;

        public KinectSimulator(KinectTracker kinectTracker)
        {
            _kinectTracker = kinectTracker;
            _t = new Thread(DoWork);
            _t.Start();
        }

        public void DoWork()
        {
            while (true)
            {
                _counter += 1;
                _kinectTracker.OnObjectMove(4, _counter, _counter);
                Thread.Sleep(10);
            }
        }
    }
}