using Newtonsoft.Json;
using RKon.Alexa.NET46.Types.PayloadObjects;

namespace RKon.Alexa.NET46.Request.RequestPayloads
{
    /// <summary>
    /// Payload for a SetColorRequest
    /// </summary>
    public class SetColorRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Color Object with Hue, Saturation and Brightness
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }
    }
}
