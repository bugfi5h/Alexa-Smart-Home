using Newtonsoft.Json;


namespace RKon.Alexa.NET.Response.ErrorResponses
{
    /// <summary>
    /// Payload für ValueOutOfRange
    /// </summary>
    public class ValueOutOfRangePayload : ResponsePayload
    {
        /// <summary>
        /// Minimalwert
        /// </summary>
        [JsonRequired]
        [JsonProperty("minimumValue")]
        public double MinimumValue { get; set; }
        /// <summary>
        /// Maximalwert
        /// </summary>
        [JsonRequired]
        [JsonProperty("maximumValue")]
        public double MaximumValue { get; set; }
        /// <summary>
        /// Konstruktor. Setzt Minimal und Maximalwert
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
