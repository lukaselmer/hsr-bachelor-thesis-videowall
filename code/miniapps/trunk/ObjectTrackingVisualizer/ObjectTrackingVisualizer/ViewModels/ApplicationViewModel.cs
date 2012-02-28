using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;
using ObjectTrackingVisualizer.Service;

namespace ObjectTrackingVisualizer.ViewModels
{
    class ApplicationViewModel : Notifier, IDisposable, INotifyCollectionChanged
    {
        public ICollectionView TrackedElements { get; set; }
        public readonly KinectService _kinectService;

        public ApplicationViewModel()
        {
            _kinectService = new KinectService();
            TrackedElements = CollectionViewSource.GetDefaultView(_kinectService.Elements);
            Notify("TrackedElements");
            _kinectService.PropertyChanged += (sender, args) => TrackedElements.Refresh();

        }

        public void Dispose()
        {
            _kinectService.Dispose();
        }

        public void AddElement()
        {

            //_kinectService.AddElement();
            //new ObservableCollection<TrackedElement>();
            //TrackedElements.Refresh();
            //TrackedElements.Filter = (o => true);
            //Notify("TrackedElements");
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }
}
