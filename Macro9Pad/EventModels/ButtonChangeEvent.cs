// <copyright file="ButtonChangeEvent.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Models;

namespace Macro9Pad.EventModels
{
  /// <summary>Event model for button changes.</summary>
  public class ButtonChangeEvent
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonChangeEvent"/> class.
    /// </summary>
    /// <param name="buttonNumber">Number of the button being changed.</param>
    /// <param name="button">Instance of button that describes new values.</param>
    public ButtonChangeEvent(int buttonNumber, ButtonModel button)
    {
      this.ButtonNumber = buttonNumber;
      this.Button = button;
    }

    /// <summary>Gets the changed buttons number.</summary>
    public int ButtonNumber { get; }

    /// <summary>Gets the changed buttons values.</summary>
    public ButtonModel Button { get; }
  }
}
