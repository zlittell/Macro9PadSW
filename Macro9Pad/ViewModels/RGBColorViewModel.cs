using Caliburn.Micro;
using Macro9Pad.EventModels;
using Macro9Pad.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Macro9Pad.ViewModels
{
    public class RGBColorViewModel : Screen
    {
        private RGBModel rgbEdit;

        private IEventAggregator eventAggregator;

        public RGBColorViewModel(IEventAggregator evAgg, RGBModel rgb)
        {
            this.rgbEdit = rgb;
            this.eventAggregator = evAgg;
        }

        public byte RGB_Red
        {
            get => this.rgbEdit.Red;

            set
            {
                this.rgbEdit.Red = value;
                this.NotifyOfPropertyChange(() => this.RGB_Red);
                this.NotifyOfPropertyChange(() => this.RGBEdit);
            }
        }

        public byte RGB_Green
        {
            get => this.rgbEdit.Green;

            set
            {
                this.rgbEdit.Green = value;
                this.NotifyOfPropertyChange(() => this.RGB_Green);
                this.NotifyOfPropertyChange(() => this.RGBEdit);
            }
        }

        public byte RGB_Blue
        {
            get => this.rgbEdit.Blue;

            set
            {
                this.rgbEdit.Blue = value;
                this.NotifyOfPropertyChange(() => this.RGB_Blue);
                this.NotifyOfPropertyChange(() => this.RGBEdit);
            }
        }

        public byte RGB_Brightness
        {
            get => this.rgbEdit.Brightness;

            set
            {
                this.rgbEdit.Brightness = value;
                this.NotifyOfPropertyChange(() => this.RGB_Brightness);
                this.NotifyOfPropertyChange(() => this.RGBEdit);
            }
        }

        public RGBModel RGBEdit
        {
            get => this.rgbEdit;
        }

        public void SaveButton()
        {
            this.eventAggregator.PublishOnUIThreadAsync(new RGBChangeEvent(this.rgbEdit));
            this.TryCloseAsync();
        }

        public void CancelButton()
        {
            this.TryCloseAsync();
        }
    }
}
