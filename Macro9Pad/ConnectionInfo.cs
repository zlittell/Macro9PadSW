// <copyright file="ConnectionInfo.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Device.Net;
using Macro9Pad.Device.EventModels;
using Macro9Pad.EventModels;

namespace Macro9Pad
{
  public class ConnectionInfo : IHandle<DeviceSelectedEventModel>, IHandle<DeviceListUpdatedEventModel>
  {
    private readonly IEventAggregator eventAggregator;

    private IDevice selectedDevice;

    private List<IDevice> deviceList;

    public ConnectionInfo(IEventAggregator evAgg)
    {
      this.eventAggregator = evAgg;
      this.eventAggregator.SubscribeOnBackgroundThread(this);
    }

    public IDevice SelectedDevice
    {
      get
      {
        return this.selectedDevice;
      }

      set
      {
        this.selectedDevice = value;
        this.LetListenersKnowOfPropertyChanged(nameof(this.SelectedDevice));
      }
    }

    public List<IDevice> DeviceList
    {
      get
      {
        return this.deviceList;
      }

      set
      {
        this.deviceList = value;
        this.LetListenersKnowOfPropertyChanged(nameof(this.DeviceList));
      }
    }

    public void SelectDevice(IDevice newDevice)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SelectDeviceEventModel(newDevice));
    }

    public void RefreshDeviceList()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new RefreshDeviceListEventModel());
    }

    public Task HandleAsync(DeviceSelectedEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.SelectedDevice = message.newDevice;
      }

      return Task.CompletedTask;
    }

    public Task HandleAsync(DeviceListUpdatedEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.DeviceList = message.updatedDeviceList;
      }

      return Task.CompletedTask;
    }

    private void LetListenersKnowOfPropertyChanged(string propertyName)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new ConnectionInfoUpdateEventModel(propertyName));
    }
  }
}
