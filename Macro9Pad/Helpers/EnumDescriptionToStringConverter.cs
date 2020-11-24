// <copyright file="EnumDescriptionToStringConverter.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Data;

namespace Macro9Pad.Helpers
{
  /// <summary>Converts an Enum to a string of its descriptor.</summary>
  public class EnumDescriptionToStringConverter : IValueConverter
  {
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null)
      {
        return EnumHelper.GetEnumDescriptionString((Enum)value);
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
