// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Message class for a profile save to NVMemory command.</summary>
  public class SendableCommandSaveProfileMessage : MacroPadSendableUSBMessage, IMacroPadUSBMessage, ISendableUSBMessage
  {
    public SendableCommandSaveProfileMessage()
      : base(
      (byte)MacroPadCommandType.SaveProfile,
      Array.Empty<byte>())
    {
    }
  }
}
