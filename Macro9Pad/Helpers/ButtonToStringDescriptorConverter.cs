using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using Macro9Pad.Device.Models;

namespace Macro9Pad.Helpers
{
  public class ButtonToStringDescriptorConverter : IValueConverter
  {
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

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    private string ButtonToString(byte button)
    {
      string output = string.Empty;
      Enum.TryParse(typeof(HIDKeyboardScanCode), button.ToString(), out object enumButton);
      HIDKeyboardScanCode convertedEnumButton = (HIDKeyboardScanCode)enumButton;

      var name = Enum.GetName(typeof(HIDKeyboardScanCode), convertedEnumButton);
      output = name;

      return output;
    }

    private string ModifierToString(byte modifier)
    {
      StringBuilder output = new StringBuilder();
      Enum.TryParse(typeof(HIDKeyboardModifierMasks), modifier.ToString(), out object convertedMask);
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
        var name = Enum.GetName(typeof(HIDKeyboardModifierMasks), singleValue);

        if (name != null)
        {
          if (name != "None")
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
