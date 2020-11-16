// <copyright file="ButtonEditViewModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Macro9Pad.Device.Models;
using Macro9Pad.EventModels;
using Macro9Pad.Helpers;

namespace Macro9Pad.ViewModels
{
  /// <summary>
  /// View model for Button Edit View.
  /// </summary>
  public class ButtonEditViewModel : Screen
  {
    private readonly IEventAggregator eventAggregator;

    private readonly int numberOfButton;

    private readonly ButtonModel originalButton;

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonEditViewModel"/> class.
    /// </summary>
    /// <param name="evAgg">Event aggregator from caliburn.</param>
    /// <param name="number">Number of button to edit.</param>
    /// <param name="button">Button to edit.</param>
    public ButtonEditViewModel(IEventAggregator evAgg, int number, ButtonModel button)
    {
      this.ButtonEdit = button;
      this.originalButton = (ButtonModel)button?.Clone();
      this.numberOfButton = number;
      this.eventAggregator = evAgg;
    }

    /// <summary>Gets list of keycodes to bind to.</summary>
    public IEnumerable<HIDKeyboardScanCode> BindableKeyboardScanCodes
    {
      get
      {
        return Enum.GetValues(typeof(HIDKeyboardScanCode)).Cast<HIDKeyboardScanCode>();
      }
    }

    /// <summary>Gets button to edit.</summary>
    public ButtonModel ButtonEdit { get; }

    /// <summary>Gets or sets the currently selected scan code.</summary>
    public HIDKeyboardScanCode SelectedScancode
    {
      get
      {
        return (HIDKeyboardScanCode)Enum.ToObject(typeof(HIDKeyboardScanCode), this.ButtonEdit.Button);
      }

      set
      {
        this.ButtonEdit.Button = (byte)value;
      }
    }

    /// <summary>Save changes to button.</summary>
    public void SaveButton()
    {
      if (this.CheckForChanges())
      {
        this.eventAggregator.PublishOnBackgroundThreadAsync(new ButtonChangeEvent(this.numberOfButton, this.ButtonEdit));
      }

      this.TryCloseAsync();
    }

    /// <summary>Cancel changes to button.</summary>
    public void CancelButton()
    {
      this.TryCloseAsync();
    }

    /// <summary>
    /// Processes a check box change.
    /// </summary>
    /// <param name="callingElement">Checkbox that has been altered.</param>
    public void ModifierCheckBoxCommand(CheckBox callingElement)
    {
      byte modifier;

      switch (callingElement?.Name)
      {
        case "LeftControl":
        {
          modifier = (byte)HIDKeyboardModifierMasks.LeftControl;
          break;
        }

        case "LeftShift":
        {
          modifier = (byte)HIDKeyboardModifierMasks.LeftShift;
          break;
        }

        case "LeftAlt":
        {
          modifier = (byte)HIDKeyboardModifierMasks.LeftAlt;
          break;
        }

        case "LeftMeta":
        {
          modifier = (byte)HIDKeyboardModifierMasks.LeftMeta;
          break;
        }

        case "RightControl":
        {
          modifier = (byte)HIDKeyboardModifierMasks.RightControl;
          break;
        }

        case "RightShift":
        {
          modifier = (byte)HIDKeyboardModifierMasks.RightShift;
          break;
        }

        case "RightAlt":
        {
          modifier = (byte)HIDKeyboardModifierMasks.RightAlt;
          break;
        }

        case "RightMeta":
        {
          modifier = (byte)HIDKeyboardModifierMasks.RightMeta;
          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(callingElement.Name.ToString(), "There is no switch case for handling this element.");
        }
      }

      // Mask modifier logic
      if ((bool)callingElement.IsChecked)
      {
        this.ButtonEdit.Modifier |= modifier;
      }
      else
      {
        this.ButtonEdit.Modifier &= (byte)~modifier;
      }
    }

    private bool CheckForChanges()
    {
      if ((this.ButtonEdit.Modifier != this.originalButton.Modifier) | 
        (this.ButtonEdit.Button != this.originalButton.Button))
      {
        return true;
      }

      return false;
    }
  }
}
