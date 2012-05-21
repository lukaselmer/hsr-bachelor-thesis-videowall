#region Header

// ------------------------ Licence / Copyright ------------------------
// 
// HSR Video Wall
// Copyright © Lukas Elmer, Christina Heidt, Delia Treichler
// All Rights Reserved
// 
// Authors:
// Lukas Elmer, Christina Heidt, Delia Treichler
// 
// ---------------------------------------------------------------------

#endregion

#region Usings

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

#endregion

namespace VideoWall.Views.Helpers
{
    internal class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        #region Methods

        /// <summary>
        ///   Converts a boolean to a visibility. True = Visibility.Visible False = Visibility.Collapsed
        /// </summary>
        /// <param name="value"> The value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> A converted value. If the method returns null, the valid null value is used. </returns>
        /// <remarks>
        /// </remarks>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool) value) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///   Converts a visibility to a boolean. Visibility.Visible = True Visibility.Collapsed = False
        /// </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> A converted value. If the method returns null, the valid null value is used. </returns>
        /// <remarks>
        /// </remarks>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Visibility) value) == Visibility.Visible;
        }

        /// <summary>
        ///   Returns an object that is set as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider"> Object that can provide services for the markup extension. </param>
        /// <returns> The object value to set on the property where the extension is applied. </returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }
}