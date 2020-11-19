// <copyright file="ConnectionInfoUpdateEventModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

namespace Macro9Pad.EventModels
{
  /// <summary>Event model for Connection Info Update.</summary>
  public class ConnectionInfoUpdateEventModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionInfoUpdateEventModel"/> class.
    /// </summary>
    /// <param name="propertyName">Name of property that was updated.</param>
    public ConnectionInfoUpdateEventModel(string propertyName)
    {
      this.PropertyName = propertyName;
    }

    /// <summary>Gets name of property updated.</summary>
    public string PropertyName { get; private set; }
  }
}
