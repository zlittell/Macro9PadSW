// <copyright file="RGBColorViewModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;
using Macro9Pad.EventModels;
using Macro9Pad.Models;

namespace Macro9Pad.ViewModels
{
  /// <summary>View Model for RGB Color View.</summary>
  public class RGBColorViewModel : Screen
  {
    private RGBModel rgbEdit;

    private IEventAggregator eventAggregator;

    /// <summary>
    /// Initializes a new instance of the <see cref="RGBColorViewModel"/> class.
    /// </summary>
    /// <param name="evAgg">Event aggregator from caliburn.</param>
    /// <param name="rgb">RGB Model to edit.</param>
    public RGBColorViewModel(IEventAggregator evAgg, RGBModel rgb)
    {
      this.rgbEdit = rgb;
      this.eventAggregator = evAgg;
    }

    /// <summary>Gets or sets red byte of the RGB Model.</summary>
    public byte RGB_Red
    {
      get => this.rgbEdit.Red;

      set
      {
        this.rgbEdit.Red = value;
        this.NotifyOfPropertyChange(() => this.RGB_Red);
        this.NotifyOfPropertyChange(() => this.RGBEdit);
      }
    }

    /// <summary>Gets or sets green byte of the RGB Model.</summary>
    public byte RGB_Green
    {
      get => this.rgbEdit.Green;

      set
      {
        this.rgbEdit.Green = value;
        this.NotifyOfPropertyChange(() => this.RGB_Green);
        this.NotifyOfPropertyChange(() => this.RGBEdit);
      }
    }

    /// <summary>Gets or sets blue byte of the RGB Model.</summary>
    public byte RGB_Blue
    {
      get => this.rgbEdit.Blue;

      set
      {
        this.rgbEdit.Blue = value;
        this.NotifyOfPropertyChange(() => this.RGB_Blue);
        this.NotifyOfPropertyChange(() => this.RGBEdit);
      }
    }

    /// <summary>Gets or sets brightness byte of the RGB Model.</summary>
    public byte RGB_Brightness
    {
      get => this.rgbEdit.Brightness;

      set
      {
        this.rgbEdit.Brightness = value;
        this.NotifyOfPropertyChange(() => this.RGB_Brightness);
        this.NotifyOfPropertyChange(() => this.RGBEdit);
      }
    }

    /// <summary>Gets the RGB Model being edited.</summary>
    public RGBModel RGBEdit
    {
      get => this.rgbEdit;
    }

    /// <summary>Save the edits to the RGB Model.</summary>
    public void SaveButton()
    {
      this.eventAggregator.PublishOnBackgroundThreadAsync(new RGBChangeEvent(this.rgbEdit));
      this.TryCloseAsync();
    }

    /// <summary>Cancel the edits to the RGB Model.</summary>
    public void CancelButton()
    {
      this.TryCloseAsync();
    }
  }
}
