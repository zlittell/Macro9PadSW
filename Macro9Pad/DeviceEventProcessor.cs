// <copyright file="DeviceEventProcessor.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Macro9Pad.EventModels;
using Macro9Pad.Models;

namespace Macro9Pad
{
  /// <summary>Class for handling events fired into the eventaggregator.</summary>
  public class DeviceEventProcessor : PropertyChangedBase, IHandle<ButtonChangeEvent>, IHandle<RGBChangeEvent>
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
          this.deviceContents.Button1 = message.Button;
          break;
        }

        case 2:
        {
          this.deviceContents.Button2 = message.Button;
          break;
        }

        case 3:
        {
          this.deviceContents.Button3 = message.Button;
          break;
        }

        case 4:
        {
          this.deviceContents.Button4 = message.Button;
          break;
        }

        case 5:
        {
          this.deviceContents.Button5 = message.Button;
          break;
        }

        case 6:
        {
          this.deviceContents.Button6 = message.Button;
          break;
        }

        case 7:
        {
          this.deviceContents.Button7 = message.Button;
          break;
        }

        case 8:
        {
          this.deviceContents.Button8 = message.Button;
          break;
        }

        case 9:
        {
          this.deviceContents.Button9 = message.Button;
          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(nameof(message), "Button Number needs to be an actual button.");
        }
      }

      this.NotifyOfPropertyChange(() => this.deviceContents);
      return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(RGBChangeEvent message, CancellationToken cancellationToken)
    {
      this.deviceContents.RGB = message?.RGBValues;
      this.NotifyOfPropertyChange(() => this.deviceContents);
      return Task.CompletedTask;
    }
  }
}
