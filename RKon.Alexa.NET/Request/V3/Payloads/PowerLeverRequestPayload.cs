
using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload class for power level requests
    /// </summary>
    public class PowerLeverRequestPayload : Payload
    {
        /// <summary>
        /// Indicates the desired power level (0-100) for the device.
        /// </summary>
        [JsonProperty("powerLever")]
        public int PowerLever { get; set; }
    }
}
