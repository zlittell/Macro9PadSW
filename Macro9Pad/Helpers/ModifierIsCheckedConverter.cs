// <copyright file="ModifierIsCheckedConverter.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Globalization;
using System.Windows.Data;

namespace Macro9Pad.Helpers
{
  /// <summary>Converts request to whether a modifier is checked.</summary>
  public class ModifierIsCheckedConverter : IValueConverter
  {
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      Enum.TryParse(typeof(HIDKeyboardModifierMasks), value?.ToString(), out object convertedMask);
      HIDKeyboardModifierMasks convertedModifierMask = (HIDKeyboardModifierMasks)convertedMask;

      switch (parameter)
      {
        case "LeftControl":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.LeftControl))
          {
            return true;
          }

          break;
        }

        case "LeftShift":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.LeftShift))
          {
            return true;
          }

          break;
        }

        case "LeftAlt":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.LeftAlt))
          {
            return true;
          }

          break;
        }

        case "LeftMeta":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.LeftMeta))
          {
            return true;
          }

          break;
        }

        case "RightControl":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.RightControl))
          {
            return true;
          }

          break;
        }

        case "RightShift":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.RightShift))
          {
            return true;
          }

          break;
        }

        case "RightAlt":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.RightAlt))
          {
            return true;
          }

          break;
        }

        case "RightMeta":
        {
          if (convertedModifierMask.HasFlag(HIDKeyboardModifierMasks.RightMeta))
          {
            return true;
          }

          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(nameof(parameter), "parameter needs to match a possible modifier");
        }
      }

      return false;
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
