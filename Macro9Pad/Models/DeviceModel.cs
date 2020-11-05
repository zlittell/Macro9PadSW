// <copyright file="DeviceModel.cs" company="Mechanical Squid Factory">
// Copyright © Mechanical Squid Factory Licensed under the Unlicense.
// </copyright>

using Caliburn.Micro;

namespace Macro9Pad.Models
{
  /// <summary>Model of a device and its contents.</summary>
  public class DeviceModel : PropertyChangedBase
  {
    private RGBModel rgb = new RGBModel();

    private ButtonModel b1 = new ButtonModel();

    private ButtonModel b2 = new ButtonModel();

    private ButtonModel b3 = new ButtonModel();

    private ButtonModel b4 = new ButtonModel();

    private ButtonModel b5 = new ButtonModel();

    private ButtonModel b6 = new ButtonModel();

    private ButtonModel b7 = new ButtonModel();

    private ButtonModel b8 = new ButtonModel();

    private ButtonModel b9 = new ButtonModel();

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

    /// <summary>Gets a value indicating whether or not the device is dirty and needs updated.</summary>
    public bool IsDirty { get; private set; }

    /// <summary>Sets the device as dirty and needing updated.</summary>
    public void SetDirty()
    {
      this.IsDirty = true;
    }

    /// <summary>Clears the device as dirty and needing updated.</summary>
    public void ClearDirty()
    {
      this.IsDirty = false;
    }
  }
}
