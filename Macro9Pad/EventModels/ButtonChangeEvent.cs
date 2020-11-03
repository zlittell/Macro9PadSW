using Macro9Pad.Models;
using System.ComponentModel;

namespace Macro9Pad.EventModels
{
    public class ButtonChangeEvent
    {
        public ButtonChangeEvent(int buttonNumber, ButtonModel button)
        {
            this.ButtonNumber = buttonNumber;
            this.Button = button;
        }

        public int ButtonNumber { get; }

        public ButtonModel Button { get; }
    }
}
