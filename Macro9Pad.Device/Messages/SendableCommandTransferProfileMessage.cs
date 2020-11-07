using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.Device.Messages
{
  public class SendableCommandTransferProfileMessage : MacroPadSendableUSBMessage, IMacroPadUSBMessage, ISendableUSBMessage
  {
    public SendableCommandTransferProfileMessage(DeviceContentsModel profile)
      : base(
          (byte)MacroPadCommandType.ReceiveProfile,
          ConvertProfileToBytes(profile))
    {
    }

    private static byte[] ConvertProfileToBytes(DeviceContentsModel profile)
    {
      if (profile == null)
      {
        throw new ArgumentNullException(nameof(profile), "Profile to convert cannot be null.");
      }
      else
      {
        return profile.ToBytes();
      }
    }
  }
}
