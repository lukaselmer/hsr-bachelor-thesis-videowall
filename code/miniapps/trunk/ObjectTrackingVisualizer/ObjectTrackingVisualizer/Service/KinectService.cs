using System;
using System.Collections.Generic;
using System.ComponentModel;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectService : Notifier
    {
        public List<TrackedElement> Elements;

        public KinectService()
        {
            Elements = new List<TrackedElement>
                {
                    new TrackedElement {Left = 10, Top = 100, Name = "one"},
                    new TrackedElement {Left = 100, Top = 10, Name = "two"},
                    new TrackedElement {Left = 300, Top = 200, Name = "three"},
                    new TrackedElement {Left = 150, Top = 200, Name = "four"},
                };
            KinectTracker = new KinectTracker(this);
            KinectSimulator = new KinectSimulator(KinectTracker);
        }

        protected KinectSimulator KinectSimulator { get; set; }

        protected KinectTracker KinectTracker { get; set; }
    }
}