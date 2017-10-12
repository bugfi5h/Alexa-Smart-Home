using Newtonsoft.Json;
using RKon.Alexa.NET.JsonObjects;

namespace RKon.Alexa.NET.Request.V3
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
