namespace Macro9Pad.Models
{
    public class DeviceModel
    {
        public RGBModel RGB { get; private set; } = new RGBModel();

        public ButtonModel Button1 { get; private set; } = new ButtonModel();

        public ButtonModel Button2 { get; private set; } = new ButtonModel();

        public ButtonModel Button3 { get; private set; } = new ButtonModel();

        public ButtonModel Button4 { get; private set; } = new ButtonModel();

        public ButtonModel Button5 { get; private set; } = new ButtonModel();

        public ButtonModel Button6 { get; private set; } = new ButtonModel();

        public ButtonModel Button7 { get; private set; } = new ButtonModel();

        public ButtonModel Button8 { get; private set; } = new ButtonModel();

        public ButtonModel Button9 { get; private set; } = new ButtonModel();
    }
}
