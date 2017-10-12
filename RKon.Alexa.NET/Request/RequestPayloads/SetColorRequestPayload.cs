using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Types;

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
        [JsonProperty(PropertyNames.COLOR)]
        public Color Color { get; set; }
    }
}
