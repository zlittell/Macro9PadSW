using Caliburn.Micro;

namespace Macro9Pad.Models
{
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
    }
}
