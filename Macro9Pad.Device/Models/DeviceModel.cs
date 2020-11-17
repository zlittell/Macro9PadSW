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

    public InitializedStatuses DeviceInitialization
    {
      get
      {
        return this.deviceInitialization;
      }

      private set
      {
        this.deviceInitialization = value;
        this.NotifyOfPropertyChange(() => this.DeviceInitialization);
        this.NotifyOfPropertyChange(() => this.DeviceCompletelyInitialized);
      }
    }

    /// <summary>Gets a value indicating whether Serial Number has been initially read.</summary>
    public bool DeviceInitializedSerialNumber => this.DeviceInitialization.HasFlag(InitializedStatuses.SerialNumber);

    /// <summary>Gets a value indicating whether Version has been initially read.</summary>
    public bool DeviceInitializedVersion => this.DeviceInitialization.HasFlag(InitializedStatuses.Version);

    /// <summary>Gets a value indicating whether Device has been read.</summary>
    public bool DeviceInitializedDeviceContents => this.DeviceInitialization.HasFlag(InitializedStatuses.DeviceContents);

    public bool DeviceCompletelyInitialized
    {
      get
      {
        if (DeviceInitializedSerialNumber &
          DeviceInitializedVersion &
          DeviceInitializedDeviceContents)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    /// <summary>Gets device version.</summary>
    public DeviceVersionModel Version { get; private set; }

    /// <summary>Gets device serial number.</summary>
    public string DeviceSerialNumber { get; private set; }

    /// <summary>Gets USB IDevice.</summary>
    public IDevice Device { get; private set; }

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
      this.NotifyOfPropertyChange(() => this.IsDirty);
    }

    /// <summary>Clears the device as dirty and needing updated.</summary>
    public void ClearDirty()
    {
      this.IsDirty = false;
      this.NotifyOfPropertyChange(() => this.IsDirty);
    }

    /// <summary>
    /// Assign Device Version to local device version.
    /// </summary>
    /// <param name="receivedVersion">Version received for assignment.</param>
    public void ProcessDeviceVersion(DeviceVersionModel receivedVersion)
    {
      this.Version = receivedVersion ?? throw new ArgumentNullException(nameof(receivedVersion));
      this.DeviceInitialization |= InitializedStatuses.Version;
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceModelChangeEvent());
    }

    /// <summary>
    /// Assign Serial Number to device model.
    /// </summary>
    /// <param name="receivedSerial">New serial number.</param>
    public void ProcessDeviceSerialNumber(string receivedSerial)
    {
      this.DeviceSerialNumber = receivedSerial ?? throw new ArgumentNullException(nameof(receivedSerial), "Received null serial number");
      this.DeviceInitialization |= InitializedStatuses.SerialNumber;
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceModelChangeEvent());
    }

    /// <summary>
    /// Assign Device Contents to device model.
    /// Used to assign entirely read in contents from USB Device.
    /// </summary>
    /// <param name="receivedContents">Contents to set.</param>
    public void ProcessDeviceContents(DeviceContentsModel receivedContents)
    {
      this.Contents = receivedContents;
      this.DeviceInitialization |= InitializedStatuses.DeviceContents;
      this.ClearDirty();
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
      this.DeviceInitialization = 0;
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceModelChangeEvent());
    }
  }
}
