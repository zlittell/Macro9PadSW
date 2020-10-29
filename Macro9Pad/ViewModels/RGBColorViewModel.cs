using Caliburn.Micro;
using Macro9Pad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.ViewModels
{
    public class RGBColorViewModel : Screen
    {
        private RGBModel rgbEdit { get; set; }

        public RGBColorViewModel(RGBModel rgb)
        {
            this.rgbEdit = rgb;
        }
    }
}
