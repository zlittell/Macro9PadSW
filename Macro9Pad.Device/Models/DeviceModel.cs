// <copyright file="DeviceModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;
using System;
using Device.Net;
using Macro9Pad.Device.EventModels;

namespace Macro9Pad.Device.Models
{
  /// <summary>Model of a device and its contents.</summary>
  public class DeviceModel : PropertyChangedBase
  {
    private readonly IEventAggregator eventAggregator;

    private InitializedStatuses deviceInitialization;

    private RGBModel rgb;

    private DeviceContentsModel contents;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceModel"/> class.
    /// </summary>
    /// <param name="eventAggregator">Caliburn Micro event aggregator.</param>
    public DeviceModel(IEventAggregator eventAggregator)
    {
      this.eventAggregator = eventAggregator;
      this.ClearDeviceModel();
    }

    /// <summary>Enum for tracking how initialized a new device is.</summary>
    [Flags]
    public enum InitializedStatuses
    {
      /// <summary>Nothing has been initialized.</summary>
      None,

      /// <summary>Serial Number has been read.</summary>
      SerialNumber,

      /// <summary>Device Version has been read.</summary>
      Version,

      /// <summary>Device Contents have been read.</summary>
      DeviceContents,
    }

    /// <summary>Gets a value indicating whether Serial Number has been initially read.</summary>
    public bool DeviceInitializedSerialNumber => this.deviceInitialization.HasFlag(InitializedStatuses.SerialNumber);

    /// <summary>Gets a value indicating whether Version has been initially read.</summary>
    public bool DeviceInitializedVersion => this.deviceInitialization.HasFlag(InitializedStatuses.Version);

    /// <summary>Gets a value indicating whether Device has been read.</summary>
    public bool DeviceInitializedDeviceContents => this.deviceInitialization.HasFlag(InitializedStatuses.DeviceContents);

    /// <summary>Gets device version.</summary>
    public DeviceVersionModel Version { get; private set; }

    /// <summary>Gets device serial number.</summary>
    public string DeviceSerialNumber { get; private set; }

    /// <summary>Gets USB IDevice.</summary>
    public IDevice Device { get; private set; }

    /// <summary>Gets or sets RGBModel of device.</summary>
    public RGBModel RGB
    {
      get
      {
        return this.rgb;
      }

      set
      {
        this.rgb = value;
        this.NotifyOfPropertyChange(() => this.RGB);
      }
    }

    /// <summary>Gets or sets Contents of device.</summary>
    public DeviceContentsModel Contents
    {
      get
      {
        return this.contents;
      }

      set
      {
        this.contents = value;
        this.NotifyOfPropertyChange(() => this.Contents);
      }
    }

    /// <summary>Gets a value indicating whether or not the device is dirty and needs updated.</summary>
    public bool IsDirty { get; private set; }

    /// <summary>Sets the device as dirty and needing updated.</summary>
    public void SetDirty()
    {
      this.IsDirty = true;
    }

    /// <summary>Clears the device as dirty and needing updated.</summary>
    public void ClearDirty()
    {
      this.IsDirty = false;
    }

    /// <summary>
    /// Assign Device Version to local device version.
    /// </summary>
    /// <param name="receivedVersion">Version received for assignment.</param>
    public void ProcessDeviceVersion(DeviceVersionModel receivedVersion)
    {
      this.Version = receivedVersion ?? throw new ArgumentNullException(nameof(receivedVersion));
      this.deviceInitialization |= InitializedStatuses.Version;
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceModelChangeEvent());
    }

    /// <summary>Clears model and sets device.</summary>
    /// <param name="device">Device to assign to model.</param>
    public void SetDevice(IDevice device)
    {
      this.ClearDeviceModel();
      this.Device = device;
    }

    /// <summary>Clears the device model of previous devices information.</summary>
    private void ClearDeviceModel()
    {
      this.Device = null;
      this.DeviceSerialNumber = string.Empty;
      this.Version = new DeviceVersionModel();
      this.Contents = new DeviceContentsModel();
      this.deviceInitialization = 0;
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceModelChangeEvent());
    }
  }
}
