using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for SetPercentage Requests
    /// </summary>
    public class SetPercentageRequestPayload : Payload
    {
        /// <summary>
        /// The percentage value to set for the device. Integer from 0-100, inclusive.
        /// </summary>
        [JsonProperty(PropertyNames.PERCENTAGE)]
        public int Percentage { get; set; }
    }
}
