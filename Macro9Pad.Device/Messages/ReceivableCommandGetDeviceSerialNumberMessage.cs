// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Macro9Pad.Device.Messages
{
  public class ReceivableCommandGetDeviceSerialNumberMessage : MacroPadReceivableUSBMessage, IMacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <inheritdoc/>
    public override byte Command => (byte)MacroPadCommandType.GetSerialNumber;

    /// <summary>Gets the device serial number.</summary>
    public string DeviceSerialNumber { get; private set; }

    /// <inheritdoc/>
    public override void ParsePayload(ImmutableArray<byte> payload)
    {
      this.DeviceSerialNumber = Encoding.ASCII.GetString(payload.ToArray());
    }
  }
}
