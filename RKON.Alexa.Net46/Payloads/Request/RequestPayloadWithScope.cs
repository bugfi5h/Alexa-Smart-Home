
using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects.Scopes;

namespace RKon.Alexa.NET46.Payloads
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
