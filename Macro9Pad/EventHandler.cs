using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Macro9Pad.EventModels;
using Macro9Pad.Models;

namespace Macro9Pad
{
    public class EventHandler : INotifyPropertyChanged, IHandle<ButtonChangeEvent>, IHandle<RGBChangeEvent>
    {
        private readonly IEventAggregator eventAggregator;

        private readonly DeviceModel deviceContents;

        public EventHandler(IEventAggregator evAgg, DeviceModel deviceModel)
        {
            this.eventAggregator = evAgg;
            this.deviceContents = deviceModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Task HandleAsync(ButtonChangeEvent message, CancellationToken cancellationToken)
        {
            switch (message?.ButtonNumber)
            {
                case 1:
                {
                    this.deviceContents.Button1 = message.Button;
                    break;
                }

                case 2:
                {
                    this.deviceContents.Button2 = message.Button;
                    break;
                }

                case 3:
                {
                    this.deviceContents.Button3 = message.Button;
                    break;
                }

                case 4:
                {
                    this.deviceContents.Button4 = message.Button;
                    break;
                }

                case 5:
                {
                    this.deviceContents.Button5 = message.Button;
                    break;
                }

                case 6:
                {
                    this.deviceContents.Button6 = message.Button;
                    break;
                }

                case 7:
                {
                    this.deviceContents.Button7 = message.Button;
                    break;
                }

                case 8:
                {
                    this.deviceContents.Button8 = message.Button;
                    break;
                }

                case 9:
                {
                    this.deviceContents.Button9 = message.Button;
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(message), "Button Number needs to be an actual button.");
                }
            }

            this.OnPropertyChanged(() => this.deviceContents);
            return Task.CompletedTask;
        }

        public Task HandleAsync(RGBChangeEvent message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
