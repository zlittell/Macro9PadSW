// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;
using Device.Net;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Messages;
using Macro9Pad.Device.Models;
using MSF.USBConnector;
using MSF.USBMessages;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Macro9Pad.Device
{
  public class DeviceConnector : USBDeviceConnector,
    IHandle<SelectDeviceEventModel>, IHandle<RefreshDeviceListEventModel>
  {
    protected override string UsbInterface { get => "MI_00"; }

    protected override Collection<FilterDeviceDefinition> DeviceFilters
    {
      get => new Collection<FilterDeviceDefinition>(){new FilterDeviceDefinition { DeviceType = DeviceType.Hid, VendorId = 0x1209, ProductId = 0x9001 }};
    }

    private readonly DeviceModel macroDevice;

    public DeviceConnector(IEventAggregator evAgg, DeviceModel devModel)
      : base(evAgg)
    {
      this.macroDevice = devModel;
      this.RunAfterInitialized();
    }

    /// <inheritdoc/>
    public override IDevice SelectedUSBDevice
    {
      get
      {
        return this.macroDevice.Device;
      }

      set
      {
        this.macroDevice.SetDevice(value);
        this.EventAggregator.PublishOnBackgroundThreadAsync(new DeviceSelectedEventModel(this.macroDevice.Device));
        _ = this.OpenUSBDevice();
        Task.Run(() => this.DeviceModelWatcherStateMachine());
      }
    }

    /// <summary>State Machine for initializing a newly connected device.</summary>
    public void DeviceModelWatcherStateMachine()
    {
      const uint maxRetries = 10;
      const uint timeoutMilliseconds = 2000;
      uint step = 0;
      uint retries = 0;
      Stopwatch timeoutWatcher = new Stopwatch();

      /*
       * Things to do:
       * Device Version
       * Serial Number
       * Get Device Contents
       */

      if (this.macroDevice.Device != null)
      {
        while (retries < maxRetries & step < 3)
        {
          switch (step)
          {
            case 0:
            {
              // Get Device Version
              timeoutWatcher.Restart();
              this.EventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandGetDeviceVersionEventModel());
              while (!this.macroDevice.DeviceInitializedVersion & timeoutWatcher.ElapsedMilliseconds < timeoutMilliseconds)
              {
                continue;
              }

              if (this.macroDevice.DeviceInitializedVersion)
              {
                step++;
                retries = 0;
                break;
              }

              retries++;
              break;
            }

            case 1:
            {
              // Get Serial Number
              timeoutWatcher.Restart();
              this.EventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandGetDeviceSerialNumberEventModel());
              while (!this.macroDevice.DeviceInitializedSerialNumber & timeoutWatcher.ElapsedMilliseconds < timeoutMilliseconds)
              {
                continue;
              }

              if (this.macroDevice.DeviceInitializedSerialNumber)
              {
                step++;
                retries = 0;
                break;
              }

              retries++;
              break;
            }

            case 2:
            {
              // Get Device Contents
              timeoutWatcher.Restart();
              this.EventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandRequestProfileEventModel());
              while (!this.macroDevice.DeviceInitializedDeviceContents & timeoutWatcher.ElapsedMilliseconds < timeoutMilliseconds)
              {
                continue;
              }

              if (this.macroDevice.DeviceInitializedDeviceContents)
              {
                step++;
                retries = 0;
                break;
              }

              retries++;
              break;
            }
          }
        }
        if (retries >= maxRetries)
        {
          throw new TimeoutException("Initializing device failed due to timeout.");
        }
      }
    }

    /// <inheritdoc/>
    protected override void ParsePayload(ReadResult receivedData)
    {
      IReceivableUSBMessage message = null;

      switch (receivedData.Data[1])
      {
        case (byte)MacroPadCommandType.EnterBootloader:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandBootloaderMessage>(receivedData.Data);
          break;
        }

        case (byte)MacroPadCommandType.GetDeviceVersion:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandGetDeviceVersionMessage>(receivedData.Data);
          break;
        }

        case (byte)MacroPadCommandType.GetSerialNumber:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandGetDeviceSerialNumberMessage>(receivedData.Data);
          break;
        }

        case (byte)MacroPadCommandType.ReceiveProfile:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandTransferProfileMessage>(receivedData.Data);
          break;
        }

        case (byte)MacroPadCommandType.SaveProfile:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandSaveProfileMessage>(receivedData.Data);
          break;
        }

        case (byte)MacroPadCommandType.SendProfile:
        {
          message = MacroPadReceivableUSBMessage.FromBytes<ReceivableCommandRequestProfileMessage>(receivedData.Data);
          break;
        }
      }

      if (message != null)
      {
        this.ReceivedUSBMessageHandler(message);
      }
    }

    public override void RefreshFilteredDeviceList()
    {
      base.RefreshFilteredDeviceList();
      this.EventAggregator.PublishOnBackgroundThreadAsync(new DeviceListUpdatedEventModel(this.USBDeviceList));
    }

    public Task HandleAsync(SelectDeviceEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.SelectDevice(message.deviceToSelect);
      }

      return Task.CompletedTask;
    }

    public Task HandleAsync(RefreshDeviceListEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.RefreshFilteredDeviceList();
      }

      return Task.CompletedTask;
    }
  }
}
