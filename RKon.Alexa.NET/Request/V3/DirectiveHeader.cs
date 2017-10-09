using Newtonsoft.Json;

namespace RKon.Alexa.NET.Request.V3
{
    public class DirectiveHeader : RequestHeader
    {
        [JsonProperty("correlationToken")]
        public string CorrelationToken { get; set; }
    }
}
