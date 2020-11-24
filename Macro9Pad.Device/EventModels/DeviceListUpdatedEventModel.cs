using Device.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Macro9Pad.Device.EventModels
{
  public class DeviceListUpdatedEventModel
  {
    /// <summary>Updated list of devices.</summary>
    public Collection<ConnectedDeviceDefinition> UpdatedDeviceList { get; private set; }

    /// <summary>
    /// Event model for Device List Updated.
    /// </summary>
    /// <param name="deviceList">Updated list of devices.</param>
    public DeviceListUpdatedEventModel(Collection<ConnectedDeviceDefinition> deviceList)
    {
      this.UpdatedDeviceList = deviceList;
    }
  }
}
