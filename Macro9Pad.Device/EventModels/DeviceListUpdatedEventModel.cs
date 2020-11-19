using Device.Net;
using System.Collections.Generic;

namespace Macro9Pad.Device.EventModels
{
  public class DeviceListUpdatedEventModel
  {
    /// <summary>Updated list of devices.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Order, single elements, and removeall")]
    public List<IDevice> UpdatedDeviceList { get; private set; }

    /// <summary>
    /// Event model for Device List Updated.
    /// </summary>
    /// <param name="deviceList">Updated list of devices.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Order, single elements, and removeall")]
    public DeviceListUpdatedEventModel(List<IDevice> deviceList)
    {
      this.UpdatedDeviceList = deviceList;
    }
  }
}
