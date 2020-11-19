// <copyright file="ButtonToStringDescriptorConverter.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using Macro9Pad.Device.Models;

namespace Macro9Pad.Helpers
{
  /// <summary>Converts Button values to a string.</summary>
  public class ButtonToStringDescriptorConverter : IValueConverter
  {
    /// <inheritdoc/>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      StringBuilder output = new StringBuilder();
      if (value != null)
      {
        ButtonModel button = (ButtonModel)value;
        string modifierString = this.ModifierToString(button.Modifier);
        if (!string.IsNullOrEmpty(modifierString))
        {
          output.Append(modifierString);
          output.Append(" + ");
        }

        string buttonString = this.ButtonToString(button.Button);
        if (!string.IsNullOrEmpty(buttonString))
        {
          output.Append(buttonString);
        }
      }

      return output.ToString();
    }

    /// <inheritdoc/>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve string descriptor of button.
    /// </summary>
    /// <param name="button">Button to convert.</param>
    /// <returns>Button as string description.</returns>
    private string ButtonToString(byte button)
    {
      Enum.TryParse(typeof(HIDKeyboardScanCode), button.ToString(CultureInfo.InvariantCulture), out object enumButton);
      HIDKeyboardScanCode convertedEnumButton = (HIDKeyboardScanCode)enumButton;

      string output = EnumHelper.GetEnumDescriptionString(convertedEnumButton);

      return output;
    }

    /// <summary>
    /// Retrieve string descriptor of modifier.
    /// </summary>
    /// <param name="modifier">Modifier to convert.</param>
    /// <returns>Modifier as string description.</returns>
    private string ModifierToString(byte modifier)
    {
      StringBuilder output = new StringBuilder();
      Enum.TryParse(typeof(HIDKeyboardModifierMasks), modifier.ToString(CultureInfo.InvariantCulture), out object convertedMask);
      HIDKeyboardModifierMasks convertedModifierMask = (HIDKeyboardModifierMasks)convertedMask;

      var possibleEnums = Enum.GetValues(typeof(HIDKeyboardModifierMasks));
      var setValues = new List<Enum>();
      foreach (var enumValue in possibleEnums)
      {
        var convertedEnumValue = (HIDKeyboardModifierMasks)enumValue;
        if (convertedModifierMask.HasFlag(convertedEnumValue))
        {
          setValues.Add(convertedEnumValue);
        }
      }

      int iterateCount = setValues.Count;
      foreach (var singleValue in setValues)
      {
        var name = EnumHelper.GetEnumDescriptionString(singleValue);

        if (name != null)
        {
          if (name != EnumHelper.GetEnumDescriptionString(HIDKeyboardModifierMasks.None))
          {
            output.Append(name);
            iterateCount--;
            if (iterateCount > 1)
            {
              output.Append(" + ");
            }
          }
          else
          {
            iterateCount--;
          }
        }
      }

      return output.ToString();
    }
  }
}
