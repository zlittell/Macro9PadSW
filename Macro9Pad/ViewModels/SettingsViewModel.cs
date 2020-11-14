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
    private ConnectionInfo connectionInfo;

    private DeviceModel deviceModel;

    public SettingsViewModel(DeviceModel devModel, ConnectionInfo connInfo)
    {
      this.deviceModel = devModel;
      this.connectionInfo = connInfo;
    }

    public string DeviceVersion
    {
      get
      {
        return this.deviceModel.Version.ReturnVersionString();
      }
    }

    public string DeviceSerial
    {
      get
      {
        return this.deviceModel.DeviceSerialNumber;
      }
    }

    public List<IDevice> DeviceList
    {
      get
      {
        return this.connectionInfo.DeviceList;
      }
    }

    public IDevice SelectedDevice
    {
      get
      {
        return this.connectionInfo.SelectedDevice;
      }

      set
      {
      }
    }

    public void CloseSettings()
    {
      this.TryCloseAsync();
    }

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

    public void RefreshDeviceList()
    {
      this.connectionInfo.RefreshDeviceList();
    }
  }
}
