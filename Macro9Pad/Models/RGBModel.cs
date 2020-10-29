using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.Models
{
    public class RGBModel
    {
        public byte Red { get; private set; }

        public byte Green { get; private set; }

        public byte Blue { get; private set; }

        public byte Brightness { get; private set; }

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
    }
}
