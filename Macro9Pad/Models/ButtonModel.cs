using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Macro9Pad.Models
{
    public class ButtonModel
    {
        public byte Modifier { get; set; }

        public byte Button { get; set; }

        public ButtonModel()
        {
            this.Modifier = 0x00;
            this.Button = 0x00;
        }

        public ButtonModel(byte button)
        {
            this.Modifier = 0x00;
            this.Button = button;
        }

        public ButtonModel(byte modifier, byte button)
        {
            this.Modifier = modifier;
            this.Button = button;
        }
    }
}
