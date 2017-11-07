using Newtonsoft.Json;
using RKon.Alexa.NET46.Types;

namespace RKon.Alexa.NET46.Payloads
{
    /// <summary>
    /// Payload for SetBrightnessRequests
    /// </summary>
    public class SetBrightnessRequestPayload : Payload
    {
        /// <summary>
        /// A value that indicates the desired brightness as a percentage. integer from 0-100, inclusive.
        /// </summary>
        [JsonProperty(PropertyNames.BRIGHTNESS)]
        public int Brightness { get; set; }
    }
}
