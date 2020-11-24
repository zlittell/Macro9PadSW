// <copyright file="ConnectionInfo.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Device.Net;
using Macro9Pad.Device.EventModels;
using Macro9Pad.EventModels;

namespace Macro9Pad
{
  /// <summary>Contains and processes connection info from device connector.</summary>
  public class ConnectionInfo : IHandle<DeviceSelectedEventModel>, IHandle<DeviceListUpdatedEventModel>
  {
    private readonly IEventAggregator eventAggregator;

    private ConnectedDeviceDefinition selectedUSBDevice;

    private Collection<ConnectedDeviceDefinition> usbDevices;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfo"/> class.
    /// </summary>
    /// <param name="evAgg">Caliburn micro event aggregator.</param>
    public ConnectionInfo(IEventAggregator evAgg)
    {
      this.eventAggregator = evAgg;
      this.eventAggregator.SubscribeOnBackgroundThread(this);
    }

    /// <summary>Gets or Sets Selected Device for Display.</summary>
    public ConnectedDeviceDefinition SelectedUSBDevice
    {
      get
      {
        return this.selectedUSBDevice;
      }

      set
      {
        this.selectedUSBDevice = value;
        this.LetListenersKnowOfPropertyChanged(nameof(this.SelectedUSBDevice));
      }
    }

    /// <summary>Gets list of Devices.</summary>
    public Collection<ConnectedDeviceDefinition> USBDevices
    {
      get
      {
        return this.usbDevices;
      }
    }

    /// <summary>Requests that device connector selects a specific device.</summary>
    /// <param name="newDevice">Device to select.</param>
    public void SelectDevice(ConnectedDeviceDefinition newDevice)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SelectDeviceEventModel(newDevice));
    }

    /// <summary>Requests device connector refresh device list.</summary>
    public void RefreshDeviceList()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new RefreshDeviceListEventModel());
    }

    /// <summary>
    /// Handles DeviceSelectedEventModel messages from event aggregator.
    /// </summary>
    /// <param name="message">Eventmodel to process.</param>
    /// <param name="cancellationToken">Cancellation token for task.</param>
    /// <returns>task state.</returns>
    public Task HandleAsync(DeviceSelectedEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.SelectedUSBDevice = message.NewDevice;
      }

      return Task.CompletedTask;
    }

    /// <summary>
    /// Handles DeviceListUpdatedEventModel messages from event aggregator.
    /// </summary>
    /// <param name="message">Eventmodel to process.</param>
    /// <param name="cancellationToken">Cancellation token for task.</param>
    /// <returns>task state.</returns>
    public Task HandleAsync(DeviceListUpdatedEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.usbDevices = message.UpdatedDeviceList;
        this.LetListenersKnowOfPropertyChanged(nameof(this.USBDevices));
      }

      return Task.CompletedTask;
    }

    /// <summary>
    /// Publishes a ConnectionInfoUpdatedEventModel.
    /// </summary>
    /// <param name="propertyName">Property that was updated.</param>
    private void LetListenersKnowOfPropertyChanged(string propertyName)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new ConnectionInfoUpdateEventModel(propertyName));
    }
  }
}
