using Newtonsoft.Json;
using RKon.Alexa.NET46.JsonObjects;
using RKon.Alexa.NET46.Payloads;

namespace RKon.Alexa.NET46.Request
{
    /// <summary>
    /// Directive from Alexa
    /// </summary>
    [JsonConverter(typeof(SmartHomeRequestConverter))]
    public class Directive
    {
        /// <summary>
        /// Requestheader
        /// </summary>
        [JsonProperty("header")]
        public DirectiveHeader Header { get; set; }
        /// <summary>
        /// Requestpayload
        /// </summary>
        [JsonProperty("payload")]
        public Payload Payload { get; set; }
        /// <summary>
        /// Requested Endpoint
        /// </summary>
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }
    }
}
