// <copyright file="ProfileReadWriteHelper.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Macro9Pad.Device.Models;
using Microsoft.Win32;

namespace Macro9Pad.Helpers
{
  public class ProfileReadWriteHelper
  {
    // RGB (4bytes) plus Buttons 1-9 (2bytes ea)
    private const int ProfileLength = 4 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2;

    public DeviceContentsModel ReadFile()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "[MSF] Profile Text Files (*.msf)|*.msf|All files (*.*)|*.*";
      openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      if (openFileDialog.ShowDialog() == true)
      {
        var fileText = File.ReadAllLines(openFileDialog.FileName).ToList();
        var model = this.ProcessStringListToProfile(fileText);
        return model;
      }

      return null;
    }

    public void WriteFile(DeviceContentsModel contents)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "[MSF] Profile Text Files (*.msf)|*.msf|All files (*.*)|*.*";
      saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      if (saveFileDialog.ShowDialog() == true)
      {
        var outputStringList = this.ProcessProfileToStringList(contents);
        if (outputStringList != null)
        {
          File.WriteAllLines(saveFileDialog.FileName, outputStringList);
        }
      }
    }

    private List<string> ProcessProfileToStringList(DeviceContentsModel contents)
    {
      if (contents != null)
      {
        List<string> stringList = new List<string>();
        var byteList = contents.ToBytes();
        foreach (byte item in byteList)
        {
          stringList.Add(Convert.ToString(item));
        }

        return stringList;
      }

      return null;
    }

    private DeviceContentsModel ProcessStringListToProfile(List<string> profileList)
    {
      if (profileList.Count == ProfileLength)
      {
        List<byte> byteList = new List<byte>();

        foreach (string item in profileList)
        {
          byteList.Add(Convert.ToByte(item));
        }

        return new DeviceContentsModel(byteList.ToArray());
      }

      return null;
    }
  }
}
