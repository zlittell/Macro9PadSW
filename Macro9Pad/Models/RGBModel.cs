using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Macro9Pad.Models
{
    public class RGBModel : ICloneable
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte Brightness { get; set; }

        public RGBModel()
        {
            this.Red = 0xFF;
            this.Green = 0xFF;
            this.Blue = 0xFF;
            this.Brightness = 0xFF;
        }

        public RGBModel(byte brightness)
        {
            this.Red = 0xFF;
            this.Green = 0xFF;
            this.Blue = 0xFF;
            this.Brightness = brightness;
        }

        public RGBModel(byte red, byte green, byte blue, byte brightness)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.Brightness = brightness;
        }

        public object Clone()
        {
            var rgb = new RGBModel
            {
                Red = this.Red,
                Green = this.Green,
                Blue = this.Blue,
                Brightness = this.Brightness,
            };
            return rgb;
        }
    }
}
