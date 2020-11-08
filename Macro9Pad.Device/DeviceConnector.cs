﻿using Caliburn.Micro;
using Device.Net;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Messages;
using Macro9Pad.Device.Models;
using MSF.USBConnector;
using MSF.USBMessages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Macro9Pad.Device
{
  public class DeviceConnector : USBDeviceConnector, IUSBDeviceConnector
  {
    private const uint usbVID = 0x0000;

    private const uint usbPID = 0x0000;

    private const string usbInterface = "MI_00";

    private readonly IEventAggregator eventAggregator;

    private DeviceModel macroDevice;

    private CancellationToken continousReadCancellationToken;

    public DeviceConnector(IEventAggregator evAgg)
      : base(evAgg)
    {
      this.eventAggregator = evAgg;
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
        while (retries < maxRetries)
        {
          switch (step)
          {
            case 0:
            {
              // Get Device Version
              timeoutWatcher.Restart();
              this.RequestDeviceVersion();
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
              this.RequestDeviceSerialNumber();
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
              this.RequestDeviceContents();
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
    public override void ParsePayload(ReadResult receivedData)
    {
      IReceivableUSBMessage message = null;

      switch (receivedData.Data[0])
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

    /// <summary>Adds this device to List of DeviceFilters.</summary>
    public void AddDeviceToFilter()
    {
      this.AddHidDeviceToFilterList(usbVID, usbPID);
    }

    /// <summary>Refresh device list and filter it for only this devices correct interface.</summary>
    public void RefreshFilteredDeviceList()
    {
      Task.Run(async () => { await this.UpdateUSBHIDDeviceList().ConfigureAwait(true); }).Wait();
      this.USBDeviceList.RemoveAll(this.DoesNotContainCorrectInterface);
      this.eventAggregator.PublishOnBackgroundThreadAsync(new DeviceConnectorChangeEvent());
    }

    /// <summary>Sends the get device version command.</summary>
    public void RequestDeviceVersion()
    {
      _ = this.SendUSBMessage(new SendableCommandGetDeviceVersionMessage());
    }

    /// <summary>Sends the enter bootloader command.</summary>
    public void EnterBootloader()
    {
      _ = this.SendUSBMessage(new SendableCommandBootloaderMessage());
    }

    public void RequestDeviceContents()
    {
      _ = this.SendUSBMessage(new SendableCommandRequestProfileMessage());
    }

    public void RequestDeviceSerialNumber()
    {
      _ = this.SendUSBMessage(new SendableCommandGetSerialNumberMessage());
    }

    public void SendProfile(DeviceContentsModel contents)
    {
      _ = this.SendUSBMessage(new SendableCommandTransferProfileMessage(contents));
    }

    private bool DoesNotContainCorrectInterface(IDevice obj)
    {
      return !obj.DeviceId.ContainsIgnoreCase(usbInterface);
    }
  }
}
