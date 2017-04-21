using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für SetColorTemperature Requests
    /// </summary>
    public class ColorTemperatureRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Wert zwischen 1000 und 10000
        /// </summary>
        [JsonProperty("colorTemperature")]
        public ColorTemperature ColorTemperature { get; set; }
    }
}
