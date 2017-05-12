using Newtonsoft.Json;
using RKon.Alexa.NET46.Types.PayloadObjects;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Payload for SetColorTemperature Requests
    /// </summary>
    public class ColorTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Value between 1000 and 10000
        /// </summary>
        [JsonProperty("colorTemperature")]
        public ColorTemperature ColorTemperature { get; set; }
    }
}
