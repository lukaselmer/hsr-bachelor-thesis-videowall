using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Kinect;
using ObjectTrackingVisualizer.ViewModels;

namespace ObjectTrackingVisualizer.Service
{
    public class KinectService : Notifier, IDisposable
    {
        public List<TrackedElement> Elements;

        //public SkeletonFrame skeletonFrame;

        public KinectService()
        {
            Elements = new List<TrackedElement>();

            KinectTracker = new KinectTracker();
            KinectTracker.SkeletonsReady += SkeletonsAvailible;
            KinectSimulator = new KinectSimulator(KinectTracker);
        }

        private void SkeletonsAvailible(Skeleton[] skeletonData)
        {
            foreach (var skeleton in skeletonData)
            {
                if (skeleton.TrackingState == SkeletonTrackingState.NotTracked) continue;

                var elementIndex = Elements.FindIndex(el => el.Id == skeleton.TrackingId);

                if (elementIndex == -1) elementIndex = AddElement(new TrackedElement(skeleton));

                Elements[elementIndex].Skeleton = skeleton;
            }
            Elements.RemoveAll(el => !Array.Exists(skeletonData, skeleton =>
                skeleton.TrackingState != SkeletonTrackingState.NotTracked && skeleton.TrackingId == el.Id));
            Notify("Elements");
        }

        protected KinectSimulator KinectSimulator { get; set; }

        protected KinectTracker KinectTracker { get; set; }

        public void Dispose()
        {
            KinectTracker.Dispose();
            KinectTracker = null;

            KinectSimulator.Dispose();
            KinectSimulator = null;
        }

        public int AddElement(TrackedElement trackedElement)
        {
            Elements.Add(trackedElement);
            Notify("Elements");
            return Elements.Count - 1;
        }

        /*public TrackedElement FindxElement(Predicate<TrackedElement> cond)
        {
            var res = Elements.Find(cond);
            Notify("Elements");
            return res;
        }

        public bool ElementxExists(Predicate<TrackedElement> cond)
        {
            var res = Elements.Exists(cond);
            Notify("Elements");
            return res;
        }*/
    }
}