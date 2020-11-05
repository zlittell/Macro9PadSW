// <copyright file="RGBToBrushConverter.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Macro9Pad.Models;

namespace Macro9Pad.Helpers
{
    /// <summary>Converter for RGB(bytes) to color brush.</summary>
    public class RGBToBrushConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            RGBModel rgb = new RGBModel();

            if (value != null)
            {
                rgb = (RGBModel)value;
            }

            return new SolidColorBrush(Color.FromArgb(rgb.Brightness, rgb.Red, rgb.Green, rgb.Blue));
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
