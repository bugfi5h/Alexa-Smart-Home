using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;

namespace RKon.Alexa.NET.Request.RequestPayloads
{
    /// <summary>
    /// Payload für einen SetColorRequest
    /// </summary>
    public class SetColorRequestPayload : RequestPayloadWithAppliance
    {
        /// <summary>
        /// Color Objekt mit Hue, Saturation und Brightness
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }
    }
}
