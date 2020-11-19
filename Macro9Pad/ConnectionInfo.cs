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
  /// <summary>Contains and processes connection info from device connector.</summary>
  public class ConnectionInfo : IHandle<DeviceSelectedEventModel>, IHandle<DeviceListUpdatedEventModel>
  {
    private readonly IEventAggregator eventAggregator;

    private IDevice selectedDevice;

    private List<IDevice> deviceList;

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

    /// <summary>Gets list of Devices.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Order, single elements, and removeall")]
    public List<IDevice> DeviceList
    {
      get
      {
        return this.deviceList;
      }
    }

    /// <summary>Requests that device connector selects a specific device.</summary>
    /// <param name="newDevice">Device to select.</param>
    public void SelectDevice(IDevice newDevice)
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
        this.SelectedDevice = message.newDevice;
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
        this.deviceList = message.UpdatedDeviceList;
        this.LetListenersKnowOfPropertyChanged(nameof(this.DeviceList));
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
