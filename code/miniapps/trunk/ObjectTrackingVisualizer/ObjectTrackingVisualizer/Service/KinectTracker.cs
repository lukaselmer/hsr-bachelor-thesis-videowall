using System;
using System.Linq;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectTracker
    {
        private readonly KinectService _kinectService;

        public KinectTracker(KinectService kinectService)
        {
            _kinectService = kinectService;
        }

        public void OnObjectMove(long uuid, long x, long y)
        {
            Predicate<TrackedElement> cond = el => el.Id == uuid;
            if (_kinectService.Elements.Exists(cond))
            {
                var e = _kinectService.Elements.Find(cond);
                e.Left = x;
                e.Top = y;
            }
            else
            {
                _kinectService.Elements.Add(new TrackedElement { Id = uuid, Left = x, Top = y });
            }
        }
    }
}