using Newtonsoft.Json;


namespace RKon.Alexa.NET.Types.PayloadObjects
{
    /// <summary>
    /// Wie TargetTemperature mit Begrenzung zwischen 1000 und 10000
    /// </summary>
    public class ColorTemperature
    {
        private double mValue;
        /// <summary>
        /// Wert
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public double Value
        {
            get
            {
                return mValue;
            }
            set
            {
                mValue = value;
                if (value < 1000)
                    mValue = 1000;
                if (value > 10000)
                    mValue = 10000;
            }
        }
    }
}
