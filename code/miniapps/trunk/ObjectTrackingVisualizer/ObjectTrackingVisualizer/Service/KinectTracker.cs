using System;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectTracker
    {
        public readonly KinectService _kinectService;

        public KinectTracker(KinectService kinectService)
        {
            _kinectService = kinectService;
        }

        public void OnObjectMove(int uuid, long x, long y)
        {
            /*Predicate<TrackedElement> cond = el => el.Id == uuid;
            if (_kinectService.ElementExists(cond))
            {
                TrackedElement e = _kinectService.FindElement(cond);
                e.Left = x;
                e.Top = y;
            }
            else
            {
                _kinectService.AddElement(new TrackedElement {Id = uuid, Left = x, Top = y});
            }*/
        }
    }
}