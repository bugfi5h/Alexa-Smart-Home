using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Class for Colorobjects with HUE
    /// </summary>
    public class Color
    {
        private double mHue;
        private double mSaturation;
        private double mBrightness;

        /// <summary>
        /// Double between 0.00 and 360.00
        /// </summary>
        [JsonProperty("hue")]
        public double Hue
        {
            get { return mHue; }
            set
            {
                mHue = value;
                if (value < 0)
                    mHue = 0;
                else if (value > 360)
                {
                    mHue = 360;
                }
            }
        }
        /// <summary>
        /// Double between 0.0000 and 1.0000
        /// </summary>
        [JsonProperty("saturation")]
        public double Saturation
        {
            get { return mSaturation; }
            set
            {
                mSaturation = value;
                if (value < 0)
                    mSaturation = 0;
                if (value > 1)
                {
                    mSaturation = 1;
                }
            }
        }
        /// <summary>
        /// Double between 0.0000 and 1.00000
        /// </summary>
        [JsonProperty(PropertyNames.BRIGHTNESS)]
        public double Brightness
        {
            get { return mBrightness; }
            set
            {
                mBrightness = value;
                if (value < 0)
                    mBrightness = 0;
                if (value > 1)
                {
                    mBrightness = 1;
                }
            }
        }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public Color()
        {

        }

        /// <summary>
        /// Inintialises Colorelement
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        public Color(double hue, double saturation, double brightness)
        {
            Hue = hue;
            Saturation = saturation;
            Brightness = brightness;
        }
    }
}
