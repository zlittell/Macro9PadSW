using Device.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.Device.EventModels
{
  public class SelectDeviceEventModel
  {
    public ConnectedDeviceDefinition DeviceToSelect { get; private set; }

    public SelectDeviceEventModel(ConnectedDeviceDefinition device)
    {
      this.DeviceToSelect = device;
    }
  }
}
