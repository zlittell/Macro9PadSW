// <copyright file="ButtonModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;

namespace Macro9Pad.Device.Models
{
  /// <summary>Class describing a button.</summary>
  public class ButtonModel : ICloneable
  {
    // Modifier, Button (1byte ea)
    private const int ButtonModelLength = 1 + 1;

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonModel"/> class.
    /// </summary>
    public ButtonModel()
    {
      this.Modifier = 0x00;
      this.Button = 0x00;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonModel"/> class.
    /// </summary>
    /// <param name="data">byte array to build Button Model with.</param>
    public ButtonModel(byte[] data)
    {
      if (data == null)
      {
        throw new ArgumentNullException(nameof(data));
      }
      else if (data.Length != ButtonModelLength)
      {
        throw new ArgumentOutOfRangeException(nameof(data), "Length must match Button model length");
      }

      this.Modifier = data[0];
      this.Button = data[1];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonModel"/> class.
    /// </summary>
    /// <param name="button">Byte for keypress to bind to button.</param>
    public ButtonModel(byte button)
    {
      this.Modifier = 0x00;
      this.Button = button;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonModel"/> class.
    /// </summary>
    /// <param name="modifier">Byte for modifier to bind to button.</param>
    /// <param name="button">Byte for keypress to bind to button.</param>
    public ButtonModel(byte modifier, byte button)
    {
      this.Modifier = modifier;
      this.Button = button;
    }

    /// <summary>Gets or sets the buttons Modifier.</summary>
    public byte Modifier { get; set; }

    /// <summary>Gets or sets the buttons Key binding.</summary>
    public byte Button { get; set; }

    /// <inheritdoc/>
    public object Clone()
    {
      var button = new ButtonModel
      {
        Button = this.Button,
        Modifier = this.Modifier,
      };
      return button;
    }
  }
}
