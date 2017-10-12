using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload for ValueOutOfRange
    /// </summary>
    public class ValueOutOfRangePayload : ResponsePayload
    {
        /// <summary>
        /// Minimum value
        /// </summary>
        [JsonRequired]
        [JsonProperty("minimumValue")]
        public double MinimumValue { get; set; }
        /// <summary>
        /// Maximum value
        /// </summary>
        [JsonRequired]
        [JsonProperty("maximumValue")]
        public double MaximumValue { get; set; }
        /// <summary>
        /// Constructor. Sets minimal and maximal value
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public ValueOutOfRangePayload(double min, double max)
        {
            MinimumValue = min;
            MaximumValue = max;
        }
    }
}
