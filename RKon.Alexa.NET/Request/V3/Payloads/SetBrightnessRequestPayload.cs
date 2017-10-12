using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Payload for SetBrightnessRequests
    /// </summary>
    public class SetBrightnessRequestPayload : RequestPayload
    {
        /// <summary>
        /// A value that indicates the desired brightness as a percentage. integer from 0-100, inclusive.
        /// </summary>
        [JsonProperty(PropertyNames.BRIGHTNESS)]
        public int Brightness { get; set; }
    }
}
