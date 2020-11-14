using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.EventModels
{
  public class ConnectionInfoUpdateEventModel
  {
    public string PropertyName { get; private set; }

    public ConnectionInfoUpdateEventModel(string propertyName)
    {
      this.PropertyName = propertyName;
    }
  }
}
