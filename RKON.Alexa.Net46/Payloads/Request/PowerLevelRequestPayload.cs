
using Newtonsoft.Json;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload class for power level requests
    /// </summary>
    public class PowerLevelRequestPayload : Payload
    {
        /// <summary>
        /// Indicates the desired power level (0-100) for the device.
        /// </summary>
        [JsonProperty("powerLevel")]
        public int PowerLevel { get; set; }
    }
}
