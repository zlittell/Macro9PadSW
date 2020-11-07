// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

namespace Macro9Pad.Device.Models
{
  /// <summary>Message command type being sent or received.</summary>
  public enum MacroPadCommandType
  {
    None = 0x00,

    /// <summary>Send a profile for device to Receive.</summary>
    ReceiveProfile = 0xA0,

    /// <summary>Request device send profile to PC.</summary>
    SendProfile = 0xB0,

    /// <summary>Request device save profile.</summary>
    SaveProfile = 0xB1,

    /// <summary>Request device enter its bootloader.</summary>
    EnterBootloader = 0xC0,

    /// <summary>Request device send its version to PC.</summary>
    GetDeviceVersion = 0xC1
  }
}
