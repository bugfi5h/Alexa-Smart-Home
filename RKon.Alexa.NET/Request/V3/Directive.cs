using Newtonsoft.Json;
using RKon.Alexa.NET.Request.RequestPayloads;

namespace RKon.Alexa.NET.Request.V3
{
    [JsonConverter(typeof(SmartHomeRequestConverter))]
    public class Directive
    {
        [JsonProperty("header")]
        public DirectiveHeader Header { get; set; }
        [JsonProperty("payload")]
        public RequestPayload Payload { get; set; }
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }
    }
}
