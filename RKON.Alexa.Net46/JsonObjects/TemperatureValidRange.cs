using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// ValidRange for TEMPERATURE_VALUE_OUT_OF_RANGE
    /// </summary>
    public class TemperatureValidRange
    {
        /// <summary>
        /// Smallest allowed value for a device
        /// </summary>
        [JsonProperty("minimumValue")]
        [JsonRequired]
        public Setpoint MinimumValue { get; set; }
        /// <summary>
        /// Biggest allowed value for a device
        /// </summary>
        [JsonProperty("maximumValue")]
        [JsonRequired]
        public Setpoint MaximumValue { get; set; }

        /// <summary>
        /// StandardConstructor
        /// </summary>
        public TemperatureValidRange()
        {

        }

        /// <summary>
        /// Initialise TemperatureValidRange
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public TemperatureValidRange(Setpoint min, Setpoint max)
        {
            MinimumValue = min;
            MaximumValue = max;
        }
    }
}
