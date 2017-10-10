using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Request.RequestPayloads
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
