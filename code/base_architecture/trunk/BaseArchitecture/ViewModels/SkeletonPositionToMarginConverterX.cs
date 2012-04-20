using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;

namespace ViewModels
{
    public class SkeletonPositionToMarginConverterX : SkeletonPositionToMarginConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var t = (Thickness) base.Convert(value, targetType, parameter, culture);
            return t.Left;
        }
    }
    public class SkeletonPositionToMarginConverterY : SkeletonPositionToMarginConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var t = (Thickness) base.Convert(value, targetType, parameter, culture);
            return t.Top;
        }
    }
}