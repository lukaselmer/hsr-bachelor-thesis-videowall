using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

namespace Views
{
    public class SkeletonPositionToMarginConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new Thickness(0);

            var handJoint = (Joint)value;
            var nj = handJoint.ScaleTo(500, 500);
            var skeletonPoint = nj.Position;

            return new Thickness(skeletonPoint.X, skeletonPoint.Y, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}