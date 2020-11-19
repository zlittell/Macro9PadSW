// <copyright file="BooleanIsDirtyToButtonBrushConverter.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Macro9Pad.Helpers
{
  /// <summary>Converts boolean to red button brush.</summary>
  public class BooleanIsDirtyToButtonBrushConverter : IValueConverter
  {
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null)
      {
        if ((bool)value)
        {
          return new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
      }

      return null;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
