using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectTrackingVisualizer.Service;

namespace ObjectTrackingVisualizer.ViewModels
{
    public class TrackedElement : Notifier
    {
        private double _left;
        public double Left
        {
            get { return _left; }
            set { _left = Math.Abs(value); Notify("Left"); }
        }

        private double _top;
        public double Top
        {
            get { return _top; }
            set { _top = Math.Abs(value); Notify("Top"); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; Notify("Name"); }
        }

        public int Id { get; set; }
    }
}
