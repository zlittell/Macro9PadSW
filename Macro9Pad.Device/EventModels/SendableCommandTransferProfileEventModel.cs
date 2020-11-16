// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;

namespace Macro9Pad.Device.EventModels
{
  public class SendableCommandTransferProfileEventModel : IMacroPadDeviceSendableCommandEventModel
  {
    /// <summary>Gets the contents of the device received from device.</summary>
    public DeviceContentsModel DeviceContents { get; private set; }

    public SendableCommandTransferProfileEventModel(DeviceContentsModel contents)
    {
      this.DeviceContents = contents;
    }
  }
}
