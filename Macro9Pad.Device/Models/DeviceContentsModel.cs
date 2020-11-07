// <copyright file="DeviceContentsModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Macro9Pad.Device.Models
{
  /// <summary>Model of a Device's Contents.</summary>
  public class DeviceContentsModel : PropertyChangedBase, ICloneable
  {
    // RGB (4bytes) plus Buttons 1-9 (2bytes ea)
    private const int ContentsByteLength = 4 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2 + 2;

    private RGBModel rgb;

    private ButtonModel b1;

    private ButtonModel b2;

    private ButtonModel b3;

    private ButtonModel b4;

    private ButtonModel b5;

    private ButtonModel b6;

    private ButtonModel b7;

    private ButtonModel b8;

    private ButtonModel b9;


    /// <summary>
    /// Initializes a new instance of the <see cref="DeviceContentsModel"/> class.
    /// </summary>
    public DeviceContentsModel()
    {
      this.rgb = new RGBModel();
      this.b1 = new ButtonModel();
      this.b2 = new ButtonModel();
      this.b3 = new ButtonModel();
      this.b4 = new ButtonModel();
      this.b5 = new ButtonModel();
      this.b6 = new ButtonModel();
      this.b7 = new ButtonModel();
      this.b8 = new ButtonModel();
      this.b9 = new ButtonModel();
    }

    public DeviceContentsModel(byte[] contents)
    {
      if (contents == null)
      {
        throw new ArgumentNullException(nameof(contents));
      }
      else if (contents.Length != ContentsByteLength)
      {
        throw new ArgumentOutOfRangeException(nameof(contents), "Length must match profile length");
      }

      int i = 0;
      this.rgb = new RGBModel(contents.Take(4).ToArray());
      i += 4;
      this.b1 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b2 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b3 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b4 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b5 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b6 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b7 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b8 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
      i += 2;
      this.b9 = new ButtonModel(contents.Skip(i).Take(2).ToArray());
    }

    /// <summary>Gets or sets RGBModel of device.</summary>
    public RGBModel RGB
    {
      get
      {
        return this.rgb;
      }

      set
      {
        this.rgb = value;
        this.NotifyOfPropertyChange(() => this.RGB);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button1 of device.</summary>
    public ButtonModel Button1
    {
      get
      {
        return this.b1;
      }

      set
      {
        this.b1 = value;
        this.NotifyOfPropertyChange(() => this.Button1);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button2 of device.</summary>
    public ButtonModel Button2
    {
      get
      {
        return this.b2;
      }

      set
      {
        this.b2 = value;
        this.NotifyOfPropertyChange(() => this.Button2);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button3 of device.</summary>
    public ButtonModel Button3
    {
      get
      {
        return this.b3;
      }

      set
      {
        this.b3 = value;
        this.NotifyOfPropertyChange(() => this.Button3);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button4 of device.</summary>
    public ButtonModel Button4
    {
      get
      {
        return this.b4;
      }

      set
      {
        this.b4 = value;
        this.NotifyOfPropertyChange(() => this.Button4);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button5 of device.</summary>
    public ButtonModel Button5
    {
      get
      {
        return this.b5;
      }

      set
      {
        this.b5 = value;
        this.NotifyOfPropertyChange(() => this.Button5);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button6 of device.</summary>
    public ButtonModel Button6
    {
      get
      {
        return this.b6;
      }

      set
      {
        this.b6 = value;
        this.NotifyOfPropertyChange(() => this.Button6);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button7 of device.</summary>
    public ButtonModel Button7
    {
      get
      {
        return this.b7;
      }

      set
      {
        this.b7 = value;
        this.NotifyOfPropertyChange(() => this.Button7);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button8 of device.</summary>
    public ButtonModel Button8
    {
      get
      {
        return this.b8;
      }

      set
      {
        this.b8 = value;
        this.NotifyOfPropertyChange(() => this.Button8);
      }
    }

    /// <summary>Gets or sets ButtonModel for Button9 of device.</summary>
    public ButtonModel Button9
    {
      get
      {
        return this.b9;
      }

      set
      {
        this.b9 = value;
        this.NotifyOfPropertyChange(() => this.Button9);
      }
    }

    /// <summary>
    /// Converts Device Contents to byte array.
    /// </summary>
    /// <returns>byte array of profile.</returns>
    public byte[] ToBytes()
    {
      List<byte> tempBytes = new List<byte>
      {
        this.rgb.Red,
        this.rgb.Green,
        this.rgb.Blue,
        this.rgb.Brightness,
        this.b1.Modifier,
        this.b1.Button,
        this.b2.Modifier,
        this.b2.Button,
        this.b3.Modifier,
        this.b3.Button,
        this.b4.Modifier,
        this.b4.Button,
        this.b5.Modifier,
        this.b5.Button,
        this.b6.Modifier,
        this.b6.Button,
        this.b7.Modifier,
        this.b7.Button,
        this.b8.Modifier,
        this.b8.Button,
        this.b9.Modifier,
        this.b9.Button
      };
      return tempBytes.ToArray();
    }

    /// <inheritdoc/>
    public object Clone()
    {
      var returnContents = new DeviceContentsModel()
      {
        rgb = (RGBModel)this.rgb.Clone(),
        b1 = (ButtonModel)this.b1.Clone(),
        b2 = (ButtonModel)this.b2.Clone(),
        b3 = (ButtonModel)this.b3.Clone(),
        b4 = (ButtonModel)this.b4.Clone(),
        b5 = (ButtonModel)this.b5.Clone(),
        b6 = (ButtonModel)this.b6.Clone(),
        b7 = (ButtonModel)this.b7.Clone(),
        b8 = (ButtonModel)this.b8.Clone(),
        b9 = (ButtonModel)this.b9.Clone(),
      };

      return returnContents;
    }
  }
}
