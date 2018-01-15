
using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects.Scopes;

namespace RKon.Alexa.NET.Payloads
{
    /// <summary>
    /// Requestpalyoud containing a Scope
    /// </summary>
    public class RequestPayloadWithScope : Payload
    {
        /// <summary>
        /// Scope of the Payload
        /// </summary>
        [JsonProperty("scope")]
        public Scope Scope { get; set; }
    }
}
