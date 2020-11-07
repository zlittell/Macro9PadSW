// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System.Collections.Immutable;

namespace Macro9Pad.Device.Messages
{
  public class ReceivableCommandBootloaderMessage : MacroPadReceivableUSBMessage, IMacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <inheritdoc/>
    public override byte Command => (byte)MacroPadCommandType.EnterBootloader;

    /// <inheritdoc/>
    public override void ParsePayload(ImmutableArray<byte> payload)
    {
      // no payload on this message.
    }
  }
}
