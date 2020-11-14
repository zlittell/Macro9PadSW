using Caliburn.Micro;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Messages;
using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Macro9Pad.Device
{
  public class USBMessageHandler : IHandle<MacroPadReceivableUSBMessage>, IHandle<IMacroPadDeviceSendableCommandEventModel>
  {
    private readonly IEventAggregator eventAggregator;

    private readonly DeviceConnector deviceConnector;

    private DeviceModel deviceModel;

    public USBMessageHandler(IEventAggregator evAgg, DeviceConnector connector, DeviceModel device)
    {
      this.eventAggregator = evAgg;
      this.eventAggregator.SubscribeOnBackgroundThread(this);
      this.deviceConnector = connector;
      this.deviceModel = device;
    }

    public Task HandleAsync(MacroPadReceivableUSBMessage message, CancellationToken cancellationToken)
    {
      if (message == null)
      {
        throw new ArgumentNullException(nameof(message), "Receivable USB Message cannot be null");
      }

      switch (message)
      {
        case ReceivableCommandBootloaderMessage converted:
        {
          throw new NotImplementedException("Bootloader support is not yet implemented.");
        }

        case ReceivableCommandGetDeviceVersionMessage converted:
        {
          this.deviceModel.ProcessDeviceVersion(converted.Version);
          break;
        }

        case ReceivableCommandGetDeviceSerialNumberMessage converted:
        {
          this.deviceModel.ProcessDeviceSerialNumber(converted.DeviceSerialNumber);
          break;
        }

        case ReceivableCommandTransferProfileMessage converted:
        {
          // Device has successfully loaded new profile, might be useful for display on app.
          break;
        }

        case ReceivableCommandSaveProfileMessage converted:
        {
          // Device has successfully saved a profile to NVMemory, might be useful for display on app.
          break;
        }

        case ReceivableCommandRequestProfileMessage converted:
        {
          this.deviceModel.ProcessDeviceContents(converted.DeviceContents);
          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(nameof(message), "has to be known type of usb message");
        }
      }

      return Task.CompletedTask;
    }

    public Task HandleAsync(IMacroPadDeviceSendableCommandEventModel message, CancellationToken cancellationToken)
    {
      if (message == null)
      {
        throw new ArgumentNullException(nameof(message), "Sendable Command Event Model cannot be null");
      }

      ISendableUSBMessage messageToSend = null;

      switch (message)
      {
        case SendableCommandBootloaderEventModel converted:
        {
          messageToSend = new SendableCommandBootloaderMessage();
          break;
        }

        case SendableCommandGetDeviceSerialNumberEventModel converted:
        {
          messageToSend = new SendableCommandGetSerialNumberMessage();
          break;
        }

        case SendableCommandGetDeviceVersionEventModel converted:
        {
          messageToSend = new SendableCommandGetDeviceVersionMessage();
          break;
        }

        case SendableCommandRequestProfileEventModel converted:
        {
          messageToSend = new SendableCommandRequestProfileMessage();
          break;
        }

        case SendableCommandSaveProfileEventModel converted:
        {
          messageToSend = new SendableCommandSaveProfileMessage();
          break;
        }

        case SendableCommandTransferProfileEventModel converted:
        {
          messageToSend = new SendableCommandTransferProfileMessage(converted.DeviceContents);
          break;
        }
      }

      if (messageToSend == null)
      {
        throw new ArgumentOutOfRangeException(nameof(messageToSend), "USB Command must be of known type");
      }
      else
      {
        _ = this.deviceConnector.SendUSBMessage(messageToSend);
      }

      return Task.CompletedTask;
    }
  }
}