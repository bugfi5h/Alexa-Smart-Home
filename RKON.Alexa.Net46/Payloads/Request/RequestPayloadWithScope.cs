
using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;

namespace RKon.Alexa.NET46.Payloads.Request
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
