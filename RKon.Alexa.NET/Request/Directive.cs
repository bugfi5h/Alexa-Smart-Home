using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;
using RKon.Alexa.NET.Payloads;

namespace RKon.Alexa.NET.Request
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
