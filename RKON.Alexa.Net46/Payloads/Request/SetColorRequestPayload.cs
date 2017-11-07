using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for a SetColorRequest
    /// </summary>
    public class SetColorRequestPayload : Payload
    {
        /// <summary>
        /// Describes the color to set for the light. Specified in the hue, saturation, brightness (HSB) color model.
        /// </summary>
        [JsonProperty(PropertyNames.COLOR)]
        public Color Color { get; set; }
    }
}
