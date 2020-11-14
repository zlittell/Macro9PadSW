// <copyright file="DeviceVersion.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;

namespace Macro9Pad.Device.Models
{
  /// <summary>Version Class.</summary>
  public class DeviceVersionModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceVersionModel"/> class.
    /// </summary>
    /// <param name="majorByte">Byte that represents major version.</param>
    /// <param name="minorByte">Byte that represents minor version.</param>
    /// <param name="revisionByte">Byte that represents revision version.</param>
    public DeviceVersionModel(byte majorByte, byte minorByte, byte revisionByte)
    {
      this.UpdateVersionMajor(majorByte);
      this.UpdateVersionMinor(minorByte);
      this.UpdateVersionRevision(revisionByte);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceVersionModel"/> class.
    /// </summary>
    public DeviceVersionModel()
    {
      this.UpdateVersionMajor(0x00);
      this.UpdateVersionMinor(0x00);
      this.UpdateVersionRevision(0x00);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceVersionModel"/> class.
    /// </summary>
    /// <param name="versionBytes">Byte array to convert to version.</param>
    public DeviceVersionModel(byte[] versionBytes)
    {
      if (versionBytes != null)
      {
        if (versionBytes.Length >= 3)
        {
          this.UpdateVersionMajor(versionBytes[0]);
          this.UpdateVersionMinor(versionBytes[1]);
          this.UpdateVersionRevision(versionBytes[2]);
        }
        else
        {
          throw new ArgumentOutOfRangeException(nameof(versionBytes), "Must be 3 bytes long");
        }
      }
      else
      {
        this.UpdateVersionMajor(0x00);
        this.UpdateVersionMinor(0x00);
        this.UpdateVersionRevision(0x00);
      }
    }

    /// <summary>Gets Major Version.</summary>
    public uint Major { get; private set; }

    /// <summary>Gets Minor Version.</summary>
    public uint Minor { get; private set; }

    /// <summary>Gets Revision Version.</summary>
    public uint Revision { get; private set; }

    /// <summary>
    /// Updates version major.
    /// </summary>
    /// <param name="majorByte">Byte to convert to version major.</param>
    public void UpdateVersionMajor(byte majorByte)
    {
      this.Major = majorByte;
    }

    /// <summary>
    /// Updates version minor.
    /// </summary>
    /// <param name="minorByte">Byte to convert to version minor.</param>
    public void UpdateVersionMinor(byte minorByte)
    {
      this.Minor = minorByte;
    }

    /// <summary>
    /// Updates version revision.
    /// </summary>
    /// <param name="revisionByte">Byte to convert to version revision.</param>
    public void UpdateVersionRevision(byte revisionByte)
    {
      this.Revision = revisionByte;
    }

    /// <summary>
    /// Converts version major, minor, revision to byte array.
    /// </summary>
    /// <returns>byte array that represents version.</returns>
    public byte[] ReturnVersionByteArray()
    {
      return new byte[] { (byte)this.Major, (byte)this.Minor, (byte)this.Revision };
    }

    public string ReturnVersionString()
    {
      var output = new System.Text.StringBuilder();
      output.Append("V");
      output.Append(this.Major.ToString("D2"));
      output.Append(".");
      output.Append(this.Minor.ToString("D2"));
      output.Append(".");
      output.Append(this.Revision.ToString("D2"));
      return output.ToString();
    }
  }
}
