
using Newtonsoft.Json;
using RKon.Alexa.NET.Types.PayloadObjects;

namespace RKon.Alexa.NET.Request.V3.Payloads
{
    /// <summary>
    /// Requestpalyoud containing a Scope
    /// </summary>
    public class RequestPayloadWithScope : RequestPayload
    {
        /// <summary>
        /// Scope of the Payload
        /// </summary>
        [JsonProperty("scope")]
        public Scope Scope { get; set; }
    }
}
