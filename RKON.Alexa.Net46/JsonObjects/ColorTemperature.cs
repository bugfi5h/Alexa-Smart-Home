using Newtonsoft.Json;


namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// Like TargetTemperature with limit between 1000 and 10000
    /// </summary>
    public class ColorTemperature
    {
        private double mValue;
        /// <summary>
        /// value
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
