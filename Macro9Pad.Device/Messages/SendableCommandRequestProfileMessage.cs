// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Message class for sending request to transfer device contents to host command.</summary>
  public class SendableCommandRequestProfileMessage : MacroPadSendableUSBMessage, IMacroPadUSBMessage, ISendableUSBMessage
  {
    public SendableCommandRequestProfileMessage()
      : base (
          (byte)MacroPadCommandType.SendProfile,
          Array.Empty<byte>())
    {
    }
  }
}
