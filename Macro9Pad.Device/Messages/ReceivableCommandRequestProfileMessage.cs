using Macro9Pad.Device.Models;
using MSF.USBMessages;
using System.Collections.Immutable;
using System.Linq;

namespace Macro9Pad.Device.Messages
{
  public class ReceivableCommandRequestProfileMessage : MacroPadReceivableUSBMessage, IMacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <inheritdoc/>
    public override byte Command => (byte)MacroPadCommandType.SendProfile;

    /// <summary>Gets the contents of the device received from device.</summary>
    public DeviceContentsModel DeviceContents { get; private set; }

    /// <inheritdoc/>
    public override void ParsePayload(ImmutableArray<byte> payload)
    {
      this.DeviceContents = new DeviceContentsModel(payload.ToArray());
    }
  }
}
