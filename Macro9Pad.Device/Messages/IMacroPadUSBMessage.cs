// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using MSF.USBMessages;

namespace Macro9Pad.Device.Messages
{
  public interface IMacroPadUSBMessage : ISimpleUSBMessage
  {
    /// <summary>Gets command.</summary>
    byte Command { get; }
  }
}
