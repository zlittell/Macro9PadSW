using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Message class for a profile save to NVMemory success response.</summary>
  public class ReceivableCommandSaveProfileMessage : MacroPadReceivableUSBMessage, IMacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <inheritdoc/>
    public override byte Command => (byte)MacroPadCommandType.SaveProfile;

    /// <inheritdoc/>
    public override void ParsePayload(ImmutableArray<byte> payload)
    {
      // No payload on message.
    }
  }
}
