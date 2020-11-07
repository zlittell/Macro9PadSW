// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System.Collections.Immutable;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Simple USB Message Model for MacroPad.</summary>
  public class MacroPadUSBMessage : IMacroPadUSBMessage
  {
    /// <inheritdoc/>
    public virtual byte Command { get; internal set; }

    /// <inheritdoc/>
    public ImmutableArray<byte> Payload { get; internal set; }
  }
}
