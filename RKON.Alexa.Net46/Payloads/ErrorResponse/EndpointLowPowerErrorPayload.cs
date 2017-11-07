using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for EnpointLowPower Errors
    /// </summary>
    public class EndpointLowPowerErrorPayload : ErrorPayload
    {
        /// <summary>
        /// percentageState value, which an integer between 0 and 100 that indicates the percentage of battery remaining for the device.
        /// </summary>
        [JsonProperty("percentageState")]
        [JsonRequired]
        public int PercentageState { get; set; }
    }
}
