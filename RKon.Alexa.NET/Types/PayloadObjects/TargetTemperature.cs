using Newtonsoft.Json;

namespace RKon.Alexa.NET.Types
{
    /// <summary>
    /// Class for TargetTemperature
    /// </summary>
    public class TargetTemperature
    {
        /// <summary>
        /// Value
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
