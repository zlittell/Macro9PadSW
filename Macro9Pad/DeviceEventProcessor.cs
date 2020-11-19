// <copyright file="DeviceEventProcessor.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Messages;
using Macro9Pad.Device.Models;
using Macro9Pad.EventModels;

namespace Macro9Pad
{
  /// <summary>Class for handling events fired into the eventaggregator.</summary>
  public class DeviceEventProcessor : PropertyChangedBase, IHandle<ButtonChangeEvent>,
    IHandle<RGBChangeEvent>, IHandle<SendToDeviceEventModel>, IHandle<LoadFromDeviceEventModel>,
    IHandle<SaveOnDeviceEventModel>
  {
    private readonly IEventAggregator eventAggregator;

    private readonly DeviceModel deviceContents;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceEventProcessor"/> class.
    /// </summary>
    /// <param name="evAgg">Caliburn event aggregator.</param>
    /// <param name="deviceModel">Device Model to apply changes to.</param>
    public DeviceEventProcessor(IEventAggregator evAgg, DeviceModel deviceModel)
    {
      this.eventAggregator = evAgg;
      this.eventAggregator.SubscribeOnBackgroundThread(this);
      this.deviceContents = deviceModel;
    }

    /// <inheritdoc/>
    public Task HandleAsync(ButtonChangeEvent message, CancellationToken cancellationToken)
    {
      switch (message?.ButtonNumber)
      {
        case 1:
        {
          this.deviceContents.Contents.Button1 = message.Button;
          break;
        }

        case 2:
        {
          this.deviceContents.Contents.Button2 = message.Button;
          break;
        }

        case 3:
        {
          this.deviceContents.Contents.Button3 = message.Button;
          break;
        }

        case 4:
        {
          this.deviceContents.Contents.Button4 = message.Button;
          break;
        }

        case 5:
        {
          this.deviceContents.Contents.Button5 = message.Button;
          break;
        }

        case 6:
        {
          this.deviceContents.Contents.Button6 = message.Button;
          break;
        }

        case 7:
        {
          this.deviceContents.Contents.Button7 = message.Button;
          break;
        }

        case 8:
        {
          this.deviceContents.Contents.Button8 = message.Button;
          break;
        }

        case 9:
        {
          this.deviceContents.Contents.Button9 = message.Button;
          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(nameof(message), "Button Number needs to be an actual button.");
        }
      }

      this.NotifyOfPropertyChange(() => this.deviceContents);
      this.deviceContents.SetDirty();
      return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(RGBChangeEvent message, CancellationToken cancellationToken)
    {
      this.deviceContents.Contents.RGB = message?.RGBValues;
      this.NotifyOfPropertyChange(() => this.deviceContents);
      this.deviceContents.SetDirty();
      return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(SendToDeviceEventModel message, CancellationToken cancellationToken)
    {
      if (message != null)
      {
        this.eventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandTransferProfileEventModel(message.Contents), cancellationToken: cancellationToken);
      }

      return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(LoadFromDeviceEventModel message, CancellationToken cancellationToken)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandRequestProfileEventModel(), cancellationToken: cancellationToken);
      return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(SaveOnDeviceEventModel message, CancellationToken cancellationToken)
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SendableCommandSaveProfileEventModel(), cancellationToken: cancellationToken);
      return Task.CompletedTask;
    }
  }
}
