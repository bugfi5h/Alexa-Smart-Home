﻿using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types.PayloadObjects
{
    /// <summary>
    /// Klasse für Farbobjekte mit HUE
    /// </summary>
    public class Color
    {
        private double mHue;
        private double mSaturation;
        private double mBrightness;

        /// <summary>
        /// Double zwischen 0.00 und 360.00
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
        /// Double zwischen 0.0000 und 1.0000
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
        /// Double zwischen 0.0000 und 1.00000
        /// </summary>
        [JsonProperty("brightness")]
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
    }
}