// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using MSF.USBMessages;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Sendable USB message for MacroPad devices.</summary>
  public abstract class MacroPadSendableUSBMessage : MacroPadUSBMessage, ISendableUSBMessage
  {
    protected MacroPadSendableUSBMessage(byte command, byte[] payload)
    {
      if (payload == null)
      {
        throw new ArgumentNullException(nameof(payload));
      }

      if (command == 0x00)
      {
        throw new ArgumentException("You must enter a valid command that isn't 0x00", nameof(command));
      }

      this.ReportID = 0x00;   // Device uses no reportID but library needs one.
      this.Command = command;
      this.Payload = payload.Length == 0 ?
        ImmutableArray.ToImmutableArray(Array.Empty<byte>()) : ImmutableArray.ToImmutableArray(payload);
    }

    public byte[] ToBytes()
    {
      int headerLength = 2; // ReportID + Command
      byte[] datagram = new byte[headerLength + this.Payload.Length];

      datagram[0] = this.ReportID;
      datagram[1] = this.Command;
      Buffer.BlockCopy(this.Payload.ToArray(), 0, datagram, headerLength, this.Payload.Length);
      return datagram;
    }
  }
}
