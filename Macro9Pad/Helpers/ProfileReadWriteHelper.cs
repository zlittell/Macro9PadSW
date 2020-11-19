// <copyright file="ProfileReadWriteHelper.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Macro9Pad.Device.Models;
using Microsoft.Win32;

namespace Macro9Pad.Helpers
{
  /// <summary>Profile file read and file write helper.</summary>
  public class ProfileReadWriteHelper
  {
    // RGB (4bytes) plus Buttons 1-9 (2bytes ea)
    private const int ProfileLength = 4 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2;

    /// <summary>Reads the file selected by user.</summary>
    /// <returns>Profile parsed from file.</returns>
    public DeviceContentsModel ReadFile()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog
      {
        Filter = "[MSF] Profile Text Files (*.msf)|*.msf|All files (*.*)|*.*",
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      };
      if (openFileDialog.ShowDialog() == true)
      {
        var fileText = File.ReadAllLines(openFileDialog.FileName).ToList();
        var model = this.ProcessStringListToProfile(fileText);
        return model;
      }

      return null;
    }

    /// <summary>Writes the file selected by the user.</summary>
    /// <param name="contents">Profile to write to file.</param>
    public void WriteFile(DeviceContentsModel contents)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog
      {
        Filter = "[MSF] Profile Text Files (*.msf)|*.msf|All files (*.*)|*.*",
        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
      };
      if (saveFileDialog.ShowDialog() == true)
      {
        var outputStringList = this.ProcessProfileToStringList(contents);
        if (outputStringList != null)
        {
          File.WriteAllLines(saveFileDialog.FileName, outputStringList);
        }
      }
    }

    /// <summary>Profile as a list of strings.</summary>
    /// <param name="contents">Profile to convert.</param>
    /// <returns>List of strings represents profile.</returns>
    private List<string> ProcessProfileToStringList(DeviceContentsModel contents)
    {
      if (contents != null)
      {
        List<string> stringList = new List<string>();
        var byteList = contents.ToBytes();
        foreach (byte item in byteList)
        {
          stringList.Add(Convert.ToString(item, CultureInfo.InvariantCulture));
        }

        return stringList;
      }

      return null;
    }

    /// <summary>Converts a list of strings to a profile.</summary>
    /// <param name="profileList">List of strings to convert.</param>
    /// <returns>Profile converted from strings.</returns>
    private DeviceContentsModel ProcessStringListToProfile(List<string> profileList)
    {
      if (profileList.Count == ProfileLength)
      {
        List<byte> byteList = new List<byte>();

        foreach (string item in profileList)
        {
          byteList.Add(Convert.ToByte(item, CultureInfo.InvariantCulture));
        }

        return new DeviceContentsModel(byteList.ToArray());
      }

      return null;
    }
  }
}
