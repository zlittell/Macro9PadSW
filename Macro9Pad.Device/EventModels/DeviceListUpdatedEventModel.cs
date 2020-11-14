using Device.Net;
using System.Collections.Generic;

namespace Macro9Pad.Device.EventModels
{
  public class DeviceListUpdatedEventModel
  {
    public List<IDevice> updatedDeviceList { get; private set; }

    public DeviceListUpdatedEventModel(List<IDevice> deviceList)
    {
      this.updatedDeviceList = deviceList;
    }
  }
}
