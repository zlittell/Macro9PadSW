// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Device.Net;

namespace Macro9Pad.Device.EventModels
{
  public class DeviceSelectedEventModel
  {
    public ConnectedDeviceDefinition NewDevice { get; private set; }

    public DeviceSelectedEventModel(ConnectedDeviceDefinition device)
    {
      this.NewDevice = device;
    }
  }
}
