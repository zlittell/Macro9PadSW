// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using MSF.USBMessages;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Macro9Pad.Device.Messages
{
  /// <summary>Receivable USB message for MacroPad devices.</summary>
  public abstract class MacroPadReceivableUSBMessage : MacroPadUSBMessage, IReceivableUSBMessage
  {
    /// <summary>
    /// From bytes.
    /// </summary>
    /// <typeparam name="T">Type of receivable usb message.</typeparam>
    /// <param name="data">Data used to create the usb message of type T.</param>
    /// <returns>Instance of receiveable usb message of type T.</returns>
    /// <exception cref="ArgumentNullException">Data is null.</exception>
    /// <exception cref="ArgumentException">Command does not match expected value.</exception>
    public static T FromBytes<T>(byte[] data)
      where T : MacroPadReceivableUSBMessage
    {
      MacroPadReceivableUSBMessage result = Activator.CreateInstance(typeof(T)) as MacroPadReceivableUSBMessage;

      if (data == null)
      {
        throw new ArgumentNullException(nameof(data));
      }

      if (data[0] != (byte)result.Command)
      {
        throw new ArgumentException(
          $"{nameof(result.Command)} '{data[0]}' must match expected value of {result.Command}.");
      }

      byte[] dataWithoutHeader = data.Skip(1).Take(data.Length - 1).ToArray();
      result.Payload = ImmutableArray.ToImmutableArray(dataWithoutHeader.ToArray());
      result.ParsePayload(result.Payload);
      return (T)result;
    }

    /// <inheritdoc/>
    public abstract void ParsePayload(ImmutableArray<byte> payload);
  }
}
