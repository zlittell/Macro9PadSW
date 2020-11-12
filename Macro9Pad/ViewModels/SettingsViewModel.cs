// <copyright file="SettingsViewModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;
using Macro9Pad.Device.Models;

namespace Macro9Pad.ViewModels
{
  /// <summary>View Model for Settings View.</summary>
  public class SettingsViewModel : Screen
  {
    private readonly IEventAggregator eventAggregator;

    private DeviceModel deviceModel;

    public SettingsViewModel(IEventAggregator evAgg, DeviceModel devModel)
    {
      this.eventAggregator = evAgg;
      this.deviceModel = devModel;
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

    public 
  }
}
