using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Macro9Pad.EventModels;
using Macro9Pad.Models;

namespace Macro9Pad.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly IWindowManager windowManager;

        private readonly DeviceModel deviceContents;
        
        public MainViewModel(IWindowManager windowManager, DeviceModel deviceModel)
        {
            this.windowManager = windowManager;
            this.deviceContents = deviceModel;
        }

        public DeviceModel Device
        {
            get
            {
                return this.deviceContents;
            }
        }

        public void EditSettings()
        {
            this.windowManager.ShowDialogAsync(new SettingsViewModel());
        }

        public void RGBEdit()
        {
            this.windowManager.ShowDialogAsync(new RGBColorViewModel((RGBModel)this.deviceContents.RGB.Clone()));
        }

        public void ButtonEdit(int buttonNumber)
        {
            var button = new ButtonModel();
            switch (buttonNumber)
            {
                case 1:
                {
                    button = this.deviceContents.Button1;
                    break;
                }

                case 2:
                {
                    button = this.deviceContents.Button2;
                    break;
                }

                case 3:
                {
                    button = this.deviceContents.Button3;
                    break;
                }

                case 4:
                {
                    button = this.deviceContents.Button4;
                    break;
                }

                case 5:
                {
                    button = this.deviceContents.Button5;
                    break;
                }

                case 6:
                {
                    button = this.deviceContents.Button6;
                    break;
                }

                case 7:
                {
                    button = this.deviceContents.Button7;
                    break;
                }

                case 8:
                {
                    button = this.deviceContents.Button8;
                    break;
                }

                case 9:
                {
                    button = this.deviceContents.Button9;
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(buttonNumber), "Button number must exist.");
                }
            }

            this.windowManager.ShowDialogAsync(new ButtonEditViewModel(button));
        }

        public void LoadProfile()
        {
            // Load profile from file
        }

        public void SaveProfile()
        {
            // Save profile to file
        }

        public void StoreProfile()
        {
            // Tell device to save profile to memory
        }
    }
}