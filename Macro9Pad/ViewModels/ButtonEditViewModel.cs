using Caliburn.Micro;
using Macro9Pad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.ViewModels
{
    public class ButtonEditViewModel : Screen
    {
        private ButtonModel buttonEdit { get; set; }

        public ButtonEditViewModel(ButtonModel button)
        {
            this.buttonEdit = button;
        }
    }
}
