using Macro9Pad.Models;

namespace Macro9Pad.EventModels
{
    public class RGBChangeEvent
    {
        public RGBChangeEvent(RGBModel rgb)
        {
            this.RGBValues = rgb;
        }

        public RGBModel RGBValues { get; }
    }
}
