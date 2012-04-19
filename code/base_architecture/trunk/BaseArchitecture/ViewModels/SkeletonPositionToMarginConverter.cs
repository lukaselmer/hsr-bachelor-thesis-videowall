using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

namespace ViewModels
{
    /// <summary>
    /// Reviewed by Christina Heidt, 23.03.2012
    /// </summary>
    public class SkeletonPositionToMarginConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A thickness.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new Thickness(0);

            var handJoint = (Joint)value;
            var joint = handJoint.ScaleTo(153, 153);
            var skeletonPoint = joint.Position;

            return new Thickness(skeletonPoint.X, skeletonPoint.Y, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
