// <copyright file="RGBModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;

namespace Macro9Pad.Models
{
  /// <summary>
  /// Models the RGB led of the device.
  /// </summary>
  public class RGBModel : ICloneable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RGBModel"/> class.
    /// </summary>
    public RGBModel()
    {
      this.Red = 0xFF;
      this.Green = 0xFF;
      this.Blue = 0xFF;
      this.Brightness = 0xFF;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RGBModel"/> class.
    /// </summary>
    /// <param name="brightness">Brightness byte of RGB.</param>
    public RGBModel(byte brightness)
    {
      this.Red = 0xFF;
      this.Green = 0xFF;
      this.Blue = 0xFF;
      this.Brightness = brightness;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RGBModel"/> class.
    /// </summary>
    /// <param name="red">Red byte of RGB.</param>
    /// <param name="green">Green byte of RGB.</param>
    /// <param name="blue">Blue byte of RGB.</param>
    /// <param name="brightness">Brightness byte of RGB.</param>
    public RGBModel(byte red, byte green, byte blue, byte brightness)
    {
      this.Red = red;
      this.Green = green;
      this.Blue = blue;
      this.Brightness = brightness;
    }

    /// <summary>Gets or sets the Red byte of RGB.</summary>
    public byte Red { get; set; }

    /// <summary>Gets or sets the Green byte of RGB.</summary>
    public byte Green { get; set; }

    /// <summary>Gets or sets the Blue byte of RGB.</summary>
    public byte Blue { get; set; }

    /// <summary>Gets or sets the Brightness byte of RGB.</summary>
    public byte Brightness { get; set; }

    /// <inheritdoc/>
    public object Clone()
    {
      var rgb = new RGBModel
      {
        Red = this.Red,
        Green = this.Green,
        Blue = this.Blue,
        Brightness = this.Brightness,
      };
      return rgb;
    }
  }
}
