// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Message class for requesting device serial number command.</summary>
  public class SendableCommandGetSerialNumberMessage : MacroPadSendableUSBMessage, IMacroPadUSBMessage, ISendableUSBMessage
  {
    public SendableCommandGetSerialNumberMessage()
      : base(
          (byte)MacroPadCommandType.GetSerialNumber,
          Array.Empty<byte>())
    {
    }
  }
}
