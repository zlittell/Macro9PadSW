// <copyright file="RGBChangeEvent.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Macro9Pad.Models;

namespace Macro9Pad.EventModels
{
  /// <summary>Change event for RGB changes.</summary>
  public class RGBChangeEvent
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RGBChangeEvent"/> class.
    /// </summary>
    /// <param name="rgb">Instance of RGB model with changes.</param>
    public RGBChangeEvent(RGBModel rgb)
    {
      this.RGBValues = rgb;
    }

    /// <summary>Gets the new instance of RGB values.</summary>
    public RGBModel RGBValues { get; }
  }
}
