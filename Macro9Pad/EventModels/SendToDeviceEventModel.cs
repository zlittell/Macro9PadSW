// <copyright file="SendToDeviceEventModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Device.Models;

namespace Macro9Pad.EventModels
{
  /// <summary>Send contents to device event model.</summary>
  public class SendToDeviceEventModel
  {
    private readonly DeviceContentsModel deviceContents;

    /// <summary>
    /// Initializes a new instance of the <see cref="SendToDeviceEventModel"/> class.
    /// </summary>
    /// <param name="deviceContents">Device Contents to Send.</param>
    public SendToDeviceEventModel(DeviceContentsModel deviceContents)
    {
      this.deviceContents = deviceContents;
    }

    /// <summary>Gets contents to send to device.</summary>
    public DeviceContentsModel Contents
    {
      get
      {
        return this.deviceContents;
      }
    }
  }
}
