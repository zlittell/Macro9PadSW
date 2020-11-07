// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System.Collections.Immutable;
using System.Linq;

namespace Macro9Pad.Device.Messages
{
  public class ReceivableCommandGetDeviceVersionMessage : MacroPadReceivableUSBMessage, IMacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <inheritdoc/>
    public override byte Command => (byte)MacroPadCommandType.GetDeviceVersion;

    /// <summary>Gets the device version.</summary>
    public DeviceVersionModel Version { get; private set; }

    /// <inheritdoc/>
    public override void ParsePayload(ImmutableArray<byte> payload)
    {
      // Version is Major, Minor, Revision
      this.Version = new DeviceVersionModel(payload.Take(1).ToArray());
    }
  }
}
