using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using ObjectTrackingVisualizer.Service;

namespace ObjectTrackingVisualizer.ViewModels
{
    class ApplicationViewModel : Notifier
    {
        public ICollectionView TrackedElements { get; set; }
        private readonly KinectService _kinectService;

        public ApplicationViewModel()
        {
            _kinectService = new KinectService();
            TrackedElements = CollectionViewSource.GetDefaultView(_kinectService.Elements);
            Notify("TrackedElements");
        }
    }
}
