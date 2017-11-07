using Newtonsoft.Json;

namespace RKon.Alexa.NET46.JsonObjects
{
    /// <summary>
    /// ValidRange for VALUE_OUT_OF_RANGE
    /// </summary>
    public class ValidRange
    {
        /// <summary>
        /// Smallest allowed value for a device
        /// </summary>
        [JsonProperty("minimumValue")]
        [JsonRequired]
        public double MinimumValue { get; set; }
        /// <summary>
        /// Biggest allowed value for a device
        /// </summary>
        [JsonProperty("maximumValue")]
        [JsonRequired]
        public double MaximumValue { get; set; }

        /// <summary>
        /// Standardconstructor
        /// </summary>
        public ValidRange()
        {

        }

        /// <summary>
        /// Initializes ValidRange
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public ValidRange(double min, double max)
        {
            MinimumValue = min;
            MaximumValue = max;
        }
    }
}
