// <copyright file="MainViewModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using Caliburn.Micro;
using Macro9Pad.Device.EventModels;
using Macro9Pad.Device.Messages;
using Macro9Pad.Device.Models;
using Macro9Pad.EventModels;
using Macro9Pad.Helpers;

namespace Macro9Pad.ViewModels
{
  /// <summary>View Model for Main View.</summary>
  public class MainViewModel : Screen
  {
    private readonly IWindowManager windowManager;

    private readonly DeviceModel deviceContents;

    private readonly IEventAggregator eventAggregator;

    private readonly ConnectionInfo connectionInfo;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="windowManager">Window manager from caliburn.</param>
    /// <param name="evAgg">Event aggregator from caliburn.</param>
    /// <param name="deviceModel">Device to work with.</param>
    /// <param name="connInfo">Connection Info Object from caliburn.</param>
    public MainViewModel(
      IWindowManager windowManager,
      IEventAggregator evAgg,
      DeviceModel deviceModel,
      ConnectionInfo connInfo)
    {
      this.windowManager = windowManager;
      this.eventAggregator = evAgg;
      this.deviceContents = deviceModel;
      this.connectionInfo = connInfo;
    }

    /// <summary>Gets the model of the Device being edited.</summary>
    public DeviceModel Device
    {
      get
      {
        return this.deviceContents;
      }
    }

    /// <summary>Launch settings edit window.</summary>
    public void EditSettings()
    {
      this.windowManager.ShowDialogAsync(new SettingsViewModel(this.deviceContents, this.connectionInfo));
    }

    /// <summary>Launch RGB edit window.</summary>
    public void RGBEdit()
    {
      this.windowManager.ShowDialogAsync(
          new RGBColorViewModel(this.eventAggregator, (RGBModel)this.deviceContents.Contents.RGB.Clone()));
    }

    /// <summary>
    /// Launches the button edit window.
    /// </summary>
    /// <param name="buttonNumber">Number of button to edit.</param>
    public void ButtonEdit(int buttonNumber)
    {
      ButtonModel button;
      switch (buttonNumber)
      {
        case 1:
        {
          button = this.deviceContents.Contents.Button1;
          break;
        }

        case 2:
        {
          button = this.deviceContents.Contents.Button2;
          break;
        }

        case 3:
        {
          button = this.deviceContents.Contents.Button3;
          break;
        }

        case 4:
        {
          button = this.deviceContents.Contents.Button4;
          break;
        }

        case 5:
        {
          button = this.deviceContents.Contents.Button5;
          break;
        }

        case 6:
        {
          button = this.deviceContents.Contents.Button6;
          break;
        }

        case 7:
        {
          button = this.deviceContents.Contents.Button7;
          break;
        }

        case 8:
        {
          button = this.deviceContents.Contents.Button8;
          break;
        }

        case 9:
        {
          button = this.deviceContents.Contents.Button9;
          break;
        }

        default:
        {
          throw new ArgumentOutOfRangeException(nameof(buttonNumber), "Button number must exist.");
        }
      }

      this.windowManager.ShowDialogAsync(new ButtonEditViewModel(this.eventAggregator, buttonNumber, (ButtonModel)button.Clone()));
    }

    /// <summary>Loads a profile from device.</summary>
    public void LoadProfile()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new LoadFromDeviceEventModel());
    }

    /// <summary>Sends a profile to device.</summary>
    public void SaveProfile()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SendToDeviceEventModel(this.deviceContents.Contents));
    }

    /// <summary>Tell device to store a profile in NVMemory.</summary>
    public void StoreProfile()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new SaveOnDeviceEventModel());
    }

    /// <summary>Load a profile from file.</summary>
    public void LoadProfileFromFile()
    {
      ProfileReadWriteHelper readerHelper = new ProfileReadWriteHelper();
      var readDeviceContents = readerHelper.ReadFile();
      if (readDeviceContents != null)
      {
        this.Device.Contents = readDeviceContents;
        this.Device.SetDirty();
      }
    }

    /// <summary>Save a profile to file.</summary>
    public void SaveProfileToFile()
    {
      ProfileReadWriteHelper writerHelper = new ProfileReadWriteHelper();
      writerHelper.WriteFile(this.Device.Contents);
    }
  }
}