// <copyright file="SettingsViewModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Device.Net;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Models;
using Macro9Pad.EventModels;

namespace Macro9Pad.ViewModels
{
  /// <summary>View Model for Settings View.</summary>
  public class SettingsViewModel : Screen, IHandle<ConnectionInfoUpdateEventModel>
  {
    private readonly ConnectionInfo connectionInfo;

    private readonly DeviceModel deviceModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
    /// </summary>
    /// <param name="devModel">Device model.</param>
    /// <param name="connInfo">Connection Info for display.</param>
    public SettingsViewModel(DeviceModel devModel, ConnectionInfo connInfo)
    {
      this.deviceModel = devModel;
      this.connectionInfo = connInfo;
    }

    /// <summary>Gets DeviceVersion for display.</summary>
    public string DeviceVersion
    {
      get
      {
        return this.deviceModel.Version.ReturnVersionString();
      }
    }

    /// <summary>Gets Serial of device to display.</summary>
    public string DeviceSerial
    {
      get
      {
        return this.deviceModel.DeviceSerialNumber;
      }
    }

    /// <summary>Gets list of devices for display.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "Order, single elements, and removeall")]
    public List<IDevice> DeviceList
    {
      get
      {
        return this.connectionInfo.DeviceList;
      }
    }

    /// <summary>Gets or sets SelectedDevice for display.</summary>
    public IDevice SelectedDevice
    {
      get
      {
        return this.connectionInfo.SelectedDevice;
      }

      set
      {
        this.connectionInfo.SelectDevice(value);
      }
    }

    /// <summary>Close button pressed.</summary>
    public void CloseSettings()
    {
      this.TryCloseAsync();
    }

    /// <summary>Refresh device list button pressed.</summary>
    public void RefreshDeviceList()
    {
      this.connectionInfo.RefreshDeviceList();
    }

    /// <summary>
    /// Handles a ConnectionInfoUpdateEventModel message from event aggregator.
    /// </summary>
    /// <param name="message">Message to process.</param>
    /// <param name="cancellationToken">Task cancellation token.</param>
    /// <returns>Task state.</returns>
    public Task HandleAsync(ConnectionInfoUpdateEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        switch (message.PropertyName)
        {
          case nameof(this.DeviceList):
          {
            this.NotifyOfPropertyChange(() => this.DeviceList);
            break;
          }

          case nameof(this.SelectedDevice):
          {
            this.NotifyOfPropertyChange(() => this.SelectedDevice);
            break;
          }
        }
      }

      return Task.CompletedTask;
    }
  }
}
