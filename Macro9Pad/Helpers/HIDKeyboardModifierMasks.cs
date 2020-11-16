// <copyright file="HIDKeyboardModifierMasks.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.ComponentModel;

namespace Macro9Pad.Helpers
{
  /// <summary>
  /// Masks for modifier byte on USB HID Keyboard.
  /// </summary>
  [Flags]
  public enum HIDKeyboardModifierMasks
  {
    /// <summary>No Modifier OR Mask.</summary>
    [Description("None")]
    None = 0x00,

    /// <summary>Left Control OR Mask.</summary>
    [Description("Left Control")]
    LeftControl = 0x01,

    /// <summary>Left Shift OR Mask.</summary>
    [Description("Left Shift")]
    LeftShift = 0x02,

    /// <summary>Left Alt OR Mask.</summary>
    [Description("Left Alt")]
    LeftAlt = 0x04,

    /// <summary>Left Meta OR Mask.</summary>
    [Description("Left Meta")]
    LeftMeta = 0x08,

    /// <summary>Right Control OR Mask.</summary>
    [Description("Right Control")]
    RightControl = 0x10,

    /// <summary>Right Shift OR Mask.</summary>
    [Description("Right Shift")]
    RightShift = 0x20,

    /// <summary>Right Alt OR Mask.</summary>
    [Description("Right Alt")]
    RightAlt = 0x40,

    /// <summary>Right Meta OR Mask.</summary>
    [Description("Right Meta")]
    RightMeta = 0x80,
  }
}
