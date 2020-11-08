// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Message class for request to enter bootloader command.</summary>
  public class SendableCommandBootloaderMessage : MacroPadSendableUSBMessage, IMacroPadUSBMessage, ISendableUSBMessage
  {
    public SendableCommandBootloaderMessage()
      : base(
          (byte)MacroPadCommandType.EnterBootloader,
          Array.Empty<byte>())
    {
    }
  }
}
