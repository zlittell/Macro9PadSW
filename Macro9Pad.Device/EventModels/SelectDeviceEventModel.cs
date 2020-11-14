using Device.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.Device.EventModels
{
  public class SelectDeviceEventModel
  {
    public IDevice deviceToSelect { get; private set; }

    public SelectDeviceEventModel(IDevice device)
    {
      this.deviceToSelect = device;
    }
  }
}
