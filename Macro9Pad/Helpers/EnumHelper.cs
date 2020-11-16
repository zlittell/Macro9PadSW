// <copyright file="EnumHelper.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.ComponentModel;
using System.Reflection;

namespace Macro9Pad.Helpers
{
  /// <summary>Enum Descriptor Helper.</summary>
  public static class EnumHelper
  {
    /// <summary>Get Enum Descriptor.</summary>
    /// <param name="value">Enum value to get descriptor of.</param>
    /// <returns>String of descriptor or just enum value if not available.</returns>
    public static string GetEnumDescriptionString(Enum value)
    {
      if (value != null)
      {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
          return attributes[0].Description;
        }
        else
        {
          return value.ToString();
        }
      }

      return string.Empty;
    }
  }
}
